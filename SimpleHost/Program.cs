using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SimpleHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(async context =>
            {
                await context.Response.WriteAsync("<h1>A Simple Host</h1>");
            }).WaitForShutdown();
        }
    }
}
