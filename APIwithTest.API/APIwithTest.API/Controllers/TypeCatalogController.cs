using APIwithTest.Services.Interfaces;
using APIwithTest.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIwithTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeCatalogController : ControllerBase
    {
        private readonly ITypeCatalogService typeCatalogService;
        public TypeCatalogController(ITypeCatalogService typeCatalogService)
        {
            this.typeCatalogService = typeCatalogService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(typeCatalogService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(typeCatalogService.GetById(new TypeCatalog { Id = id }));
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            return Ok(typeCatalogService.GetByName(new TypeCatalog { Name = name }));
        }
    }
}
