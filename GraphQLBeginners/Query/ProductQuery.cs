using GraphQL;
using GraphQL.Types;
using GraphQLBeginners.Interfaces;
using GraphQLBeginners.Models;
using GraphQLBeginners.Type;

namespace GraphQLBeginners.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProduct service)
        {
            FieldAsync<ListGraphType<ProductType>>("products",
                resolve: async context => await service.GetAll());

            FieldAsync<ProductType>("product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context => await service.GetById(context.GetArgument<int>("id")));
        }
    }
}
