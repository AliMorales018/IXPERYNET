using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities{
    public class EAplicacion{
        public int idApli { get; set; }
        public string Aplicacion { get; set; }
        public bool Estado { get; set; }
        public string Version { get; set; }
        public string Abreviatura { get; set; }
    }
}
//Fin