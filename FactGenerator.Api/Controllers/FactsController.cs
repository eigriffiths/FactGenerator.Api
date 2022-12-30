using FactGenerator.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactGenerator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactsController : ControllerBase
    {
        private readonly IFactService _factService;

        public FactsController(IFactService factService)
        {
            _factService = factService;
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hi!");
        }

        [HttpGet("getfacts")]
        public IActionResult GetFacts()
        {
            var facts = _factService.GetAllFacts();

            return Ok(facts);
        }
    }
}
