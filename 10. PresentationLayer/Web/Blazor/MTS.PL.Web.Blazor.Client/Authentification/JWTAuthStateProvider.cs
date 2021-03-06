﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Net.Http;
using Newtonsoft.Json;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Infra.Entities.Standard;
using Microsoft.AspNetCore.Components;
using MTS.PL.Web.Blazor.Client.Utils.Extensions;

namespace MTS.PL.Web.Blazor.Client.Authentification
{
    public class JWTAuthStateProvider : AuthenticationStateProvider, ILoginService
    {
        private readonly IJSRuntime _js;
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly string TOKENKEY = "TOKENKEY";
        private readonly NavigationManager _navigationManager;

        private AuthenticationState Anonymous => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public PLUserToken CurrentToken { get; set; }

        public JWTAuthStateProvider(IJSRuntime js, NavigationManager navigationManager, IHttpClientFactory httpClientFactory)
        {
            _js = js;
            _navigationManager = navigationManager;
            _httpClientFactory = httpClientFactory;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _js.GetFromLocalStorage(TOKENKEY);

            if (string.IsNullOrEmpty(token))
            {
                return Anonymous;
            }

            return BuildAuthenticationState(token);
        }

        public async Task Login(string token)
        {
            await _js.SetInLocalStorage(TOKENKEY, token);
            var authenticationState = BuildAuthenticationState(token);
            NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));
        }

        public async Task Logout()
        {
            //_httpClient.DefaultRequestHeaders.Authorization = null;
            await _js.RemoveItem(TOKENKEY);
            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }

        private AuthenticationState BuildAuthenticationState(string token)
        {
            var authState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));

            CurrentToken = JsonConvert.DeserializeObject<PLUserToken>(token);

            if (CurrentToken.Expiration < DateTime.UtcNow)
                return Anonymous;

            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _plUserToken.Value);

            return authState;
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();

            var payload = jwt.Split('.');

            var jsonBytes = ParseBase64WithoutPadding(payload[2]);
            var keyValuePairs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonConvert.DeserializeObject<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }

    }
}
