using System.ComponentModel.DataAnnotations;

namespace VShop.ProductApi;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }

    public string? Description { get; set; }

    [Required(ErrorMessage = "Stock is required")]
    public long Stock { get; set; }
    
    public string? ImageURL { get; set; }

    
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}
