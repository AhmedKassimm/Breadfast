
using Breadfast.APIs.Errors;
using Breadfast.APIs.Extensions;
using Breadfast.APIs.Middlewares;
using Breadfast.Application.Services;
using Breadfast.Domain.Entities.User;
using Breadfast.Domain.Interfaces;
using Breadfast.Domain.Interfaces.Service.Interface;
using Breadfast.Infrastructure.Persistence.Data.Database;
using Breadfast.Infrastructure.Persistence.Data.Repositories;
using Breadfast.Infrastructure.Persistence.Identity.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Reflection;
using System.Text;

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

            builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityBreadfastDataBaseConnection"));
            });
            builder.Services.AddIdentity<ApplcationUser, IdentityRole>(op =>
            {
                 op.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            // builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {



                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:authKey"] ?? string.Empty));


                options.TokenValidationParameters = new TokenValidationParameters()
                {

                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:audience"],
                    ValidateLifetime = true,    
                    ClockSkew = TimeSpan.Zero
                };



            });
            builder.Services.AddScoped<IConnectionMultiplexer>((servicsProvider =>
            {
                return ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")!);
            }));
            builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));

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
            app.UseAuthentication();
            app.UseAuthorization();


    
            app.MapControllers();

            app.Run();
        }
    }
}
 