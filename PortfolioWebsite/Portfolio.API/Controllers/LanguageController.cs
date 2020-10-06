using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IDataService data;

        public LanguageController(IDataService data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
        
        [HttpGet]
        public async Task<IList<Language>> Get()
        {
            var languages = await data.Languages
                .ToListAsync();

            Console.WriteLine(languages);
            return languages;
        }

        [HttpGet("getprojects/{id}")]
        public async Task<IEnumerable<Project>> GetLanguagesByProjectId(int id)
        {
            return await data.ProjectLanguages.Where(pl => pl.LanguageId == id).Select(p => p.Project).ToListAsync();
        }
    }
}
