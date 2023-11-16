using System.Security.Claims;
using CansInnov.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CansInnov.Server.Controllers
{
    [ApiController()]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ApplicationUser> Get()
        {
            var user = new ApplicationUser
            {
                Matricule = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            return Ok(user);
        }
    }
}