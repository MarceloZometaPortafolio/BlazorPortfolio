using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
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

            Console.WriteLine("\tAbout to call API to assign tag");
            await client.PostAsJsonAsync($"api/project/assign/", assignBody);
        }

        public async Task<IEnumerable<Language>> GetLanguagesByProjectId(int projectId)
        {
            return await client.GetFromJsonAsync<IEnumerable<Language>>("api/project/getlanguages/" + projectId);
        }

        public async Task<IEnumerable<Platform>> GetPlatformsByProjectId(int projectId)
        {
            return await client.GetFromJsonAsync<IEnumerable<Platform>>("api/project/getplatforms/" + projectId);
        }

        public async Task<IEnumerable<Technology>> GetTechnologiesByProjectId(int projectId)
        {
            return await client.GetFromJsonAsync<IEnumerable<Technology>>("api/project/gettechnologies/" + projectId);
        }


        public async Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            Console.WriteLine("\tCurrently getting all languages");
            var languages = await client.GetFromJsonAsync<IEnumerable<Language>>("api/language");

            return languages;
        }
        public async Task<Language> GetLanguageByIDAsync(int id)
        {
            var languages = await client.GetFromJsonAsync<IEnumerable<Language>>("api/language");

            var language = languages.Where(l => l.Id == id).First();
            Console.WriteLine("Language found was " + language.Name);
            return language;
        }
        public async Task<IEnumerable<Project>> GetProjectsByLanguageId(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/language/getprojects/" + id);
        }


        public async Task<IEnumerable<Platform>> GetPlatformsAsync()
        {
            Console.WriteLine("\tCurrently getting all platforms");
            var platforms = await client.GetFromJsonAsync<IEnumerable<Platform>>("api/platform");

            return platforms;
        }
        public async Task<Platform> GetPlatformsByIdAsync(int id)
        {
            var platforms = await client.GetFromJsonAsync<IEnumerable<Platform>>("api/platform");

            var platform = platforms.Where(p => p.Id == id).First();
            Console.WriteLine("Platform found was " + platform.Name);
            return platform;
        }
        public async Task<IEnumerable<Project>> GetProjectsByPlatformId(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/platform/getprojects/" + id);
        }


        public async Task<IEnumerable<Technology>> GetTechnologiesAsync()
        {
            Console.WriteLine("\tCurrently getting all technologies");
            var technologies = await client.GetFromJsonAsync<IEnumerable<Technology>>("api/technology");

            return technologies;
        }
        public async Task<Technology> GetTechnologiesById(int id)
        {
            var technologies = await GetTechnologiesAsync();

            var technology = technologies.Where(p => p.Id == id).First();
            Console.WriteLine("Technology found was " + technology.Name);
            return technology;
        }
        public async Task<IEnumerable<Project>> GetProjectsByTechnologyId(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/technology/getprojects/" + id);
        }
    }
}
