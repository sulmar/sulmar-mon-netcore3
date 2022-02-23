using Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            // Logger
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation($"{context.Request.Method} {context.Request.Path}");

            //    await next();

            //    logger.LogInformation($"{context.Response.StatusCode}");

            //});


            // Authorization
            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Headers.ContainsKey("Authorization"))
            //    {
            //        await next();
            //    }
            //    else
            //    {
            //        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    }
            //});

            // app.UseMiddleware<LoggerMiddleware>();
            // app.UseMiddleware<AuthorizationMiddleware>();

            app.UseLogger();
            app.UseAuth();

            // app.UseLogger();

            // Hello World
            app.Run(context => context.Response.WriteAsync("Hello World!"));
        }
    }
}
