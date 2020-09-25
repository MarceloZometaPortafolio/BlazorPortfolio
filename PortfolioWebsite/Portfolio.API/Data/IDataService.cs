using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public interface IDataService
    {
        IQueryable<Project> Projects { get; }

        Task AddProjectAsync(Project project);

        Task DeleteProjectAsync(Project project);

        Task UpdateProjectAsync(Project project);

    }
}
