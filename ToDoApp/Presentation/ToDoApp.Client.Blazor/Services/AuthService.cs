﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AuthenticationWithClientSideBlazor.Client;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using ToDoApp.Client.Blazor.ViewModels;

namespace ToDoApp.Client.Blazor.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly ILocalStorageService localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.authenticationStateProvider = authenticationStateProvider;
            this.localStorage = localStorage;
        }

        public async Task Register(RegisterModel registerModel)
        {
            await httpClient.PostJsonAsync("api/account/register", new { email = registerModel.Email, password = registerModel.Password });
        }

        // PostJsonAsync throws an error when reading string result - this is why I switched to PostAsync
        public async Task<string> Login(LoginModel loginModel)
        {
            var token = await httpClient.PostJsonAsync<string>("api/account/login", new { username = loginModel.Email, password = loginModel.Password });
            if (string.IsNullOrEmpty(token))
            {
                return token;
            }

            await localStorage.SetItemAsync("authToken", token);
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return token;
        }

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();
            httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}