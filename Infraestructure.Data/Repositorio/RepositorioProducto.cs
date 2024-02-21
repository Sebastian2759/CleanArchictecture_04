using Domain.Entidades;
using Domain.Interfaces;
using Infraestructure.Data.Context;
using Infraestructure.Data.Context.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositorio
{
    public class RepositorioProducto : IRepositorioProducto
    {
        private readonly ConfigurationDbContextTienda dbContextTienda;
        public RepositorioProducto(ConfigurationDbContextTienda dbContextTienda)
        {
            this.dbContextTienda = dbContextTienda;
        }
        public async Task<bool> DeleteProducto(Guid id)
        {
            using (var context = GetDbContext())
            {
                var busqueda = context.Producto.Where(x => x.ID_PRODUCTO == id).FirstOrDefaultAsync();
                if (busqueda != null)
                {
                    context.Producto.Remove(await busqueda);
                    await  context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<ProductoEntidades> GetProducto(Guid id)
        {
            using (var db = GetDbContext())
            {
                var busqueda = db.Producto.FindAsync(id);
                if (busqueda.Result != null)
                {
                    return  await busqueda;
                }
                else
                {
                    return new ProductoEntidades();
                }
            }
        }

        public async Task<List<ProductoEntidades>> GetProductos()
        {
            using (var db = GetDbContext())
            {
                var busqueda = db.Producto.ToListAsync();
                if (busqueda.Result.Count > 0)
                {
                    return await busqueda;
                }
                else
                {
                    return new List<ProductoEntidades>();
                }
            }
        }

        public async Task<bool> InsertProducto(ProductoEntidades producto)
        {
            using (var db = GetDbContext())
            {
                producto.ID_PRODUCTO = Guid.NewGuid();
                await db.AddAsync(producto);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateProducto(ProductoEntidades producto)
        {
            using (var db = GetDbContext())
            {
  
                db.Entry(producto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
        }
        public TiendaDbContext GetDbContext()
        {
            string connectionString = dbContextTienda.GetConnectionString();
            var optionBuilder = new DbContextOptionsBuilder<TiendaDbContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new TiendaDbContext(optionBuilder.Options);
        }
    }
}
