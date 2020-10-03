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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectLanguage>().HasKey(pl => new { pl.ProjectId, pl.LanguageId });

            modelBuilder.Entity<ProjectLanguage>()
                .HasOne<Project>(p => p.Project)
                .WithMany(l => l.ProjectLanguages)
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<ProjectLanguage>()
                .HasOne<Language>(l => l.Language)
                .WithMany(p => p.ProjectLanguages)
                .HasForeignKey(l => l.LanguageId);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        public DbSet<ProjectLanguage> ProjectLanguages { get; set; }
        public DbSet<ProjectPlatform> ProjectPlatforms { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }


    }
}
