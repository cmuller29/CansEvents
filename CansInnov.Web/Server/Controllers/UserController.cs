using System.Security.Claims;
using CansInnov.Shared;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CansInnov.Server.Controllers
{
    [ApiController()]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            Claim claim = new Claim(ClaimTypes.NameIdentifier, "cmuller");

            ClaimsIdentity identity = new ClaimsIdentity(
                new Claim[] { claim },
                "My-Console-Authentication-Type", ClaimTypes.NameIdentifier,
                "admin");

            return Ok(CreateUserInfo(new ClaimsPrincipal(identity)));
        }

        private UserInfo CreateUserInfo(ClaimsPrincipal claimsPrincipal)
        {
            if (!claimsPrincipal.Identity.IsAuthenticated)
            {
                return UserInfo.Anonymous;
            }

            var userInfo = new UserInfo
            {
                IsAuthenticated = true
            };

            if (claimsPrincipal.Identity is ClaimsIdentity claimsIdentity)
            {
                userInfo.NameClaimType = claimsIdentity.NameClaimType;
                userInfo.RoleClaimType = claimsIdentity.RoleClaimType;
            }
            else
            {
                userInfo.NameClaimType = JwtClaimTypes.Name;
                userInfo.RoleClaimType = JwtClaimTypes.Role;
            }

            if (claimsPrincipal.Claims.Any())
            {
                var claims = new List<ClaimValue>();
                var nameClaims = claimsPrincipal.Claims.ToList();
                foreach (var claim in nameClaims)
                {
                    switch (claim.Type)
                    {
                        case string searchKey when searchKey.Contains("givenname"):
                            userInfo.GivenName = claim.Value;
                            break;
                        case string searchKey when searchKey.Contains("surname"):
                            userInfo.SurName = claim.Value;
                            break;
                        case string searchKey when searchKey.Contains("nameidentifier"):
                            userInfo.UserMatricule = claim.Value;
                            break;
                        case string searchKey when searchKey.Contains("emailaddress"):
                            userInfo.UserMail = claim.Value;
                            break;
                        default:
                            break;
                    }

                    claims.Add(new ClaimValue(claim.Type, claim.Value));
                }

                userInfo.Claims = claims;
            }
            return userInfo;
        }
    }
}
