using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities
{
    public class EPerfil{
        public EMenuPerfil oMenuPerfil { get; set; }
        public EMenu oMenu { get; set; }
        public EPerfil oPerfil { get; set; }
        public bool Visible { get; set; }
        public bool Estado { get; set; }
    }
}
