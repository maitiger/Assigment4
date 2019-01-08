using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ASM.Data;
using ASM.Models;

namespace ASM.Midle
{
    public static class ChecktokenExtensions
    {
        public static IApplicationBuilder UseCheckToken(
           this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Checktoken>;
        }
    }
    public class Checktoken
    {
        private readonly RequestDelegate _next;

        public Checktoken(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext databaseContext)
        {
            bool isValid = false;
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var basicToken = context.Request.Headers["Authorization"].ToString();
                basicToken = basicToken.Replace("Basic ", "");
                MyCredential credential = databaseContext.MyCredential.SingleOrDefault(c => c.AccessToken == basicToken);
                if (credential != null && credential.isValid())
                {
                    isValid = true;
                }
            }
            if (isValid)
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Forbidden");
            }

        }
    }
}

