﻿using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public interface IDataService
    {
        IQueryable<Project> Projects { get; }  
        IQueryable<Language> Languages { get; }
        IQueryable<Platform> Platforms { get; }
        IQueryable<Technology> Technologies{ get; }


        IQueryable<ProjectLanguage> ProjectLanguages { get; }
        IQueryable<ProjectPlatform> ProjectPlatforms { get; }
        IQueryable<ProjectTechnology> ProjectTechnologies { get; }

        Task AddProjectAsync(Project project);

        Task DeleteProjectAsync(Project project);

        Task UpdateProjectAsync(Project project);

        Task AssignCategoryAsync(AssignRequest assignRequest);

        
    }
}
