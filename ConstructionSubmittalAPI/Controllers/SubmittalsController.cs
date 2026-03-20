using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSubmittal_API.Controllers
{
    [Route("api/submittals")]
    [ApiController]
    public class SubmittalsController : ControllerBase
    {
        [HttpGet]
        public string GetSubmittals()
        {
            return "Getting all submittals.";
        }

        [HttpGet("{id:int}")]
        public string GetSubmittalById(int id)
        {
            return "Sub..";
        }
    }
}
