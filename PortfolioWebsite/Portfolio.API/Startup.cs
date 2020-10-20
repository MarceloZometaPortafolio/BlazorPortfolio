using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Portfolio.API.Data;

namespace Portfolio.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connectionString = Configuration["DATABASE_URL"];
            services.AddDbContext<AppDBContext>(options => options.UseNpgsql(ConvertUrlConnectionString(Configuration["DATABASE_URL"])));
            services.AddTransient<IDataService, PostgresDataService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Marcelo Zometa Portfolio",
                    Version = "v1"
                });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
        }

        private string ConvertUrlConnectionString(string dbUrl)
        {
            if(dbUrl is null)
            {
                throw new ArgumentNullException(nameof(dbUrl));
            }

            if (!dbUrl.Contains("//"))
            {
                return dbUrl;
            }

            var uri = new Uri(dbUrl);
            var host = uri.Host;
            var port = uri.Port;
            var database = uri.Segments.Last();
            var parts = uri.AbsoluteUri.Split(':', '/', '@');
            var user = parts[3];
            var password = parts[4];

            return $"host={host}; port={port}; database={database}; username={user}; password={password}; SSL Mode=Prefer; Trust Server Certificate=true";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
