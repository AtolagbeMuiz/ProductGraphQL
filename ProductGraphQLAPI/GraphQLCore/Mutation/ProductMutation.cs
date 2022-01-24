namespace ProductGraphQLAPI.GraphQLCore.Mutation;

public class ProductMutation : ObjectGraphType
{
    public ProductMutation(IProductProvider productProvider)
    {
        Field<ProductType>("CreateProduct",
              arguments: new QueryArguments(new QueryArgument<ProductInput> { Name = "product" }),
              resolve: x => productProvider.CreateProduct(x.GetArgument<Product>("product")));
    }
}

