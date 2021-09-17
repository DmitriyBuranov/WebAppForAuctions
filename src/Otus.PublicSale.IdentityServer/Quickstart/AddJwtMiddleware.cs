using IdentityServer4;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Otus.PublicSale.IdentityServer.Quickstart
{
    public class AddJwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IdentityServerTools _tools;

        public AddJwtMiddleware(RequestDelegate next, IdentityServerTools tools)
        {
            _next = next;
            _tools = tools;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
                if (httpContext.User.Identity is ClaimsIdentity claimsIdentity)
                {
                    if (!claimsIdentity.Claims.Any(x => x.Type == "JWT"))
                    {
                        var tokenClaims = new List<Claim>() { 
                            new Claim("scope", "otus.publicsale.webapi"),
                            new Claim("aud", "otus.publicsale.webapi")                            
                        };
                        foreach (var claim in claimsIdentity.Claims)
                        {
                            tokenClaims.Add(claim);
                        }

                        var issuer = "https://localhost:44337";
                        var token = await _tools.IssueJwtAsync(
                            30000,
                            issuer,
                            tokenClaims
                        );

                        var claims = new List<Claim>
                        {
                            new Claim("JWT", token)
                        };

                        var appIdentity = new ClaimsIdentity(claims);
                        httpContext.User.AddIdentity(appIdentity);
                    }
                }
            }

            await _next(httpContext);
        }
    }
}
