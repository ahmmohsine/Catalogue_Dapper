namespace Catalogue.Api.Controllers;

using Catalogue.Core.Dtos.Product;
using Catalogue.Core.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadOnlyProductDTO>>> GetAll(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllAsync(cancellationToken);
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadOnlyProductDTO>> GetById(int id, CancellationToken cancellationToken)
    {
        var product = await _productService.GetByIdAsync(id, cancellationToken);
        if (product is null)
        {
            return NotFound($"Le produit avec l'ID {id} n'existe pas.");
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ReadOnlyProductDTO>> Create([FromBody] CreateProductDTO dto, CancellationToken cancellationToken)
    {
        int newId = await _productService.CreateAsync(dto, cancellationToken);

        // On récupère la ressource complète créée pour la retourner dans le 201 Created
        var createdProduct = await _productService.GetByIdAsync(newId, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = newId },
            createdProduct
        );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDTO dto, CancellationToken cancellationToken)
    {
        bool updated = await _productService.UpdateAsync(id, dto, cancellationToken);
        if (!updated)
        {
            return NotFound($"Le produit avec l'ID {id} n'existe pas.");
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        bool deleted = await _productService.DeleteAsync(id, cancellationToken);
        if (!deleted)
        {
            return NotFound($"Le produit avec l'ID {id} n'existe pas.");
        }

        return NoContent();
    }
}