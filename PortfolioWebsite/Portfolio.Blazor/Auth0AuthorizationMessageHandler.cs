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
                authorizedUrls: new[] { "http://localhost:5005", "https://portfolio-api-marcelo.herokuapp.com/" }
            );
        }
    }
}