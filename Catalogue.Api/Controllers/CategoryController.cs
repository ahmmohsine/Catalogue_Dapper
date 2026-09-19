using Catalogue.Core.Dtos.Category;
using Catalogue.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ReadOnlyCategoryDTO>>> GetAll(CancellationToken cancellationToken)
    {
        var categories = await _categoryService.GetAllAsync(cancellationToken);
        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadOnlyCategoryDTO>> GetById(int id, CancellationToken cancellationToken)
    {
        var category = await _categoryService.GetByIdAsync(id, cancellationToken);
        if (category is null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<ReadOnlyCategoryDTO>> Create([FromBody] CreateCategoryDTO createCategory, CancellationToken cancellationToken)
    {
        ReadOnlyCategoryDTO createdCategory = await _categoryService.CreateCategoryAsync(createCategory, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdCategory.Id },
            createdCategory
        );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDTO updateCategory, CancellationToken cancellationToken)
    {
        var updated = await _categoryService.UpdateCategoryAsync(id, updateCategory, cancellationToken);

        if (!updated)
        {
            return NotFound($"La catégorie avec l'ID {id} n'existe pas.");
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await _categoryService.DeleteCategoryAsync(id, cancellationToken);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}