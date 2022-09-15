using GraphQLBeginners.Models;

namespace GraphQLBeginners.Interfaces
{
    public interface IProduct
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(int id, Product product);
        Task Delete(int id);
    }
}
