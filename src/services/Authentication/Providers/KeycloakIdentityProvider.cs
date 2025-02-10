using Microsoft.AspNetCore.WebUtilities;

namespace Authentication.Providers;

public class KeycloakIdentityProvider : IIdentityProvider
{
    public KeycloakIdentityProvider(IConfiguration configuration)
    {
        var keycloakSection = configuration.GetSection("Keycloak");

        LoginEndpoint = keycloakSection["LoginEndpoint"]!;
        TokenEndpoint = keycloakSection["TokenEndpoint"]!;
        ClientId = keycloakSection["ClientId"]!;
        RedirectUri = keycloakSection["RedirectUri"]!;
    }

    public string LoginEndpoint { get; private set; }

    public string TokenEndpoint { get; private set; }

    public string ClientId { get; private set; }

    public string RedirectUri { get; private set; }

    public Result<string> ExchangeToken(string authCode)
    {
        Guard.Against.Null(authCode);

        return Result.Success(string.Empty);
    }

    public string GetRedirectLoginEndpoint()
    {
        var queryParams = new Dictionary<string, string?>()
        {
          { "client_id", ClientId },
          { "redirect_uri", RedirectUri },
          { "response_type", "code" },
          { "scope", "openid" }
        };

        return QueryHelpers.AddQueryString(LoginEndpoint, queryParams);
    }
}

