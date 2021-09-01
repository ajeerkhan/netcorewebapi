using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_demo_1.Filters;

namespace webapi_demo_1
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
            services.AddControllers(options=> 
                options.Filters.Add<ApiErrorFilter>());
            services.AddOpenApiDocument();
            services.AddApiVersioning(options=> {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;

                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);    

             });
            services.AddRouting(options => {
                options.LowercaseUrls = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
                app.UseReDoc();
                //app.UseSwaggerUi3WithApiExplorer(options => options.GeneratorSettings.DefaultPropertyNameHandling = NJsonSchema.PropertyNameHandling.Default);
                //app.UseSwaggerUi3(options => options.GeneratorSettings.DefaultPropertyNameHandling = NJsonSchema.PropertyNameHandling.CamelCase);
                //app.UseSwaggerUi3WithApiExplorer(options => 
                //    options.GeneratorSettings.DefaultPropertyNameHandling = NJsonSchema.PropertyNameHandling.CamelCase);
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
