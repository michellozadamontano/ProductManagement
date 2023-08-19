using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Features.Products.Commands.CreateProduct;
using ProductManagement.Application.Features.Products.Commands.DeleteProduct;
using ProductManagement.Application.Features.Products.Commands.UpdateProduct;
using ProductManagement.Application.Features.Products.Queries.GetAllProducts;
using ProductManagement.Application.Features.Products.Queries.GetProductById;

namespace ProductManagement.WebApi.Controllers.v1;

[ApiVersion("1.0")]
[Authorize]
public class ProductController : BaseApiController
{
    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> Get(int pageNumber, int pageSize)
    {
        return Ok(await Mediator.Send(new GetAllProductQuery(pageNumber, pageSize)));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetProductByIdQuery(id)));
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("create")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    /// <summary>
    /// Update a product
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("update/{id:int}")]   
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    /// Delete a product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]    
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteProductCommand(id)));
    }
}