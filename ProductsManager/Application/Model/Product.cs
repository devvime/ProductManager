namespace ProductsManager.Application.Model
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Stocke { get; set; }
    }
}