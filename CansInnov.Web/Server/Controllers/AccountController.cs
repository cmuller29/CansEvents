using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CansInnov.Server.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet("LoginToServer")]
        public async Task Login(string returnUrl = "/")
        {
            await HttpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = returnUrl });
        }
    }
}