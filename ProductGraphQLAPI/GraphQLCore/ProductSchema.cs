using ProductGraphQLAPI.GraphQLCore.Mutation;

namespace ProductGraphQLAPI.GraphQLCore
{
    public class ProductSchema : Schema
    {
        /// <summary>
        /// WorkFlow is Schema ===> Query ===> Type
        /// Schema is used for documentation which in turn links to Query that results to the GraphType
        /// </summary>
        /// <param name="serviceProvider"></param>
        public ProductSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<ProductQuery>();

            Mutation = serviceProvider.GetRequiredService<ProductMutation>();
        }
    }
}
