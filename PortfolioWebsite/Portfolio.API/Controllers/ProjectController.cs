using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProjectController : ControllerBase
    {
        private readonly IDataService data;

        public ProjectController(IDataService data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<IEnumerable<Project>> Get()
        {
            var projects =  await data.Projects                
                .ToListAsync();

            Console.WriteLine(projects);
            return projects;
        }

        // GET api/<ProjectController>/5
        //[HttpGet("{id}")]
        //public async Task<IEnumerable<Project>> Get(int id)
        //{
        //    IEnumerable<Project> projects = data.Projects.Where(project => project.id == id);

        //    return projects;
        //}

        // POST api/<ProjectController>
        [HttpPost]
        public async Task Post([FromBody] Project project)
        {
            await data.AddProjectAsync(project);
        }

        // PUT api/<ProjectController>/5
        //[HttpPut("{id}")]
        //public async Task Put(int id, [FromBody] string value)
        //{
        //    //var project = value
        //    //data.UpdateProjectAsync(project);
        //    Console.WriteLine("Updating project " + id + " " + value);
        //}

        [HttpPost("[action]")]
        public async Task Update(Project project)
        {
            await data.UpdateProjectAsync(project);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var projectToDelete = data.Projects.Where(project => project.id == id).FirstOrDefault();

            Console.WriteLine("Project to delete is " + projectToDelete.Title);

            await data.DeleteProjectAsync(projectToDelete);
        }

        [HttpPost("[action]")]
        public async Task Assign(AssignRequest assignRequest)
        {
            await data.AssignCategoryAsync(assignRequest);
        }

        [Authorize]
        [HttpGet("getlanguages/{id}")]
        public async Task<IEnumerable<Language>> GetLanguagesByProjectId(int id)
        {            
            return await data.ProjectLanguages.Where(pl => pl.ProjectId == id).Select(l => l.Language).ToListAsync();            
        }

        [HttpGet("getplatforms/{id}")]
        public async Task<IEnumerable<Platform>> GetPlatformsByProjectId(int id)
        {            
            return await data.ProjectPlatforms.Where(pp => pp.ProjectId == id).Select(p => p.Platform).ToListAsync();
        }

        [HttpGet("gettechnologies/{id}")]
        public async Task<IEnumerable<Technology>> GetTechnologiesByProjectId(int id)
        {
            return await data.ProjectTechnologies.Where(pt => pt.ProjectId == id).Select(t => t.Technology).ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task DefaultData()
        {
            await data.AddProjectAsync(new Project
            {
                id = 1,
                Title = "Project 1",
                Requirement = "Post this to the database",
                Design = "We are using Blazor",
                CompletionDate = DateTime.Now
            });


            await data.AddProjectAsync(new Project
            {
                id = 2,
                Title = "Project 2",
                Requirement = "This is the second entry",
                Design = "We are still using Blazor",
                CompletionDate = DateTime.Now
            });
        }
    }
}
