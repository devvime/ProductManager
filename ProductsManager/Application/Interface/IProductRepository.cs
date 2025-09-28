using ProductsManager.Application.Model;

namespace ProductsManager.Application.Interface;

public interface IProductRepository
{
    public List<Product> GetAll();

    public Product? GetById(int id);

    public void Create(Product request);

    public Product? Update(int id, Product request);

    public bool Destroy(int id);
}