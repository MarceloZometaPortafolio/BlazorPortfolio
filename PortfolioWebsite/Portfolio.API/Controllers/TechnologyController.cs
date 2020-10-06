using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly IDataService data;

        public TechnologyController(IDataService data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }

        [HttpGet]
        public async Task<IList<Technology>> Get()
        {
            var technologies = await data.Technologies
                .ToListAsync();

            Console.WriteLine(technologies);
            return technologies;
        }

        [HttpGet("getprojects/{id}")]
        public async Task<IEnumerable<Project>> GetProjectsByTechnologyId(int id)
        {
            return await data.ProjectTechnologies.Where(pt => pt.TechnologyId == id)
                .Select(p => p.Project)
                .ToListAsync();
        }
    }
}
