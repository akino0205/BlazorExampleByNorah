using BlazorExampleByNorah.Data;
using BlazorExampleByNorah.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorExampleByNorah.Services
{
    public class AuthenticationService
    {
        public AppSettings _appSettings { get; }
        public AuthenticationSettings _authenticationSettings { get; set; }
        public HttpClient _httpClient { get; }

        public AuthenticationService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_appSettings.AuthenticationAPIAddress);
        }

        public async Task<TokenSet> LoginAndGetTokenSet(WisdomainLoginForm Input)
        {
            var response = await _httpClient.PostAsJsonAsync("/login", Input);
            TokenSet token = null;
            if (response.IsSuccessStatusCode)
            {
                token = await response.Content.ReadFromJsonAsync<TokenSet>();
                //await HttpContext.SignInAsync(_authenticationSettings.AuthenticationScheme, token.GenerateIdentity(
                //    _authenticationSettings.AuthenticationScheme, _authenticationSettings.AccessTokenCookie,
                //    _authenticationSettings.RefreshTokenCookie, HttpContext));
            }
            return token;
        }
    }
}
