using Cotizacion.DAL;
using Cotizacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizacion.BLL
{
    public class ClienteBLL
    {
        public static bool Guardar(Cliente cliente)
        {
            bool retorno = false;
            try
            {
                var db = new CotizacionDB();
                db.Cliente.Add(cliente);
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