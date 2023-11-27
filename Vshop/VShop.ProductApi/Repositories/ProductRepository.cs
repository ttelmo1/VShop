
using Microsoft.EntityFrameworkCore;

namespace VShop.ProductApi;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context)
    {
    }

    public async  Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId)
    {
        return await Get().Where(p => p.CategoryId == categoryId).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByPrice()
    {
        return await Get().OrderBy(p => p.Price).ToListAsync();
    }
}
