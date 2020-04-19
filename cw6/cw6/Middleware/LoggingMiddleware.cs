using cw6.Models;
using cw6.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw6.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            if (context.Request != null)
            {
                Logs log = new Logs();
                log.Path = context.Request.Path;
                log.MethodType = context.Request.Method;
                log.Query = context.Request.QueryString.ToString();

                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    log.Body = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;
                }
                // zapis do pliku
                string logs = log.ToString();
 
                using (var writer = new StreamWriter("Log.txt", true))
                {
                writer.WriteLine(log);
                }
            }

            if (_next != null) await _next(context);
        }
    }
}
