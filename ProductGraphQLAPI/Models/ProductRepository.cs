namespace ProductGraphQLAPI.Models;

public interface IProductRepository
{
    List<Product> Get();
    Product Create(Product product);
}

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product(1, "Laptop", 20),
        new Product(2, "Mouse", 30),
        new Product(3, "Keyboard", 10),
        new Product(4, "Monitor", 40)

    };



    public List<Product> Get() => _products;


    public Product Create(Product product)
    {
        _products.Add(product);
        return product;
    }
            
}
