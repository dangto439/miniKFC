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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            await _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateCategory(Category category)
        {
            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
