﻿using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Portfolio.Blazor.DataProvider
{
    public class PublicAPIService
    {
        private readonly HttpClient client;

        public PublicAPIService(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));           

        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            Console.WriteLine("\tCurrently getting projects async");
            var projects = await client.GetFromJsonAsync<IEnumerable<Project>>("api/project");

            return projects;
        }

        public async Task<Project> GetProjectByIDAsync(int id)
        {
            var projects = await GetProjectsAsync();

            var project = projects.Where(proj => proj.id == id).First();
            Console.WriteLine("Project found was " + project.Title + " with id of " + project.id);
            return project;
        }

        public async Task<Project> GetProjectBySlugAsync(string slug)
        {
            var projects = await GetProjectsAsync();

            var project = projects.Where(proj => proj.Slug == slug).First();
            Console.WriteLine("Project found was " + project.Title + " with slug of " + project.Slug);
            return project;
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
            var languages = await GetLanguagesAsync();

            var language = languages.Where(l => l.Id == id).First();
            Console.WriteLine("Language found was " + language.Name);
            return language;
        }

        public async Task<Language> GetLanguageBySlugAsync(string slug)
        {
            var languages = await GetLanguagesAsync();

            var language = languages.Where(l => l.Slug == slug).First();

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
            var platforms = await GetPlatformsAsync();

            var platform = platforms.Where(p => p.Id == id).First();
            Console.WriteLine("Platform found was " + platform.Name);
            return platform;
        }
        public async Task<Platform> GetPlatformsBySlugAsync(string slug)
        {
            var platforms = await GetPlatformsAsync();

            var platform = platforms.Where(p => p.Slug == slug).First();

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
        public async Task<Technology> GetTechnologiesByIdAsync(int id)
        {
            var technologies = await GetTechnologiesAsync();

            var technology = technologies.Where(p => p.Id == id).First();
            Console.WriteLine("Technology found was " + technology.Name);
            return technology;
        }
        public async Task<Technology> GetTechnologiesBySlugAsync(string slug)
        {
            var technologies = await GetTechnologiesAsync();

            var technology = technologies.Where(p => p.Slug == slug).First();
            Console.WriteLine("Technology found was " + technology.Name);
            return technology;
        }

        public async Task<IEnumerable<Project>> GetProjectsByTechnologyId(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/technology/getprojects/" + id);
        }
    }
}
