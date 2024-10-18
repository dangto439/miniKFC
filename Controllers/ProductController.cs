using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniKFCStore.Models;
using MiniKFCStore.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniKFCStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
