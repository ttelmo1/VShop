namespace VShop.ProductApi;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    Task Commit();
    void Dispose();
}
