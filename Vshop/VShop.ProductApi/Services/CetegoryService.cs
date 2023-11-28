using AutoMapper;
using VShop.ProductApi.Repositories.Interfaces;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi;

public class CetegoryService : ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CetegoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }      

    public async Task<CategoryDTO?> CreateCategory(CategoryDTO category)
    {
        var categoryEntity = _mapper.Map<Category>(category);
        var categoryCreated = await _categoryRepository.CreateCategory(categoryEntity);
        category.Id = categoryCreated.Id;
        //duvida: necessario retornar?
        var categoryDTO = _mapper.Map<CategoryDTO>(categoryCreated);
        return categoryDTO;
    }

    public async Task<CategoryDTO?> DeleteCategory(int id)
    {
        try
        {
            var categoryDeleted = await _categoryRepository.DeleteCategory(id);
            var categoryDTO = _mapper.Map<CategoryDTO>(categoryDeleted);
            return categoryDTO;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao deletar categoria");
        }
        
    }

    public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
    {
        var caterogiesEntity = await _categoryRepository.GetAllCategories();
        var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(caterogiesEntity);
        return categoriesDTO;
    }

    public async Task<IEnumerable<CategoryDTO?>> GetCategoriesProducts()
    {
        var caterogiesEntity = await _categoryRepository.GetCategoriesProducts();
        var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(caterogiesEntity);
        return categoriesDTO;
    }

    public async Task<CategoryDTO?> GetCategoryById(int id)
    {
        var categoryEntity = await _categoryRepository.GetCategoryById(id);
        var categoryDTO = _mapper.Map<CategoryDTO>(categoryEntity);
        return categoryDTO;
    }

    public async Task<CategoryDTO?> UpdateCategory(CategoryDTO category)
    {
        var categoryEntity = _mapper.Map<Category>(category);
        var categoryUpdated = await _categoryRepository.UpdateCategory(categoryEntity);
        var categoryDTO = _mapper.Map<CategoryDTO>(categoryUpdated);
        return categoryDTO;
    }
}
