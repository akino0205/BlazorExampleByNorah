namespace BlazorExampleByNorah.Data
{
    public class AuthenticationSettings
    {
        public string AuthenticationScheme { get; set; }
        public string AuthorizationAPIUri { get; set; }
        public string AccessTokenCookie { get; set; }
        public string RefreshTokenCookie { get; set; }
        public string ClaimEncryptKey { get; set; }
        public bool SlidingExpiration { get; set; }
        public int ExpirationHours { get; set; }
    }
}
