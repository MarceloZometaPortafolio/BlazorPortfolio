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
            Console.WriteLine("Project found was " + project.Title + " with id of " + project.id);
            return project;
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
            await client.PostAsJsonAsync($"api/project/assign/", assignBody);
        }
    }
}
