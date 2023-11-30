using AutoMapper;
using VShop.ProductApi.Repositories.Interfaces;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi;

public class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }      

    public async Task<CategoryDTO?> CreateCategory(CategoryDTO category)
    {
        try
        {
            var categoryEntity = _mapper.Map<Category>(category);
            var categoryCreated = await _categoryRepository.CreateCategory(categoryEntity);
            category.Id = categoryCreated.Id;
            var categoryDTO = _mapper.Map<CategoryDTO>(categoryCreated);
            return categoryDTO;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao criar categoria", ex);
        }
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
        try
        {
            var caterogiesEntity = await _categoryRepository.GetAllCategories();
            var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(caterogiesEntity);
            return categoriesDTO;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao obter todas as categorias", ex);
        }
    }

    public async Task<IEnumerable<CategoryDTO?>> GetCategoriesProducts()
    {
        try
        {
            var caterogiesEntity = await _categoryRepository.GetCategoriesProducts();
            var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(caterogiesEntity);
            return categoriesDTO;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao obter categorias de produtos");
        }
    }

    public async Task<CategoryDTO?> GetCategoryById(int id)
    {
        try
        {
            var categoryEntity = await _categoryRepository.GetCategoryById(id);
            var categoryDTO = _mapper.Map<CategoryDTO>(categoryEntity);
            return categoryDTO;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<CategoryDTO?> UpdateCategory(CategoryDTO category)
    {
        try
        {
            var categoryEntity = _mapper.Map<Category>(category);
            var categoryUpdated = await _categoryRepository.UpdateCategory(categoryEntity);
            var categoryDTO = _mapper.Map<CategoryDTO>(categoryUpdated);
            return categoryDTO;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao atualizar categoria", ex);
        }
    }
}
