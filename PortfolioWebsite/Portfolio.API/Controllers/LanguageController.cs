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
        // GET: api/<LanguageController>
        //[HttpGet("{id}")]
        //public async Task<IEnumerable<Language>> Get(int id)
        //{
           
        //}

        // GET api/<LanguageController>/5
        [HttpGet]
        public async Task<IList<Language>> Get()
        {
            var languages = await data.Languages
                .ToListAsync();

            Console.WriteLine(languages);
            return languages;
        }

        // POST api/<LanguageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }               
    }
}
