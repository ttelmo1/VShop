namespace VShop.ProductApi.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product?> GetProductById(int id);
    Task<Product> CreateProduct(Product product);
    Task<Product?> UpdateProduct(Product product);
    Task<Product?> DeleteProduct(int id);
}
