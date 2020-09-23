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

        public PostgresDataService(AppDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddProjectAsync(Project project)
        {
            context.Projects.Add(project);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Project project)
        {
            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            context.Projects.Update(project);
            await context.SaveChangesAsync();
        }
    }
}
