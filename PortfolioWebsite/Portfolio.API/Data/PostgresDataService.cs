using Microsoft.EntityFrameworkCore;
using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public class PostgresDataService : IDataService
    {
        private readonly AppDBContext context;

        public IQueryable<Project> Projects => context.Projects;
        public IQueryable<Language> Languages => context.Languages;
        public IQueryable<ProjectLanguage> ProjectLanguages => context.ProjectLanguages;

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
                        language = new Language { Name = assignRequest.Name };
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
                default:
                    break;
            }
        }
    }
}
