using Microsoft.AspNetCore.Components;
using Portfolio.Blazor.DataProvider;
using Portfolio.Blazor.Pages;
using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Portfolio.Blazor.CodeBase
{
    public class ProjectsBase : ComponentBase
    {
        //private APIService service;
        public bool isAddComponentDisplayed = false;

        public ProjectsBase()
        {
            Projects = new List<Project>();
        }

        //protected override Task OnInitializedAsync()
        //{
        //    this.service = service;
        //    return base.OnInitializedAsync();
        //}

        //public ProjectsBase()
        //{
        //    this.service = service ?? throw new ArgumentNullException(nameof(service));
        //}
        
        public string PageTitle { get; set; }

        public IEnumerable<Project> Projects { get; private set; }

        public void EditProject(int id, APIService service)
        { 
        }

        public async Task DeleteProject(int id, APIService service)
        {
            await service.DeleteProjectAsync(id);
        }

        public void ShowAddComponent()
        {
            if(isAddComponentDisplayed is false)
            {
                isAddComponentDisplayed = true;
            }
            else
            {
                isAddComponentDisplayed = false;
            }
        }        
    }
}
