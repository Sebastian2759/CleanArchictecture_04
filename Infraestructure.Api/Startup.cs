using Aplication.Mapper.Configuration;
using Aplication.Mapper.Configuration.ProductoMapper;
using Aplication.Mapper.Configuration.ProductoMapper.Interface;
using Aplication.Services;
using Aplication.Services.Interfaces;
using Domain.Interfaces;
using Infraestructure.Data.Context;
using Infraestructure.Data.Context.Configuration;
using Infraestructure.Data.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Api
{
    public class Startup
    {
        
       private IConfiguration Configuration { get; }
       public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<TiendaDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddSingleton(new ConfigurationDbContextTienda(connectionString));
            services.AddScoped<IRepositorioProducto, RepositorioProducto>();
            services.AddScoped<IServiceProducto, ServiceProducto>();
            services.AddScoped<IProductoMapper, ProductoMapper>();
            services.AddAutoMapper(typeof(ConfigurationMapperProfile));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                                       builder =>
                                       {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

  
        }
       
      
    }
}
