using Authentication.Providers;
using Authentication.Features;

public static class Extensions
{
    public static void AddKeycloak(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IIdentityProvider, KeycloakIdentityProvider>();
    }

    public static void AddFeatures(this WebApplication app)
    {
        app.UseLogin();
    }
}
