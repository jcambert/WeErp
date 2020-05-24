using Microsoft.AspNetCore.Mvc;

namespace weerp.Services.Cotations.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get() => Ok("WeErp Cotations Service");
    }
}