using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
    {
        var productsDTO = await _productService.GetAllProducts();
        return Ok(productsDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        var productDTO = await _productService.GetProductById(id);
        if (productDTO == null)
        {
            return NotFound("Product not found");
        }
        return Ok(productDTO);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] ProductDTO productDTO)
    {
        try
        {
            var productCreated = await _productService.CreateProduct(productDTO);
            if (productCreated == null)
            {
                return BadRequest("Failed to create product");
            }
            return new CreatedAtRouteResult("GetProduct", new { id = productCreated.Id }, productCreated);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDTO)
    {
        try
        {
            if (id != productDTO.Id)
            {
                return BadRequest("Product id mismatch");
            }
            var productUpdated = await _productService.UpdateProduct(productDTO);
            if (productUpdated == null)
            {
                return NotFound("Product not found");
            }
            return Ok(productUpdated);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        try
        {
            var productDeleted = await _productService.DeleteProduct(id);
            if (productDeleted == null)
            {
                return NotFound("Product not found");
            }
            return Ok(productDeleted);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
