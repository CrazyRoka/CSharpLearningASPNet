using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSampleApp.Services;

namespace WebSampleApp.Controllers
{
    public class HomeController
    {
        private readonly ISampleService _service;
        public HomeController(ISampleService sampleService) => _service = sampleService;

        public async Task Index(HttpContext context)
        {
            var sb = new StringBuilder();
            sb.Append("<ul>");
            sb.Append(string.Join(string.Empty,
                _service.GetSampleStrings().Select(s => s.Li()).ToArray()));
            sb.Append("</ul>");
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(sb.ToString());   
        }
    }
}
