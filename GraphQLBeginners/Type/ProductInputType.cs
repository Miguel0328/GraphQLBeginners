using GraphQL.Types;
using GraphQLBeginners.Models;

namespace GraphQLBeginners.Type
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "ProductInput";
            Description = "ProductInput Type";

            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<DecimalGraphType>("price");
        }

        //public override object ParseDictionary(IDictionary<string, object> value)
        //{
        //    return new Product
        //    {
        //        Id = 0,
        //        Name = ((string)value["name"]),
        //        Price = value.TryGetValue("price", out var price) ? Convert.ToDecimal(price) : 0
        //    };
        //}
    }
}
