namespace VShop.ProductApi.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProducts();
    Task<ProductDTO?> GetProductById(int id);
    Task<ProductDTO?> CreateProduct(ProductDTO product);
    Task<ProductDTO?> UpdateProduct(ProductDTO product);
    Task<ProductDTO?> DeleteProduct(int id);
}
