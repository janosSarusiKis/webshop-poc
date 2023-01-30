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
    public class OrdersController : ControllerBase
    {
        [HttpGet(Name = "getAllOrdes")]
        [ProducesResponseType(typeof(List<OrderViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(new List<OrderViewModel>());
        }

        [HttpGet("{id}", Name = "getOrder")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<OrderViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id) =>
            Ok();

        [HttpPost(Name = "createOrder")]
        [ProducesResponseType(typeof(OrderViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderViewModel>> Create(OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPatch("{id}", Name = "updateOrder")]
        [ProducesResponseType(typeof(OrderViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderViewModel>> Update(Guid id, [FromBody] OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}", Name = "deleteOrder")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Delete(Guid id) =>
            Ok();
    }
}
