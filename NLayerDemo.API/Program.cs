using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLayerDemo.Core.Repositories;
using NLayerDemo.Core.Services;
using NLayerDemo.Core.UnitOfWorks;
using NLayerDemo.Repository;
using NLayerDemo.Repository.Repositories;
using NLayerDemo.Repository.UnitOfWorks;
using NLayerDemo.Service.Mapping;
using NLayerDemo.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


var builder = WebApplication.CreateBuilder(args);

//Bu filter bundan sonra eklenen ve varolan tüm controllerlar için geçerli olur. 
// Sürekli Controllerlarýn baþýna eklemeye gerek kalmaz. 
//services.AddControllers(options =>
//{
//    options.Filters.Add(new ValidateFilterAttribute()
//        );
//}).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MemberDtoValidator>());

// Fluent Validation'un kendi döndüðü filter pasif hale getirilir.
//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;
//});



#region Swagger
builder.Services.AddSwaggerGen(c =>
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
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("PostgreLocalConnection"),
    b => b.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name)
    ));
builder.Services.AddScoped<DbContext>(provider => provider.GetService<AppDbContext>());
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
#endregion

builder.Services.AddMvc();

var app = builder.Build();
IWebHostEnvironment env = app.Environment;

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapGet("/auth", () => "This endpoint requires authorization")
   .RequireAuthorization();

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


app.Run();