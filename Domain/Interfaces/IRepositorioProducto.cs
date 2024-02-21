using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositorioProducto
    {
        Task<List<ProductoEntidades>> GetProductos();
        Task<ProductoEntidades> GetProducto(Guid id);
        Task<bool> InsertProducto(ProductoEntidades producto);
        Task<bool> UpdateProducto(ProductoEntidades producto);
        Task<bool> DeleteProducto(Guid id);
    }
}
