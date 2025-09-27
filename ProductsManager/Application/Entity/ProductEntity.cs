using ProductsManager.Application.Interface;
using ProductsManager.Application.Model;
using ProductsManager.Database;

namespace ProductsManager.Application.Entity;

public class ProductEntity(ApplicationDbContext db) : IProductEntity
{
    private readonly ApplicationDbContext db = db;
    
    public List<Product> GetAll()
    {
        return db.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return db.Products.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Product data)
    {
        db.Products.Add(data);
        db.SaveChanges();
    }

    public Product? Update(int id, Product request)
    {
        var product = db.Products.FirstOrDefault(x => x.Id == id);

        if (product is null)
        {
            return null;
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.Stocke = request.Stocke;

        db.SaveChanges();

        return product;
    }

    public bool Destroy(int id)
    {
        var product = db.Products.FirstOrDefault(x => x.Id == id);

        if (product is null)
        {
            return false;
        }

        db.Products.Remove(product);
        db.SaveChanges();

        return true;
    }
}