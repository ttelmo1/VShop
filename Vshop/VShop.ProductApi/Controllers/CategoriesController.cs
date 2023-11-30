using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {
        var categoriesDTO = await _categoryService.GetAllCategories();
        return Ok(categoriesDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
    {
        var categoryDTO = await _categoryService.GetCategoryById(id);
        if (categoryDTO == null)
        {
            return NotFound("Category not found");
        }
        return Ok(categoryDTO);
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesWithProducts()
    {
        var categoriesDTO = await _categoryService.GetCategoriesProducts();
        if(categoriesDTO == null)
        {
            return NotFound("Categories not found");
        }
        return Ok(categoriesDTO);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
    {
        try
        {
            if(categoryDTO == null)
            {
                return BadRequest(ModelState);
            }

            await _categoryService.CreateCategory(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
    {
        try
        {
            if (categoryDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryDTO.Id)
            {
                return BadRequest(ModelState);
            }

            await _categoryService.UpdateCategory(categoryDTO);
            return Ok($"Category {categoryDTO.Id} updated");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        try
        {
            var categoryDTO = await _categoryService.GetCategoryById(id);
            if (categoryDTO == null)
            {
                return NotFound($"Category {id} not found");
            }

            await _categoryService.DeleteCategory(id);
            return Ok($"Category {id} deleted");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}
