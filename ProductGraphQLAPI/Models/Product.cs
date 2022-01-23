namespace ProductGraphQLAPI.Models;

//public record Product
//{
//    private int _id { get; set; }
//    private string _name { get; set; }
//    private int _quantity { get; set; }

//    public Product(int Id, string Name, int Quantity)
//    {
//        this._id = Id;
//        this._name = Name;
//        this._quantity = Quantity;
//    }
//}

public record Product(int Id, string Name, int Quantity);

public  interface IProductProvider
{
    Product[] GetProducts();
}

public class ProductProvider : IProductProvider
{
    public Product[] GetProducts() => new[]
    {
        new Product(1, "Laptop", 20),
        new Product(2, "Mouse", 30),
        new Product(3, "Keyboard", 10),
        new Product(4, "Monitor", 40)

    };
}
