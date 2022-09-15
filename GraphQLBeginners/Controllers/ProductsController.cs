using GraphQLBeginners.Interfaces;
using GraphQLBeginners.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GraphQLBeginners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _service;

        public ProductsController(IProduct service)
        {
            _service = service;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _service.GetById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<Product> Post([FromBody] Product product)
        {
            return await _service.Add(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<Product> Put(int id, [FromBody] Product product)
        {
            return await _service.Update(id, product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
