using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities{
    public class EMenu{
		public int idMenu { get; set; }
		public string Descripcion { get; set; }
		public int IdPadre { get; set; }
		public int Posicion { get; set; }
		public String Icon { get; set; }
		public bool Habilitado { get; set; }
		public String Url { get; set; }
		public EAplicacion oIdApli { get; set; }
	}
}
