using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using System.Reflection;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using ZombieSurvivalSocialNetwork.Infrastructure.Contexts;
using ZombieSurvivalSocialNetwork.Core.Application.Interfaces;
using ZombieSurvivalSocialNetwork.Infrastructure.Repository;
using ZombieSurvivalSocialNetwork.Infrastructure.Repositories;
using SHOPRURETAIL.Application.Interfaces.Repositories;

namespace ZombieSurvivalSocialNetwork.Core.Application.Extensions
{
    public static class ServiceExtensions
    {

        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region ApplicationConnection

            services.AddDbContext<ZombieDbContext>(options =>
                     options.UseSqlite(
                         configuration.GetConnectionString("SQLITE"),
                         b => b.MigrationsAssembly(typeof(ZombieDbContext).Assembly.FullName)));

            #endregion

            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IReportRepositoryAsync, ReportRepositoryAsync>();
            
        }
        public static void AddSwaggerExtension(this IServiceCollection services)
        {


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SURVIVOR - API",
                    Description = "This Api will be responsible for survivor.",
                    Contact = new OpenApiContact
                    {
                        Name = "Olamide",
                        Email = "olamideonakoya@gmail.com"
                    }
                });
               
            });
        }
   

        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

        

    }
}
