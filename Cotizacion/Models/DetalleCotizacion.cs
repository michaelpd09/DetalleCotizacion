using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cotizacion.Models
{
    public class DetalleCotizacion
    {
        [Key]

        public int DetalleCotizacionId { get; set; }
        public int CotizacionId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual MCotizacion Cotizacion { get; set; }

        public DetalleCotizacion()
        {

        }
    }
}