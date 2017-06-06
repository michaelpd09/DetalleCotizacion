using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cotizacion.Models
{
    public class Cliente
    {
        [Key]

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
    }
}