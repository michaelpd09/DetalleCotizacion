using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cotizacion.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    }
}