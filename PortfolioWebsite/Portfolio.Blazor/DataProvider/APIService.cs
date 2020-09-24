using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Portfolio.Blazor.DataProvider
{
    public class APIService
    {
        private readonly HttpClient client;

        public APIService(HttpClient client)
        {
            Console.WriteLine("\t" + client.BaseAddress);
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            Console.WriteLine("\t" + this.client.BaseAddress);

        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            Console.WriteLine("\tCurrently getting projects async");
            var projects = await client.GetFromJsonAsync<IEnumerable<Project>>("api/project");

            return projects;
        }

        public async Task AddProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("api/project", project);
        }

        public async Task<Project> GetProjectByIDAsync(int id)
        {
            var projects = await client.GetFromJsonAsync<IEnumerable<Project>>("api/project");

            var project = projects.Where(proj => proj.id == id).First();
            Console.WriteLine("Project found waas " + project.Title);
            return project;
        }

        public async Task DeleteProjectAsync(int id)
        {
            Console.WriteLine("\tCurrently deleting project " + id);
            await client.DeleteAsync($"api/project/{id}");
        }

        public async Task UpdateProjectAsync(int id)
        {
            Console.WriteLine("\tCurrently updating project " + id);            
        }
    }
}
