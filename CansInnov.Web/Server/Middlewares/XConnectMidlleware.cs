using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace CansInnov.Server.Middlewares
{
    public class XConnectMidlleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Claim claim = new Claim(ClaimTypes.NameIdentifier, "cmuller");

            ClaimsIdentity identity = new ClaimsIdentity(
                new Claim[] { claim },
                "My-Console-Authentication-Type", ClaimTypes.NameIdentifier,
                "admin");

            context.User = new ClaimsPrincipal(identity);

            return next(context);
        }
    }
}