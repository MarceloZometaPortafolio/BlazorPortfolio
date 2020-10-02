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
        public IQueryable<Platform> Platforms => context.Platforms;
        public IQueryable<Technology> Technologies => context.Technologies;

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

    }
}
