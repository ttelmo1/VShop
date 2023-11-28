using AutoMapper;
using VShop.ProductApi.Repositories.Interfaces;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<ProductDTO?> CreateProduct(ProductDTO product)
    {
        var productEntity = _mapper.Map<Product>(product);
        var productCreated = await _productRepository.CreateProduct(productEntity);
        product.Id = productCreated.Id;
        var productDTO = _mapper.Map<ProductDTO>(productCreated);
        return productDTO;
    }

    public async Task<ProductDTO?> DeleteProduct(int id)
    {
        var productDeleted = await _productRepository.DeleteProduct(id);
        var productDTO = _mapper.Map<ProductDTO>(productDeleted);
        return productDTO;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProducts()
    {
        var productsEntity = await _productRepository.GetAllProducts();
        var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        return productsDTO;
    }

    public async Task<ProductDTO?> GetProductById(int id)
    {
        var productEntity = await _productRepository.GetProductById(id);
        var productDTO = _mapper.Map<ProductDTO>(productEntity);
        return productDTO;
    }

    public async Task<ProductDTO?> UpdateProduct(ProductDTO product)
    {
        var productEntity = _mapper.Map<Product>(product);
        var productUpdated = await _productRepository.UpdateProduct(productEntity);
        var productDTO = _mapper.Map<ProductDTO>(productUpdated);
        return productDTO;
    }
}
