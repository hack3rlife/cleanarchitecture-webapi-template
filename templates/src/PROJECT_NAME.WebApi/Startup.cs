using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using PROJECT_NAME.Application;
using PROJECT_NAME.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace PROJECT_NAME.WebApi
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
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Clean Architecture Template for ASP .NET Core WebApi Projects",
                        Description = "A simple ASP .NET Core Web API project for Development and Testing Training",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "hack3rlife",
                            Email = "admin@hack3rlife.com"
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Microsoft Public License (MS-PL)",
                            Url = new Uri("https://opensource.org/licenses/MS-PL")
                        }

                    });

                //Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Registering Application Layer Dependencies
            services.AddApplicationServices(Configuration);

            //Registering Infrastructure Layer Dependencies
            services.AddInfrastructureServices(Configuration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture Template V1");
                c.RoutePrefix = string.Empty;
                c.ConfigObject.SupportedSubmitMethods = new List<SubmitMethod>()
                {
                    SubmitMethod.Delete,
                    SubmitMethod.Get,
                    SubmitMethod.Patch,
                    SubmitMethod.Post,
                    SubmitMethod.Put
                };
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
