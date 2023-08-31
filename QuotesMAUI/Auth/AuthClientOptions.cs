namespace QuotesMAUI.Auth
{
    public class AuthClientOptions
    {
        public string Scope { get; set; }
        public string RedirectUri { get; set; }
        public string Domain { get; set; }
        public string ClientId { get; set; }
        public IdentityModel.OidcClient.Browser.IBrowser Browser { get; private set; }

        public AuthClientOptions()
        {
            Scope = "openid";
            RedirectUri = "myapp://callback";
            Browser = new WebBrowserAuthenticator();
        }
    }
}
