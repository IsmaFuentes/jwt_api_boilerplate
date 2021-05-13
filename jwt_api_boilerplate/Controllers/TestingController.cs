using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace jwt_api_boilerplate.Controllers
{
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
        [Authorize]
        public async Task<ActionResult> AuthorizationTest()
        {
            // If you don't provide a jwt, a 401 unauthorized response will be sent
            return Ok("Authorization success!!");
        }
    }
}