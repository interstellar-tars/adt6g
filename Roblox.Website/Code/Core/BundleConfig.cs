﻿using Roblox.Web.StaticContent;

namespace Roblox.Website
{
	public class BundleConfig
	{
		private readonly IScriptManager _scripts;
        private readonly IStyleManager _styles;

		public BundleConfig(IScriptManager scripts, IStyleManager styles)
		{
			_scripts = scripts;
			_styles = styles;
		}

        public void RegisterBundles()
		{
			_scripts.DeclareBundle(
				"master",
					"roblox.js",
					"jquery.json-2.2.js",
					"jquery.simplemodal-1.3.5.js",
					"jquery.tipsy.js",
					"AjaxAvatarThumbnail.js",
					"extensions/string.js",
					"StringTruncator.js",
					"json2.js",
					"webkit.js",
					"GoogleAnalytics/GoogleAnalyticsEvents.js",
					"MasterPageUI.js",
					"jquery.cookie.js",
					"jquery.jsoncookie.js",
					"JSErrorTracker.js",
					"RobloxEventManager.js",
					"RobloxEventListener.js",
					"GoogleEventListener.js",
					"MongoEventListener.js",
					"SiteTouchEvent.js",
					"jPlayer/2.4.0/jquery.jplayer.js",
					"XsrfToken.js",
					"jquery.ba-postmessage.js",
					"parentFrameLogin.js",
					"DropDownNav.js",
					"UpsellAdModal.js"
			);

			_scripts.DeclareBundle(
				"base",
					"roblox.js",
					"jquery.json-2.2.js",
					"jquery.simplemodal-1.3.5.js",
					"jquery.tipsy.js",
					"AjaxAvatarThumbnail.js",
					"extensions/string.js",
					"StringTruncator.js",
					"json2.js",
					"webkit.js",
					"GoogleAnalytics/GoogleAnalyticsEvents.js",
					"MasterPageUI.js",
					"jquery.cookie.js",
					"jquery.jsoncookie.js",
					"JSErrorTracker.js",
					"XsrfToken.js",
					"RobloxEventManager.js",
					"RobloxEventListener.js",
					"GoogleEventListener.js",
					"MongoEventListener.js",
					"SiteTouchEvent.js",
					"GPTAdScript.js",
					"DropDownNav.js",
					"common/forms.js",
					"jquery.ba-postmessage.js",
					"parentFrameLogin.js",
					"UpsellAdModal.js"
			);
			_scripts.DeclareBundle(
				"simple",
					"jquery.simplemodal-1.3.5.js",
					"jquery.tipsy.js",
					"GoogleAnalytics/GoogleAnalyticsEvents.js",
					"json2.js",
					"jquery.cookie.js",
					"jquery.jsoncookie.js",
					"DropDownNav.js",
					"JSErrorTracker.js",
					"RobloxEventManager.js",
					"RobloxEventListener.js",
					"GoogleEventListener.js",
					"MongoEventListener.js",
					"SiteTouchEvent.js",
					"GenericConfirmation.js",
					"UpsellAdModal.js"
			);
			_scripts.DeclareBundle(
				"simple-mvc",
					"RobloxEventManager.js",
					"jquery.simplemodal-1.3.5.js",
					"jquery.cookies.2.2.0.1.js",
					"jquery.cookie.js",
					"jquery.jsoncookie.js",
					"jquery.json-2.2.js",
					"parentFrameLogin.js",
					"RobloxEventListener.js",
					"GoogleEventListener.js",
					"MongoEventListener.js",
					"SiteTouchEvent.js",
					"JSErrorTracker.js"
			);
			_scripts.DeclareBundle(
				"videopreroll",
					"VideoPreRoll.js"
			);
			_scripts.DeclareBundle(
				"clientinstaller",
					"EventTracker.js",
					"ClientInstaller.js",
					"InstallationInstructions.js",
					"IEMetroInstructions.js"
			);
			_scripts.DeclareBundle(
				"placelauncher",
					"CharacterSelect.js",
					"MadStatus.js",
					"PlaceLauncher.js",
					"ABPlaceLauncher.js"
			);
			_scripts.DeclareBundle(
				"non	LoggedIn",
					"jquery.ba-postmessage.js",
					"parentFrameLogin.js"
			);
			_scripts.DeclareBundle(
				"chat",
					"jquery.cookies.2.2.0.1.js",
					"chat.js",
					"jquery-extensions.js",
					"party.js"
			);
			_scripts.DeclareBundle(
				"threeDeeThumbnailScripts",
					"3D/three.js",
					"3D/MTLLoader.js",
					"3D/OBJMTLLoader.js",
					"3D/tween.js",
					"3D/RobloxOrbitControls.js"
			);
			_scripts.DeclareBundle(
				"jQuery",
					"modules/jQuery.js"
			);
			_scripts.DeclareBundle(
				 "iframelogin",
					"jquery.ba-postmessage.js",
					"iFrameLogin.js"
			);

            _styles.DeclareBundle(
				"main",
					"Base/CSS/Roblox.css",
					"RBXCommon.css",
					"Base/CSS/AdFormatClasses.css",
					"Base/CSS/Ads.css",
					"Base/CSS/AgeUpEmailVerifyPage.css",
					"Base/CSS/Asset.css",
					"Base/CSS/Badges.css",
					"Base/CSS/BCModal.css",
					"Base/CSS/Billing.css",
					"Base/CSS/carouselpager.css",
					"Base/CSS/Catalog.css",
					"Base/CSS/CharacterCustomization.css",
					"Base/CSS/CharacterSelectAndInstallInstructions.css",
					"Base/CSS/CommonForms.css",
					"Base/CSS/ContentAdapters.css",
					"Base/CSS/ContentBuilder.css",
					"Base/CSS/Contest.css",
					"Base/CSS/CreditCardExpireModal.css",
					"Base/CSS/CuratedGames.css",
					"Base/CSS/CurrencyExchange.css",
					"Base/CSS/Flyouts.css",
					"Base/CSS/Footer.css",
					"Base/CSS/Games.css",
					"Base/CSS/GenericModal.css",
					"Base/CSS/GroupRoleSetMembersPane.css",
					"Base/CSS/Groups.css",
					"Base/CSS/Header.css",
					"Base/CSS/Help.css",
					"Base/CSS/IframeHeader.css",
					"Base/CSS/iFrameLogin.css",
					"Base/CSS/Install.css",
					"Base/CSS/Item.css",
					"Base/CSS/jquery.mCustomScrollbar.css",
					"Base/CSS/LandingGames.css",
					"Base/CSS/Language.css",
					"Base/CSS/LoadingSpinner.css",
					"Base/CSS/ManageAccount.css",
					"Base/CSS/MediaThumb.css",
					"Base/CSS/Membership.css",
					"Base/CSS/MenuRedesign.css",
					"Base/CSS/Message.css",
					"Base/CSS/Modals.css",
					"Base/CSS/MyAccount.css",
					"Base/CSS/MyItem.css",
					"Base/CSS/MyMoney.css",
					"Base/CSS/NewToolBox.css",
					"Base/CSS/Parents.css",
					"Base/CSS/party.css",
					"Base/CSS/PersonalServerAccessPrivilegesRoleSet.css",
					"Base/CSS/Place.css",
					"Base/CSS/PlaceItem.css",
					"Base/CSS/PlaceLauncher.css",
					"Base/CSS/Profile.css",
					"Base/CSS/RevisedCharacterSelectModal.css",
					"Base/CSS/Sets.css",
					"Base/CSS/ShadowedStandardBox.css",
					"Base/CSS/ShareRoblox.css",
					"Base/CSS/Signup.css",
					"Base/CSS/tipsy.css",
					"Base/CSS/Thumbnail.css",
					"Base/CSS/tipsy.css",
					"Base/CSS/Toolbox.css",
					"Base/CSS/Trade.css",
					"Base/CSS/UnifiedModal.css",
					"Base/CSS/Upgrades.css",
					"Base/CSS/Upload.css",
					"Base/CSS/User.css",
					"Base/CSS/Utility.css",
					"Base/CSS/VideoPreRoll.css",
					"Base/CSS/StyleGuide.css",
					"RBX2/CSS/DarkGradientBox.css",
					"RBX2/CSS/Item.css",
					"RBX2/CSS/Roblox.css",
					"RBX2/CSS/Utility.css"
			);

            _styles.DeclareBundle(
				"reset",
					"YUIReset.css"
			);
		}
	}
}
