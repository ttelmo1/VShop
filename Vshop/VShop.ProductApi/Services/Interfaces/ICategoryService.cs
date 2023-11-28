namespace VShop.ProductApi.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllCategories();
    Task<IEnumerable<CategoryDTO?>> GetCategoriesProducts();
    Task<CategoryDTO?> GetCategoryById(int id);
    Task<CategoryDTO?> CreateCategory(CategoryDTO category);
    Task<CategoryDTO?> UpdateCategory(CategoryDTO category);
    Task<CategoryDTO?> DeleteCategory(int id);
}
