namespace VShop.ProductApi;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId);
    Task<IEnumerable<Product>> GetProductByPrice();
}
