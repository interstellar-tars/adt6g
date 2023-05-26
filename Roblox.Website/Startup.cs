﻿using System;

using Microsoft.AspNetCore.Authorization;

using Roblox.EventLog;

using Roblox.Platform.Membership;
using Roblox.Platform.Roles;
using Roblox.Platform.Email;
using Roblox.Platform.Authentication;

using Roblox.Website.Data;

namespace Roblox.Website
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="configuration"/> is null.</exception>
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        /// <summary>
        /// Configures the services
        /// </summary>
        /// <param name="services">The services. <seealso cref="IServiceCollection"/></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionString = _Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionString));
            //services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<Account>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<RobloxDbContext<Account, long, RobloxAccounts>>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = (HttpContext context) => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(RobloxCookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.LoginPath = RobloxCookieAuthenticationDefaults.LoginPath;
                });
            services.AddSingleton<IWebAuthenticator, WebAuthenticator>();

            services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                //options.FallbackPolicy = options.GetPolicy("Constraint");

                // Only allows access to the site if the user is authenticated.
                options.AddPolicy("Restricted", 
                    new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build()
                );
                // Only allows access to the site if the user is an employee.
                options.AddPolicy("EmployeesOnly", 
                    new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .RequireClaim("IsAdmin", true.ToString())
                        .Build()
                );
                // Only allows access to the site if the user has successfully provided the correct cookie to bypass the constraint.
                options.AddPolicy("Constraint", 
                    new AuthorizationPolicyBuilder()
                        .RequireClaim("IsConstrainted", false.ToString())
                        .Build()
                );
            });

            services.AddRazorPages(options =>
            {
                // TODO: This is not all-good; do some role-checking
                options.Conventions.AuthorizeFolder("/Admi/", "EmployeesOnly")
                    .AllowAnonymousToFolder("/");
            });

            ConfigureLogger(services);
            ConfigureDomainFactories(services);
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application <seealso cref="IApplicationBuilder"/></param>
        /// <param name="env">The env. <see cref="IWebHostEnvironment"/></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapRazorPages();
            });
        }

        /// <summary>
        /// Sets up and configures the logger for the current application.
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureLogger(IServiceCollection services)
        {
            // Construct application event logger
            var logger = new ConsoleLogger(
                () =>
                {
                    var logLevel = EventLog.LogLevel.Information;
                    var logLevelStr = _Configuration["LogLevel"];
                    if (!string.IsNullOrEmpty(logLevelStr))
                        logLevel = Enum.Parse<EventLog.LogLevel>(logLevelStr);
                    return logLevel;
                },
                logThreadId: false
            );

            services.AddSingleton<EventLog.ILogger>(logger);
        }

        /// <summary>
        /// Initializes and configures all platform domain-factories used by the current application.
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureDomainFactories(IServiceCollection services)
        {
            services.AddSingleton<MembershipDomainFactories>();
            services.AddSingleton<RoleDomainFactories>();
            services.AddSingleton<EmailDomainFactories>();
            services.AddSingleton<AuthenticationDomainFactories>();
        }
    }
}
