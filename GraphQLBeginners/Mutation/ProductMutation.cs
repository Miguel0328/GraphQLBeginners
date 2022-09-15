using GraphQL;
using GraphQL.Types;
using GraphQLBeginners.Interfaces;
using GraphQLBeginners.Models;
using GraphQLBeginners.Type;

namespace GraphQLBeginners.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct service)
        {
            FieldAsync<ProductType>("addProduct",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }),
                resolve: async context => await service.Add(context.GetArgument<Product>("product")));

            FieldAsync<ProductType>("updateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    var product = context.GetArgument<Product>("product");
                    return await service.Update(id, product);
                });

            FieldAsync<StringGraphType>("deleteProduct",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: async context =>
                {
                    await service.Delete(context.GetArgument<int>("id"));
                    return "deleted";
                });
        }
    }
}
