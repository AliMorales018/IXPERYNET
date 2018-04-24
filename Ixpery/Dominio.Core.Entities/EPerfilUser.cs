using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities{
    public class EPerfilUser{
        public int idPerfilUser {get;set;}
        public EPerfil oPerfil { get; set; }
        public EUser oUser { get; set; }
        public bool Estado { get; set; }
    }
}
