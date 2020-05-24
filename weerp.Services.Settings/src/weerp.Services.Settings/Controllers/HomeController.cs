using Microsoft.AspNetCore.Mvc;

namespace weerp.Services.Settings.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("WeErp Settings Service");
    }
}