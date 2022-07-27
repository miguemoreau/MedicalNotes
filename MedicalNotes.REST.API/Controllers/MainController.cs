using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet]

        public ActionResult Main() { return Ok("Medical Notes API V 0.0.1"); }

    }
}
