
using Microsoft.EntityFrameworkCore;

namespace VShop.ProductApi;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(DbContext context) : base(context)
    {
    }

    public async Task<Category> CreateCategory(Category category)
    {
        try
        {
            Add(category);
            await Commit();
            return category;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<Category> DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetCategoryById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetProductsByCategory()
    {
        return await Get().Include(c=> c.Products).ToListAsync();
    }

    public Task<Category> UpdateCategory(Category category)
    {
        throw new NotImplementedException();
    }
}
