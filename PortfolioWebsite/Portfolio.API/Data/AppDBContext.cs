using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Project> Projects { get; set; }

    }
}
