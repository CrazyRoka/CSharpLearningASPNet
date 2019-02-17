using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebSampleApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                // await context.Response.WriteAsync("Hello World!");

                string[] lines = new[]
                {
                    @"<ul>",
                      @"<li><a href=""/hello.html"">Static Files</a> - requires UseStaticFiles</li>",
                      @"<li>Request and Response",
                        @"<ul>",
                          @"<li><a href=""/RequestAndResponse"">Request and Response</a></li>",
                          @"<li><a href=""/RequestAndResponse/header"">Header</a></li>",
                          @"<li><a href=""/RequestAndResponse/add?x=38&y=4"">Add</a></li>",
                          @"<li><a href=""/RequestAndResponse/content?data=sample"">Content</a></li>",
                          @"<li><a href=""/RequestAndResponse/content?data=<h1>Heading 1</h1>"">HTML Content</a></li>",
                          @"<li><a href=""/RequestAndResponse/content?data=<script>alert('hacker');</script>"">Bad Content</a></li>",
                          @"<li><a href=""/RequestAndResponse/encoded?data=<h1>sample</h1>"">Encoded content</a></li>",
                          @"<li><a href=""/RequestAndResponse/encoded?data=<script>alert('hacker');</script>"">Encoded bad Content</a></li>",
                          @"<li><a href=""/RequestAndResponse/form"">Form</a></li>",
                          @"<li><a href=""/RequestAndResponse/writecookie"">Write cookie</a></li>",
                          @"<li><a href=""/RequestAndResponse/readcookie"">Read cookie</a></li>",
                          @"<li><a href=""/RequestAndResponse/json"">JSON</a></li>",
                        @"</ul>",
                      @"</li>",
                      @"<li><a href=""/Home"">Home Controller with dependency injection</a></li>",
                      @"<li><a href=""/abc/xyz/42hello42/foobar"">MapWhen with hello in the URL</a></li>",
                      @"<li><a href=""/Session"">Session</a></li>",
                      @"<li>Configuration",
                        @"<ul>",
                          @"<li><a href=""/Configuration/appsettings"">Appsettings</a></li>",
                          @"<li><a href=""/Configuration/colons"">Using Colons</a></li>",
                          @"<li><a href=""/Configuration/database"">Database</a></li>",
                          @"<li><a href=""/Configuration/stronglytyped"">Strongly Typed</a></li>",
                        @"</ul>",
                      @"</li>",
                    @"</ul>"
                };

                var sb = new StringBuilder();
                foreach (var line in lines)
                {
                    sb.Append(line);
                }
                string html = sb.ToString().HtmlDocument("Web Sample App");

                await context.Response.WriteAsync(html);
            });
        }
    }
}
