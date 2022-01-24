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
    Product CreateProduct(Product product);
}

public class ProductProvider : IProductProvider
{
    private readonly IProductRepository _productRepo;

    public ProductProvider(IProductRepository productRepo)
    {
        this._productRepo = productRepo;
    }

    //This method calls the Get method in the Productrepository that returns all the products stored in-memory
    public Product[] GetProducts() =>
        _productRepo.Get().ToArray();


    public Product CreateProduct(Product product)
    {
        _productRepo.Create(product);
        return product;
    }

}
