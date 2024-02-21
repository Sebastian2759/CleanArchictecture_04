using Aplication.Dto;
using Aplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IServiceProducto _serviceProducto;
        public ProductoController(IServiceProducto serviceProducto)
        {
            _serviceProducto = serviceProducto;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<List<ProductoDto>> Get()
        {
            return await _serviceProducto.GetProductos();
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<ProductoDto> Get(Guid id)
        {
            return await _serviceProducto.GetProducto(id);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<bool> Post([FromBody] ProductoDto value)
        {

            return await _serviceProducto.InsertProducto(value);
        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] ProductoDto value)
        {
            return await _serviceProducto.UpdateProducto(value);
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _serviceProducto.DeleteProducto(id);
        }
    }
}
