using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet5App
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dotnet5App", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dotnet5App v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World");
            //    });
            //});

            app.UseAuthorization();
      
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World");
                //});
                endpoints.MapGet("/", async context =>
                {
                    HttpRequest request = context.Request;
                    //request.Query["query"].ToString()
                    request.EnableBuffering();   //<-- add to try to make it work
                    string message = "Unknown";
                    try
                    {
                        var reader = request.BodyReader;
                        await reader.ReadAsync();   //<-- add to try to make it work
                        message = "Content type: " + (request.ContentType == null ? "Null" : request.ContentType) + "<br>" +
                            "Request size: " + (request.ContentLength == null ? "Null" : request.ContentLength.ToString());
                    }
                    catch (Exception e)
                    {
                        message = "Error: " + e.Message;
                    }
                    await context.Response.WriteAsync(page(message));
                });
                endpoints.MapPost("/", async context =>
                {
                    HttpRequest request = context.Request;
                    string message = "Unknown";
                    try
                    {
                        context.Request.EnableBuffering(1048576);
                        
                        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                        await request.Body.ReadAsync(buffer, 0, buffer.Length);
                        string requestBody = Encoding.UTF8.GetString(buffer);
                        if(requestBody != null)
                        {

                            Console.WriteLine("Request Body Is not Null");
                            
                        }


                        var reader = request.BodyReader;

                        if (string.IsNullOrEmpty(reader.ToString()))
                        {
                            Console.WriteLine("Not Empty");
                        }

                        await reader.ReadAsync();   //<-- add to try to make it work
                        message = "Content type: " + (request.ContentType == null ? "Null" : request.ContentType) + "<br>" +
                            "Request size: " + (request.ContentLength == null ? "Null" : request.ContentLength.ToString());
                    }
                    catch (Exception e)
                    {
                        message = "Error: " + e.Message;
                    }
                    var code = context.Response.StatusCode;
                    if (code == 401)
                    {
                     await   context.Response.WriteAsync("No content for 401");
                    }
                    else
                    {
                        await context.Response.WriteAsync(page(message));
                    }
                    
                });
                //endpoints.MapHealthChecks("/hc/ping", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
                //{
                //    Predicate = check => check.Tags.Contains("ping"),
                //    //ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                //});
            });
        }
        public string page(string message)
        {
            return
                @"<html xmlns=""http://www.w3.org/1999/xhtml"">
            <meta httm-equiv='Content-Type' content='text/html; charset=iso-8859-1' />
            <meta http-equiv=""expires"" content=""0"" />
            <title>
            TANCS TEST(PRODUCITON DATA)
            </title >
            <body>
            <form method=""post"">
            Enter a value: <input type=""text"" id="" value"" name=""query"" width=20 value=""xyz"">
            <input id=""Save"" type=""submit"">
            </form>
            " + message + @"
            </body>
            </html>";
        }
    }
}
