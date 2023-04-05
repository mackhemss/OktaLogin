using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using OktaLogin.Models;
using IdentityModel.Client;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;

namespace OktaLogin
{
    public partial class Startup
    {
        // These values are stored in Web.config. Make sure you update them!
        private readonly string _clientId = ConfigurationManager.AppSettings["okta:ClientId"];

        private readonly string _redirectUri = ConfigurationManager.AppSettings["okta:RedirectUri"];
        private readonly string _authority = ConfigurationManager.AppSettings["okta:OrgUri"];
        private readonly string _clientSecret = ConfigurationManager.AppSettings["okta:ClientSecret"];
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301883
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());


            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ProtocolValidator = new CustomOpenIdConnectProtocolValidator(false),
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                Authority = _authority,
                RedirectUri = _redirectUri,
                ResponseType = OpenIdConnectResponseType.CodeIdToken,
                Scope = OpenIdConnectScope.OpenIdProfile,
                TokenValidationParameters = new TokenValidationParameters { NameClaimType = "name" },

          //      Notifications = new OpenIdConnectAuthenticationNotifications
          //      {
          //          AuthorizationCodeReceived = async n =>
          //          {

          //              // Exchange code for access and ID tokens
          //              var tokenClient = new TokenClient("https://lakeshore-admin.oktapreview.com/v1/token", "0oa7byyhtwWiHxRTh1d7", _clientSecret);

          //              var tokenResponse = await tokenClient.RequestAuthorizationCodeAsync(n.Code, _redirectUri);

          //              if (tokenResponse.IsError)
          //              {
          //                  throw new Exception(tokenResponse.Error);
          //              }

          //              var userInfoClient = new UserInfoClient("https://lakeshore-admin.oktapreview.com/v1/userinfo");
          //              var userInfoResponse = await userInfoClient.GetAsync(tokenResponse.AccessToken);

          //              var claims = new List<Claim>(userInfoResponse.Claims)
          //{
          //        new Claim("id_token", tokenResponse.IdentityToken),
          //        new Claim("access_token", tokenResponse.AccessToken)
          //};

          //              n.AuthenticationTicket.Identity.AddClaims(claims);

          //          },
          //      },
            });
        }

        public class CustomOpenIdConnectProtocolValidator : OpenIdConnectProtocolValidator
        {
            public CustomOpenIdConnectProtocolValidator(bool shouldValidateNonce)
            {
                this.ShouldValidateNonce = shouldValidateNonce;



            }
            protected override void ValidateNonce(OpenIdConnectProtocolValidationContext validationContext)
            {
                if (this.ShouldValidateNonce)
                {
                    base.ValidateNonce(validationContext);
                }
            }

            protected override void ValidateState(OpenIdConnectProtocolValidationContext validationContext)
            {
                if (this.ShouldValidateNonce)
                {
                    base.ValidateState(validationContext);
                }
            }

            private bool ShouldValidateNonce { get; set; }
        }
    }
}
