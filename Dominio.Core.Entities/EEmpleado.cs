using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities
{
    public class EEmpleado
    {
        public int idEmpleado { get; set; }
        public EArea oArea { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }
        public byte Sexo { get; set; }
        public bool Estado { get; set; }
    }
}
