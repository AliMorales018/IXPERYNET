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
	public class BMenu
	{
		DMenu odMenu = new DMenu();
		DPerfil odPerfil = new DPerfil();

		public string perValue()
		{
			return odPerfil.cIdPer;
		}

		public string perText()
		{
			return odPerfil.cNomPer;
		}

		public string KeyMember()
		{
			return odMenu.cIdMen;
		}

		public string DisplayMember()
		{
			return odMenu.cDesMen;
		}

		public string ValueMember()
		{
			return odMenu.cIdMen;
		}

		public string ParentMember()
		{
			return odMenu.cIdPadMen;
		}

		public DataTable DataSource(EAplicacion oeApli, EPerfil oePerfil)
		{
			return odMenu.DataSource(oeApli, oePerfil);
		}

		public void ActualizarMenuPerfil(EPerfil oePerfil, string lista)
		{
			odMenu.ActualizarMenuPerfil(oePerfil, lista);
		}

		public DataTable ListarPerfilApli(EAplicacion oeApli)
		{
			return odMenu.ListarPerfilApli(oeApli);
		}
	}
}
