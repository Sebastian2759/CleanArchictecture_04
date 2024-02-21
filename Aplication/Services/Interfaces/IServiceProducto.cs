using Aplication.Dto;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Interfaces
{
    public interface IServiceProducto
    {
        Task<List<ProductoDto>> GetProductos();
        Task<ProductoDto> GetProducto(Guid id);
        Task<bool> InsertProducto(ProductoDto producto);
        Task<bool> UpdateProducto(ProductoDto producto);
        Task<bool> DeleteProducto(Guid id);
    }
}
