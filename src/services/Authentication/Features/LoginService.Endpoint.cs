using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Authentication.Features;

public static class LoginEndpoint
{
    public static void UseLogin(this WebApplication app)
    {
        app.MapGet(Constants.LoginRoute, Login);
        app.MapGet(Constants.LogoutRoute, Logout);
        app.MapGet(Constants.CallbackRoute, LoginCallback);
    }

    private static async Task Login(HttpContext httpContext)
    {
        await httpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme);
    }

    private static async Task Logout(HttpContext httpContext)
    {
        await httpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    private static string LoginCallback() => "The callback route!";
}
