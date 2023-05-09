using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/teste")]
    [ApiController]
    
    public class TesteV1Controller : ControllerBase
    {
        [HttpGet("get")]
        public ActionResult Get()
        {
            return Content("<html><body><h2>TesteV1Controller - V 1.0 </h2></body></html>", "text/html");
        }
    }
}
