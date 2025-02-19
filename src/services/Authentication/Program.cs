using Authentication.Features;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.Authority = config["Keycloak:Authority"];
        options.ClientId = config["Keycloak:ClientId"];
        options.ClientSecret = config["Keycloak:ClientSecret"]; // Only needed for confidential clients
        options.ResponseType = OpenIdConnectResponseType.Code; // Authorization Code Flow
        options.UsePkce = true; // Enables PKCE automatically
        options.SaveTokens = true; // Stores tokens in session cookies
        options.CallbackPath = Constants.CallbackRoute; // Redirect URI after login
        options.SignedOutCallbackPath = "/logout-callback"; // Redirect after logout
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");
        options.RequireHttpsMetadata = false;
        options.GetClaimsFromUserInfoEndpoint = true; // Fetch additional user info
    });

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseLogin();

app.MapGet("/secure", () => "This is a protected route").RequireAuthorization();

app.Run();
