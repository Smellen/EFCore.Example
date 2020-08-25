using System;
using System.Threading.Tasks;
using EFCore.Example.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Example.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Gets a product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>A product.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            if(id < 1)
            {
                return BadRequest("The product identifier is required.");
            }

            var product = await _service.GetProduct(id);

            return Ok(product);
        }
    }
}
