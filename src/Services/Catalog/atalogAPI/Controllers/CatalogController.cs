using CatalogAPI.Entities;
using CatalogAPI.Reposatory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        private readonly IProductRepo _repo;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepo repo, ILogger<CatalogController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(typeof (IEnumerable<Product>),(int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Product>> GetAll()
        {
            var result=await _repo.GetAll();
            return (IEnumerable<Product>)Ok(result);
        }

        [HttpGet("{id:length(24)}",Name ="GetProduct")]
        public async Task<IActionResult> GetProductByID(string id)
        {
            var result = await _repo.Getbyid(id);
            if(result==null)
            {
                _logger.LogError("");
                return NotFound();
            }
            return Ok(result);
        }
        [Route("[action]/{Category}",Name = "GetByCategoryName")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategoryName(string name)
        {
            var result = await _repo.GetbyCategoryName(name);
            return Ok(result);
        }
    }
}
