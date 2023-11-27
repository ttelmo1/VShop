namespace VShop.ProductApi;

public interface ICategoryRepository : IRepository<Category>
{
    Task<IEnumerable<Category>> GetProductsByCategory();
    Task<Category> GetCategoryById(int id);
    Task<Category> CreateCategory(Category category);
    Task<Category> UpdateCategory(Category category);
    Task<Category> DeleteCategory(int id);
}
