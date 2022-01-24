namespace ProductGraphQLAPI.GraphQLCore.Mutation;
public class ProductInput : InputObjectGraphType<Product>
{
    public ProductInput()
    {
        Field<IntGraphType>("id");
        Field<StringGraphType>("name");
        Field<IntGraphType>("quantity");
    }

}
