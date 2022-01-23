namespace ProductGraphQLAPI.Models
{
    public class ProductType : ObjectGraphType<Product>
    {
        /// <summary>
        /// This ProductType class intitializes the Product class with its Field/Properties cause
        /// GraphQL doesn't understand our C# custom class Product, so we bind or map it with the GraphQL by creating the ProductType class
        /// which inherits from ObjectGraphType
        /// </summary>
        public ProductType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Quantity);
        }
    }
}
