
using Breadfast.APIs.Errors;
using Breadfast.APIs.Extensions;
using Breadfast.APIs.Helper;
using Breadfast.APIs.Middlewares;
using Breadfast.Domain.Entities;
using Breadfast.Domain.Entities.Products;
using Breadfast.Domain.Interfaces;
using Breadfast.Infrastructure.Persistence.Data.Database;
using Breadfast.Infrastructure.Persistence.Data.Repositories;
using Breadfast.Infrastructure.Persistence.Data.Seeding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Breadfast.APIs
{
    public class Program
    {
        public static async Task Main()
        {
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped(typeof(IGenericRepositry<>), typeof(GenericRepository<>));
            // builder.Services.AddScoped(typeof(ISpecification<>),typeof(BaseSpecification<>));
            //builder.Services.AddScoped<IGenericRepositry<Product>,GenericRepository<Product>>();
            builder.Services.AddDbContext<BreadfastDbContext>(async options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("BreadfastDataBaseConnection"));
                options.UseLazyLoadingProxies(false);

            });

            // builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


            // builder.Services.Configure<ApiBehaviorOptions>(options =>
            // {
            //     options.InvalidModelStateResponseFactory = actionContext =>
            //     {
            //         actionContext.ModelState.Where(P => P.Value.Errors.Count()>0)
            //                                 .SelectMany
            //     }
            // 
            // });
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {

                options.InvalidModelStateResponseFactory = actionContext =>
                {
                   var errors = actionContext.ModelState.Where(P => P.Value!.Errors.Count() > 0)
                                            .SelectMany(P => P.Value!.Errors)
                                            .Select(E => E.ErrorMessage)
                                            .ToList();

                    var errorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };


                    return  new BadRequestObjectResult(errorResponse);

                };

            });


            var app = builder.Build();


            app.UseMiddleware<ExceptionMiddleware>();   
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                      app.UseSwagger();
                      app.UseSwaggerUI();
               await  app.ApplyMigrations();
                
               
            }
            app.UseStatusCodePagesWithReExecute("/errors/{0}"); // Middelware Handing NOTFoundEndPointErrors

            app.UseHttpsRedirection();
            app.UseStaticFiles();   
            app.UseAuthorization();


    
            app.MapControllers();

            app.Run();
        }
    }
}
