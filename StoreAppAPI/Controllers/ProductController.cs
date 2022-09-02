using Microsoft.AspNetCore.Mvc;
using StoreAppAPI.Models;
using StoreAppAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppAPI.Controllers
{
    [Route("api/products")] // path
    [ApiController]         // for model validation
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var productDTOs = await _productService.GetAll();

            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct([FromRoute] int id)
        {
            var productDTO = await _productService.GetProductById(id);

            if (productDTO is null)
            {
                return NotFound();
            }
            return Ok(productDTO);
        }
    }
}
