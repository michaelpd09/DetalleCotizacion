using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cotizacion.Models
{
    public class MCotizacion
    {
        [Key]

        public int CotizacionId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleCotizacion> Detalle { get; set; }

        public MCotizacion()
        {
            this.Detalle = new HashSet<DetalleCotizacion>();
        }
    }
}