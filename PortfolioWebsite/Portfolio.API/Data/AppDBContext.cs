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
        public DbSet<Language> Languages{ get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        public DbSet<ProjectLanguage> ProjectCategories { get; set; }
    }
}
