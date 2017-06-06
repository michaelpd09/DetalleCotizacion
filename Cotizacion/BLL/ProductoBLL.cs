using Cotizacion.DAL;
using Cotizacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizacion.BLL
{
    public class ProductoBLL
    {
        public static bool Guardar(Producto producto)
        {
            bool retorno = false;
            try
            {
                var db = new CotizacionDB();
                db.Producto.Add(producto);
                db.SaveChanges();
                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }
    }
}