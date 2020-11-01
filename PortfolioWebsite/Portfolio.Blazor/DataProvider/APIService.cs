using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Portfolio.Shared;
using RestSharp;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Portfolio.Blazor.DataProvider
{
    public class APIService
    {
        private readonly HttpClient client;
        private readonly IAccessTokenProvider accessToken;

        public APIService(HttpClient client, IAccessTokenProvider accessToken)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken.RequestAccessToken.ToString());

        }

        public async Task AddProjectAsync(Project project)
        {            
            await client.PostAsJsonAsync("api/project", project);
        }

        public async Task DeleteProjectAsync(int id)
        {
            Console.WriteLine("\tCurrently deleting project " + id);
            await client.DeleteAsync($"api/project/{id}");
        }

        public async Task UpdateProjectAsync(Project project)
        {
            Console.WriteLine("\tCurrently updating project " + project.id);
            await client.PostAsJsonAsync("api/project/update", project);
        }

        public async Task AssignTag(string categoryType, int projectId, string newName)
        {
            var assignBody = new AssignRequest
            {
                CategoryType = categoryType,
                Name = newName,
                ProjectId = projectId
            };

            Console.WriteLine("\tAbout to call API to assign tag");
            await client.PostAsJsonAsync($"api/project/assign/", assignBody);
        }        
    }
}
