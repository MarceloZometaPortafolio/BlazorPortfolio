﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Blazor
{
    public class Auth0AuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public Auth0AuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigationManager, IConfiguration config) : base(provider, navigationManager)
        {
            this.ConfigureHandler(
                authorizedUrls: new[] {config["APIBaseAddress"], "https://localhost:5001", "https://localhost:5005", "https://portfolio-api-marcelo.herokuapp.com/", "https://marcelozometaportafolio.github.io/BlazorPortfolio/", "https://dev--qt6q8jb.us.auth0.com" }
            );
        }
    }
}