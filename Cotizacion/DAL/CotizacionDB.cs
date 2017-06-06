using Cotizacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cotizacion.DAL
{
    public class CotizacionDB: DbContext
    {
        public CotizacionDB(): base("ConStr")
        {

        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<MCotizacion> Cotizacion { get; set; }
        public virtual DbSet<DetalleCotizacion> DetalleCotizacion { get; set; }


    }
}