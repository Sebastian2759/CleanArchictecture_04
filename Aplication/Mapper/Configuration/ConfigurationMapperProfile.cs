using Aplication.Dto;
using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mapper.Configuration
{
    public class ConfigurationMapperProfile: Profile
    {
        public ConfigurationMapperProfile()
        {
            CreateMap<ProductoEntidades, ProductoDto>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID_PRODUCTO))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.PRODUCTO_NOMBRE))
                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.PRODUCTO_DESCRIPCION))
                .ForMember(dest => dest.cantidad, opt => opt.MapFrom(src => src.PRODUCTO_CANTIDAD)).ReverseMap();

        }
    }
}
