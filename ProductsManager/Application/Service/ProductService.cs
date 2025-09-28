using ProductsManager.Application.Model;
using ProductsManager.Application.Interface;

namespace ProductsManager.Application.Service;

public class ProductService(IProductRepository productEntity) : IProductService
{
    private readonly IProductRepository productEntity = productEntity;
    public List<Product> GetAll()
    {
        var products = productEntity.GetAll();
        return products;
    }

    public Product? GetById(int id)
    {
        var product = productEntity.GetById(id);

        if (product is null)
        {
            return null;
        }

        return product;
    }

    public void Create(Product request)
    {
        productEntity.Create(request);
    }

    public Product? Update(int id, Product request)
    {
        var product = productEntity.Update(id, request);

        if (product is null)
        {
            return null;
        }

        return product;
    }

    public bool Destroy(int id)
    {
        return productEntity.Destroy(id);
    }
}