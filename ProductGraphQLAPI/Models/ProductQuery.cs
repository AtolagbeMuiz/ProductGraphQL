namespace ProductGraphQLAPI.Models
{
    public class ProductQuery : ObjectGraphType
    {
        /// <summary>
        /// This queries the method to get all products.. 
        /// which returns a array of products that is casted into GraphQL List type
        /// </summary>
        /// <param name="productProvider"></param>
        public ProductQuery(IProductProvider productProvider)
        {
            //This returns a List of ProductType 
            //the "resolve" helps in resolving/casting the custom type returned(Array of Products) to the GraphQL List Type (GistGraphType)
            Field<ListGraphType<ProductType>>(Name = "ProductsList", resolve: x => productProvider.GetProducts());
        }
      
    }
}
