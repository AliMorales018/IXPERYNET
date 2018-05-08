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

		public string perValue()
		{
			return odMenu.perValue;
		}

		public string perText()
		{
			return odMenu.perText;
		}

		public string KeyMember()
		{
			return odMenu.KeyMember;
		}

		public string DisplayMember()
		{
			return odMenu.DisplayMember;
		}

		public string ValueMember()
		{
			return odMenu.ValueMember;
		}

		public string ParentMember()
		{
			return odMenu.ParentMember;
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
