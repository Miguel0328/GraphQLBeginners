using GraphQL.Types;
using GraphQLBeginners.Models;

namespace GraphQLBeginners.Type
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "Product";
            Description = "Product Type";

            Field(x => x.Id);
            Field(x => x.Name).Description("Product name");
            Field(x => x.Price).Description("Product price");
        }
    }
}
