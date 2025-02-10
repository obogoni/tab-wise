namespace Authentication.Providers;

public interface IIdentityProvider
{
    Result<string> ExchangeToken(string authCode);

    string GetRedirectLoginEndpoint();
}
