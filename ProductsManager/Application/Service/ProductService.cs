using ProductsManager.Application.Interface;
using ProductsManager.Application.Model;

namespace ProductsManager.Application.Service;

public class ProductService : IProductService
{
    private static List<Product> products =
    [
        new Product() { Id = 1, Name = "Monitor", Price = 499.90m, Stocke = 50 },
        new Product() { Id = 2, Name = "Notebook", Price = 1499.90m, Stocke = 30 }
    ];

    public List<Product> GetAll()
    {
        return products;
    }

    public Product? GetById(int id)
    {
        return products.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Product request)
    {
        products.Add(request);
    }

    public Product? Update(int id, Product request)
    {
        var product = products.FirstOrDefault(x => x.Id == id);

        if (product is null)
        {
            return null;
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.Stocke = request.Stocke;

        return product;
    }

    public bool Destroy(int id)
    {
        var product = products.FirstOrDefault(x => x.Id == id);

        if (product is null)
        {
            return false;
        }

        products.Remove(product);

        return true;
    }
}