using Fish.Application.Model;
using Fish.Application.Usecase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fish.Export.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : BaseController
    {
        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<ResponseOne<CreateProductData>>> AddProduct(CreateProductRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<ActionResult<ResponseOne<UpdateProductData>>> UpdateProduct(UpdateProductRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<ActionResult<ResponseOne<DeleteProductData>>> DeleteProduct(DeleteProductRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize]
        [HttpPost("find")]
        public async Task<ActionResult<ResponseOne<FindProductData>>> FindProduct([FromBody] FindProductRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        [Authorize]
        [HttpGet("detail/{productId}")]
        public async Task<ActionResult<ResponseOne<GetProductData>>> GetProduct([FromRoute] GetProductRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

    }
}
