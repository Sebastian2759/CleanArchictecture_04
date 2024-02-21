using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ProductoEntidades
    {
        [Key]
        public Guid ID_PRODUCTO { get; set; }
        public string PRODUCTO_NOMBRE { get; set; }
        public string PRODUCTO_DESCRIPCION { get; set; }
        public int PRODUCTO_CANTIDAD{ get; set; }
    }
}
