using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Features.Categories.Commands.CreateCategory;
using ProductManagement.Application.Features.Categories.Commands.DeleteCategory;
using ProductManagement.Application.Features.Categories.Commands.UpdateCategory;
using ProductManagement.Application.Features.Categories.Queries.GetAllCategories;
using ProductManagement.Application.Features.Categories.Queries.GetCategoryById;
using ProductManagement.WebApi.Extensions;

namespace ProductManagement.WebApi.Controllers.v1;

[ApiVersion("1.0")]
public class CategoryController : BaseApiController
{
    /// <summary>
    /// Get all categories
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await Mediator.Send(new GetAllCategoriesQuery()));
    }
    
    /// <summary>
    /// Create a new category
    /// </summary>
    /// <param name="categoryCommand"></param>
    /// <returns></returns>
    [HttpPost]
    //[Authorize(Policy = AuthorizationConsts.AdminPolicy)]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] CreateCategoryCommand categoryCommand)
    {
        return Ok(await Mediator.Send(categoryCommand));
    }
    
    /// <summary>
    /// Get a category by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]    
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator.Send(new GetCategoryByIdQuery(id)));
    }
    
    /// <summary>
    /// Update a category
    /// </summary>
    /// <param name="id"></param>
    /// <param name="categoryCommand"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateCategoryCommand categoryCommand)
    {
        if (id != categoryCommand.Id)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(categoryCommand));
    }
    
    /// <summary>
    /// Delete a category
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteCategoryCommand = new DeleteCategoryCommand(id);
        return Ok(await Mediator.Send(deleteCategoryCommand));
    }
}