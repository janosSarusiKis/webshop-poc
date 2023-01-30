using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webshop.ViewModels;

namespace webshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet(Name = "getAllCategories")]
        [ProducesResponseType(typeof(List<CategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAll();
            var categoriesViewModels = new List<CategoryViewModel>();
            foreach (var category in categories)
            {
                categoriesViewModels.Add(new CategoryViewModel().MapFromEntity(category));
            }

            return Ok(categoriesViewModels);
        }

        [HttpGet("{id}", Name = "getCategory")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<CategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id) =>
            Ok(await _categoryService.GetByIdAsync(id));

        [HttpPost(Name = "createCategory")]
        [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryViewModel>> Create(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _categoryService.CreateAsync(categoryViewModel.MapToEntity()));
        }

        [HttpPatch("{id}", Name = "updateCategory")]
        [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryViewModel>> Update(
            Guid id,
            [FromBody] CategoryViewModel CategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}", Name = "deleteCategory")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Delete(Guid id) =>
            Ok();
    }
}
