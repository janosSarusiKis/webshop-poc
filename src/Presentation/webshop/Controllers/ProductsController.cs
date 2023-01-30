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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet(Name = "getAllProducts")]
        [ProducesResponseType(typeof(List<ProductViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAll();
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(new ProductViewModel().MapFromEntity(product));
            }

            return Ok(productsViewModels);
        }

        [HttpGet("{id}", Name = "getProduct")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<ProductViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id) =>
            Ok(await _productService.GetByIdAsync(id));

        [HttpPost(Name = "createProduct")]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductViewModel>> Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newProductViewModel = await _productService.CreateAsync(productViewModel.MapToEntity());
            if (newProductViewModel == null)
            {
                return NotFound("Category not found");
            }

            return Ok();
        }

        [HttpPatch("{id}", Name = "updateProduct")]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductViewModel>> Update(Guid id, [FromBody] ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}", Name = "deleteProduct")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Delete(Guid id) =>
            Ok(await _productService.DeleteByIdAsync(id));
    }
}
