using FactGenerator.Core.Dto;
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

        [HttpGet("getfacts")]
        public IActionResult GetFacts()
        {
            var facts = _factService.GetAllFacts();

            return Ok(facts);
        }

        [HttpGet("getfact/{id}")]
        public IActionResult GetFact(int id)
        {
            var fact = _factService.GetFact(id);            
                
            return Ok(fact);
        }

        [HttpPost("create")]
        public IActionResult Create(FactDto factDto)
        {
            var created = false;

            try
            {
                created = _factService.CreateFact(factDto);
            }
            catch (Exception)
            {
                return StatusCode(500);   
            }

            if (created)
            {
                return StatusCode(201);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("edit")]
        public IActionResult Edit(FactDto factDto)
        {
            try
            {
                _factService.EditFact(factDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _factService.DeleteFact(id);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
