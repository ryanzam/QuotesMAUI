using IdentityModel.Client;
using IdentityModel.OidcClient.Browser;

namespace QuotesMAUI.Auth
{
    public class WebBrowserAuthenticator : IdentityModel.OidcClient.Browser.IBrowser
    {
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            try
            {
                WebAuthenticatorResult authenticatorResult = await WebAuthenticator.Default.AuthenticateAsync(
                    new Uri(options.StartUrl), new Uri(options.EndUrl));

                var url = new RequestUrl(options.EndUrl).Create(new Parameters(authenticatorResult.Properties));

                return new BrowserResult { Response = url, ResultType = BrowserResultType.Success };
            }
            catch (TaskCanceledException)
            {
                return new BrowserResult { ResultType = BrowserResultType.UserCancel, ErrorDescription = "Login cancelled by the user." };
            }
        }
    }
}
