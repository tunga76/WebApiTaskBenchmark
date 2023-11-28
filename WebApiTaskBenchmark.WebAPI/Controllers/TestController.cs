using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTaskBenchmark.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("Sync")]
        public ActionResult GetSync()
        {
            Thread.Sleep(1000);
            return Ok();


        }
        [HttpGet]
        [Route("Async")]
        public async Task<ActionResult> GetAsync()
        {
            await Task.Delay(1000);
            return Ok();
        }
    }
}
