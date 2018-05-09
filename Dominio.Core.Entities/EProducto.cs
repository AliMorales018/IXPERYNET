using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities
{
   public class EProducto
    {
        public int IdProducto { get; set; }
        public string NomProducto { get; set; }
        public int CantProducto { get; set; }
        public int IdCategoria { get; set; }
        public int IdUnidMedida { get; set; }
    }
}
