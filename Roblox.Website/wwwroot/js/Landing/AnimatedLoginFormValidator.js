;// Landing/AnimatedLoginFormValidator.js
typeof Roblox == "undefined" && (Roblox = {}), Roblox.AnimatedLoginFormValidator = function() {
    function t() {
        var t = $("#loginUsername"),
            n = $("#loginPassword");
        return t.val().length == 0 || n.val().length == 0 ? ($("#login-error").html(Roblox.Resources.AnimatedSignupFormValidator.loginFieldsRequired), $("#login-error").show(), !1) : ($("#login-error").hide(), !0)
    }
    return {
        validateLoginForm: t
    }
}();