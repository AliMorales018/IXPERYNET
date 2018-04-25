using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities
{
    public class EPerfil{
        public int idPerfil { get; set; }
        public EAplicacion oAplicacion { get; set; }
        public string Nombre  { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public EUser oUserC { get; set; }
        public DateTime FechaModifi { get; set; }
        public EUser oUserM { get; set; }
    }
}
