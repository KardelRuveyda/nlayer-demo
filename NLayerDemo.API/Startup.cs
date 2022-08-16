using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLayerDemo.API.Filters;
using NLayerDemo.API.MiddleWares;
using NLayerDemo.Core.Repositories;
using NLayerDemo.Core.Services;
using NLayerDemo.Core.UnitOfWorks;
using NLayerDemo.Repository;
using NLayerDemo.Repository.Repositories;
using NLayerDemo.Repository.UnitOfWorks;
using NLayerDemo.Service.Mapping;
using NLayerDemo.Service.Services;
using NLayerDemo.Service.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NLayerDemo.API
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
            //Bu filter bundan sonra eklenen ve varolan tüm controllerlar için geçerli olur. 
            // Sürekli Controllerlarýn baþýna eklemeye gerek kalmaz. 
            services.AddControllers(options =>
            {
                options.Filters.Add(new ValidateFilterAttribute()
                    );
            }).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MemberDtoValidator>());

            // Fluent Validation'un kendi döndüðü filter pasif hale getirilir.
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });



            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "API Swagger",
                    Description = "Api Swagger Documentation",
                    TermsOfService = new Uri("http://swagger.io/terms/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Kardel Rüveyda Çetin"

                    }
                });
            });
            #endregion

            #region Postgre
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
                Configuration.GetConnectionString("PostgreLocalConnection"),
                b => b.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name)
                ));
            services.AddScoped<DbContext>(provider => provider.GetService<AppDbContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddAutoMapper(typeof(MapProfile));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UserCustomException();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Swagger Ýþlemleri
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", " API V1");
                c.RoutePrefix = string.Empty;
            });
            #endregion

            //User Custom Exception

        }
    }
}
