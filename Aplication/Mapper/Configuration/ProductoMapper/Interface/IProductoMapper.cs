using Aplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mapper.Configuration.ProductoMapper.Interface
{
    public interface IProductoMapper
    {
        ProductoDto EntidadToDto(Domain.Entidades.ProductoEntidades producto);
        Domain.Entidades.ProductoEntidades DtoToEntidad(ProductoDto producto);

        List<ProductoDto> ListEntidadToDto(List<Domain.Entidades.ProductoEntidades> productos);
    }
}
