using Microsoft.EntityFrameworkCore;
using Portfolio.Shared;
using Portfolio.Shared.Slug;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public class PostgresDataService : IDataService
    {
        private readonly AppDBContext context;

        public IQueryable<Project> Projects => context.Projects;
        public IQueryable<Language> Languages => context.Languages;
        public IQueryable<Platform> Platforms => context.Platforms;
        public IQueryable<Technology> Technologies => context.Technologies;

        public IQueryable<ProjectLanguage> ProjectLanguages => context.ProjectLanguages;
        public IQueryable<ProjectPlatform> ProjectPlatforms => context.ProjectPlatforms;
        public IQueryable<ProjectTechnology> ProjectTechnologies => context.ProjectTechnologies;


        public PostgresDataService(AppDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //Project table interactions
        public async Task AddProjectAsync(Project project)
        {
            context.Projects.Add(project);

            Console.WriteLine("Added project " + project.Title + "with id " + project.id);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Project project)
        {
            context.Projects.Remove(project);

            Console.WriteLine("Deleted project " + project.Title);
            await context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            Console.WriteLine("About to update project");

            context.Projects.Update(project);

            Console.WriteLine("Updated project " + project.Title);
            await context.SaveChangesAsync();
        }

        //Language table interactions
        public async Task AddLanguageAsync(Language language)
        {
            context.Languages.Add(language);

            Console.WriteLine("Added language " + language.Name + "with id " + language.Id);
            await context.SaveChangesAsync();
        }

        public async Task DeleteLanguageAsync(Language language)
        {
            context.Languages.Remove(language);

            Console.WriteLine("Deleted language " + language.Name);
            await context.SaveChangesAsync();
        }

        public async Task UpdateLanguageAsync(Language language)
        {
            context.Languages.Update(language);

            Console.WriteLine("Updated language " + language.Name);
            await context.SaveChangesAsync();
        }

        public async Task AssignCategoryAsync(AssignRequest assignRequest)
        {
            switch (assignRequest.CategoryType)
            {
                case Project.LanguageCategory:
                    var language = await context.Languages.FirstOrDefaultAsync(l => l.Name == assignRequest.Name);

                    if (language == null)
                    {
                        language = new Language
                        {
                            Name = assignRequest.Name,
                            Slug = assignRequest.Name.ToSlug()
                        };

                        context.Languages.Add(language);
                        await context.SaveChangesAsync();
                    }

                    var lc = new ProjectLanguage
                    {
                        ProjectId = assignRequest.ProjectId,
                        LanguageId = language.Id
                    };

                    context.ProjectLanguages.Add(lc);
                    await context.SaveChangesAsync();
                    break;

                case Project.PlatformCategory:
                    var platform = await context.Platforms.FirstOrDefaultAsync(p => p.Name == assignRequest.Name);

                    if (platform == null)
                    {
                        platform = new Platform
                        {
                            Name = assignRequest.Name,
                            Slug = assignRequest.Name.ToSlug()
                        };

                        context.Platforms.Add(platform);
                        await context.SaveChangesAsync();
                    }

                    var projectPlatform = new ProjectPlatform
                    {
                        ProjectId = assignRequest.ProjectId,
                        PlatformId = platform.Id
                    };

                    context.ProjectPlatforms.Add(projectPlatform);
                    await context.SaveChangesAsync();
                    break;

                case Project.TechnologyCategory:
                    var technology = await context.Technologies.FirstOrDefaultAsync(t => t.Name == assignRequest.Name);

                    if (technology == null)
                    {
                        technology = new Technology 
                        {
                            Name = assignRequest.Name,
                            Slug = assignRequest.Name.ToSlug()
                        };
                        context.Technologies.Add(technology);
                        await context.SaveChangesAsync();
                    }

                    var projectTechnology = new ProjectTechnology
                    {
                        ProjectId = assignRequest.ProjectId,
                        TechnologyId = technology.Id
                    };

                    context.ProjectTechnologies.Add(projectTechnology);
                    await context.SaveChangesAsync();
                    break;

                default:
                    break;
            }
        }
    }
}
