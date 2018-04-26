using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities {
    public class EUser {
        public int idUsuario { get; set; }
        public String Login { get; set; }
        public String Nombres { get; set; }
        public String Paterno { get; set; }
        public String Materno { get; set; }
        public bool Estado { get; set; }
        public String CLave { get; set; }
        public String idPersonal { get; set; }
    }
}
