namespace Authentication.Features;

using Microsoft.AspNetCore.Http;
using Authentication.Providers;

public class ExchangeTokenFeature(IIdentityProvider identityProvider)
{
    public IResult ExchangeToken(string authCode)
    {
        identityProvider.ExchangeToken(authCode);

        return Results.Ok();
    }
}
