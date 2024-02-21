using Aplication.Dto;
using Aplication.Mapper.Configuration.ProductoMapper.Interface;
using Aplication.Services.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class ServiceProducto: IServiceProducto
    {
        private readonly IProductoMapper _productoMapper;
        private readonly IRepositorioProducto repositorioProducto;
        public ServiceProducto(IProductoMapper productoMapper, IRepositorioProducto repositorioProducto)
        {
            _productoMapper = productoMapper;
            this.repositorioProducto = repositorioProducto;
        }
        public async Task<bool> DeleteProducto(Guid id)
        {
            return await repositorioProducto.DeleteProducto(id);
        }

        public async Task<ProductoDto> GetProducto(Guid id)
        {
           return await repositorioProducto.GetProducto(id).ContinueWith(task => _productoMapper.EntidadToDto(task.Result));
        }

        public async Task<List<ProductoDto>> GetProductos()
        {
            return  _productoMapper.ListEntidadToDto(await repositorioProducto.GetProductos());
        }

        public Task<bool> InsertProducto(ProductoDto producto)
        {
            return repositorioProducto.InsertProducto(_productoMapper.DtoToEntidad(producto));
        }

        public Task<bool> UpdateProducto(ProductoDto producto)
        {
           return repositorioProducto.UpdateProducto(_productoMapper.DtoToEntidad(producto));
        }
    }
}
