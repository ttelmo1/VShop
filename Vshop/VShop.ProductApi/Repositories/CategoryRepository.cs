using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Repositories.Interfaces;

namespace VShop.ProductApi;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Category> CreateCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> DeleteCategory(int id)
    {   
        try
        {
            var category = await GetCategoryById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return category;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoriesProducts()
    {
        return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync();
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Category?> UpdateCategory(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }
}
