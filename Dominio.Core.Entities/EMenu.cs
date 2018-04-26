using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities{
    public class EMenu{
        public int idMenu { get; set; }
        public string Descripcion { get; set; }
        public int Padre_Id { get; set; }
        public int Posicion { get; set; }
        public String Icon { get; set; }
        public bool Habilitado { get; set; }
        public String Url { get; set; }
        public DateTime FechaCreacion { get; set; }
        public char UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public char UsuarioModificacion { get; set; }
        public EAplicacion oIdAplicacion { get; set; }
    }
}
