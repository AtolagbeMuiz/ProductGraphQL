namespace ProductGraphQLAPI.GraphQLCore.Query
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
            //the "resolve" helps in resolving/casting the custom type returned(Array of Products) to the GraphQL List Type (ListGraphType)
            Field<ListGraphType<ProductType>>(Name = "ProductsList", resolve: x => productProvider.GetProducts());

            //This returns a product by Id
           Field<ProductType>(Name = "ProductById",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "Id" }),
               resolve: x => productProvider.GetProducts().Where(p => p.Id == x.GetArgument<int>("Id")).FirstOrDefault()); //.FirstOrDefault(p => p.Id == x.GetArgument<int>("Id")));
        }
      
    }
}
