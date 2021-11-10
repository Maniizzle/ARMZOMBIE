using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Middlewares;

namespace ZombieSurvivalSocialNetwork.Core.Application.Extensions
{
    public static class AppExtensions
    {
      
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
        public static void UseCustomSwaggerApi(this IApplicationBuilder app, string name = "ZOMBIE API")
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger - ui assets(HTML, JS, CSS etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", name);
                c.DocExpansion(DocExpansion.None);
            });
        }

    }
}
