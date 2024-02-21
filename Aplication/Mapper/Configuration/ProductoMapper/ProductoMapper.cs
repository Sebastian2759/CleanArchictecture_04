using Aplication.Dto;
using Aplication.Mapper.Configuration.ProductoMapper.Interface;
using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mapper.Configuration.ProductoMapper
{
    public class ProductoMapper : IProductoMapper
    {
        private IMapper _mapper;
        public ProductoMapper(IMapper mapper)
        {
            var config = new MapperConfiguration(cfg =>
            {
              cfg.AddProfile<ConfigurationMapperProfile>();
            });
            mapper = config.CreateMapper();
            _mapper = mapper;
        }

        public ProductoEntidades DtoToEntidad(ProductoDto producto)
        {
            return _mapper.Map<ProductoEntidades>(producto);
        }

        public ProductoDto EntidadToDto(ProductoEntidades producto)
        {
            return _mapper.Map<ProductoDto>(producto);
        }

        public List<ProductoDto> ListEntidadToDto(List<ProductoEntidades> productos)
        {
            return _mapper.Map<List<ProductoDto>>(productos);
        }
    }
}
