using APIwithTest.Services.Interfaces;
using APIwithTest.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIwithTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(catalogService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(catalogService.GetById(new Catalog { Id = id }));
        }

        [HttpGet("ByName/{name}")]
        public IActionResult GetByName(string name)
        {
            return Ok(catalogService.GetByName(new Catalog { Name = name }));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Catalog item)
        {
            var result = catalogService.SaveNew(item);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromQuery]int id, [FromBody] Catalog item)
        {
            if (id == item.Id)
            {
                var result = catalogService.Update(item);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
