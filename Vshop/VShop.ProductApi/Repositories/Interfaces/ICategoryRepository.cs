namespace VShop.ProductApi.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category?> GetCategoriesProducts();
    Task<Category?> GetCategoryById(int id);
    Task<Category> CreateCategory(Category category);
    Task<Category?> UpdateCategory(Category category);
    Task<Category?> DeleteCategory(int id);
}
