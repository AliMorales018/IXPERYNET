using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Dominio.Core.Entities;
using Infraestructura.Data.SqlServer;

namespace Dominio.Main.Module
{
	public class BAplicacion
	{
		DAplicacion oDApli = new DAplicacion();

		public string ApliValue()
		{
			return oDApli.apliValue;
		}

		public string ApliText()
		{
			return oDApli.apliText;
		}

		public void InsertarAplicacion(EAplicacion oEApli)
		{
			oDApli.InsertarAplicacion(oEApli);
		}

		public void ModificarAplicacion(EAplicacion oEApli)
		{
			oDApli.ModificarAplicacion(oEApli);
		}

		public void EliminarAplicacion(EAplicacion oEApli)
		{
			oDApli.EliminarAplicacion(oEApli);
		}

		public DataTable ListarAplicaciones()
		{
			return oDApli.ListarAplicaciones();
		}

		public DataTable BuscarAplicacion(EAplicacion oEApli, string campo, string valor)
		{
			return oDApli.BuscarAplicacion(oEApli, campo, valor);
		}
	}
}
