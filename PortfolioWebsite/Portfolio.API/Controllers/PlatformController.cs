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
    public class PlatformController : ControllerBase
    {
        private readonly IDataService data;

        public PlatformController(IDataService data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }

        [HttpGet]
        public async Task<IList<Platform>> Get()
        {
            var platforms = await data.Platforms
                .ToListAsync();

            Console.WriteLine(platforms);
            return platforms;
        }

        [HttpGet("getprojects/{id}")]
        public async Task<IEnumerable<Project>> GetProjectsByPlatformId(int id)
        {
            return await data.ProjectPlatforms.Where(pp => pp.PlatformId == id)
                .Select(p => p.Project)
                .ToListAsync();
        }
    }
}
