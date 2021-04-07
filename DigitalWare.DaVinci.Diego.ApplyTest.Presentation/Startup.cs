namespace DigitalWare.DaVinci.Diego.ApplyTest.Presentation
{
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Filters;
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Services;
    using DigitalWare.DaVinci.Diego.ApplyTest.BL.Services.Facades;
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.DTOs.Responses;
    using DigitalWare.DaVinci.Diego.ApplyTest.DAL.EFDatabaseContext;
    using DigitalWare.DaVinci.Diego.ApplyTest.DAL.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;

    /// <summary>
    /// Startup Class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services. This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());

            ////Set data access connections
            services.AddDbContext<DigitalWareDavinCiInvoiceSystemContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DaVinciInvoiceSystem")));
            ////Repositories
            services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
            ////BL Services
            services.AddScoped<IProductServiceBL, ProductServiceBL>();

            ////Model State Result (For API Controller)
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var apiReponse = new WebApiResponseDTO<IEnumerable<string>>()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                        IsSuccess = false,
                        Message = "Verifique los datos ingresados",
                        ObjResult = context.ModelState.Values.SelectMany(v => v.Errors)?.Select(x => x.ErrorMessage)
                    };

                    return new BadRequestObjectResult(apiReponse);
                };
            });

            ////Configure swagger doc
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DigitalWare DaVinci Diego Apply Test", Version = "v1", Description = "DaVinci Invoice System" });
                c.AddEnumsWithValuesFixFilters();
            });
        }

        /// <summary>
        /// Configures the specified application. This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(o => o.SerializeAsV2 = true);
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DigitalWare DaVinci Diego ApplyTest Presentation v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}