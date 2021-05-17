using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace jwt_api_boilerplate.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : Controller
    {
        private readonly IConfiguration configuration;

        public TestingController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> AuthorizationTest()
        {
            // If you don't provide a jwt, a 401 unauthorized response will be sent
            return Ok(new { status = this.Response.StatusCode, message = "AUTHORIZATION SUCCESS" });
        }
    }
}