namespace VShop.ProductApi;

public class UnitOfWork : IUnitOfWork
{
    private ProductRepository _productRepository;
    private CategoryRepository _categoryRepository;
    public AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        _productRepository = new ProductRepository(_context);
        _categoryRepository = new CategoryRepository(_context);
    }

    public IProductRepository ProductRepository
    {
        get
        {
            return _productRepository = _productRepository ?? new ProductRepository(_context);
        }
    }

    public ICategoryRepository CategoryRepository
    {
        get
        {
            return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
        }
    }    

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        //duvida: o que é o dispose? Necessário ser async?
        _context.Dispose();
    }
}
