using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers;

[Route("/v1/CategoryManagement")]
[ApiController]
public class CategoryController : Controller
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get list of categories.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<Category>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllCategories()
    {
        return Ok(await _mediator.Send(new GetAllCategoriesQuery()));
    }

    /// <summary>
    /// Get category by id.
    /// </summary>
    [Route("{categoryId}")]
    [HttpGet]
    [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int categoryId)
    {
        return Ok(await _mediator.Send(new GetCategoryByIdQuery(categoryId)));
    }

    /// <summary>
    /// Add category.
    /// </summary>
    [Route("")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddCategoryAsync([FromBody] AddCategoryCommand request)
    {
        await _mediator.Send(request);

        return Created(string.Empty, null);
    }

    /// <summary>
    /// Update category.
    /// </summary>
    [Route("")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryCommand request)
    {
        await _mediator.Send(request);

        return Ok();
    }

    /// <summary>
    /// Remove category.
    /// </summary>
    [Route("{categoryId}")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RemoveCategoryAsync([FromRoute] int categoryId)
    {
        await _mediator.Send(new RemoveCategoryCommand(categoryId));

        return NoContent();
    }
}