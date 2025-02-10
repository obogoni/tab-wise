using IResult = Microsoft.AspNetCore.Http.IResult;
using Authentication.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Features;

public static class LoginEndpoint
{
    public static void UseLogin(this WebApplication app)
    {
        app.MapGet(Constants.LoginRoute, Login);
    }

    private static IResult Login([FromServices] IIdentityProvider identityProvider)
    {
        var redirectUrl = identityProvider.GetRedirectLoginEndpoint();

        return Results.Redirect(redirectUrl);
    }
}
