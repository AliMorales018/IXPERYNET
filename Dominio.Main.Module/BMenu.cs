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

		public void LlenarMenuAl()
		{
			odMenu.LlenarMenuAl();
		}

		public List<string> getMenuAl()
		{
			return odMenu.getMenuAl();
		}

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
			return odMenu.getMenuAl()[0];
		}

		public string DisplayMember()
		{
			return odMenu.getMenuAl()[1];
		}

		public string ValueMember()
		{
			return odMenu.getMenuAl()[0];
		}

		public string ParentMember()
		{
			return odMenu.getMenuAl()[2];
		}
		
		public int SigMenuId()
		{
			return odMenu.SigMenuId();
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

		public void InsertarMenu(DataSet ds)
		{
			odMenu.InsertarMenu(ds);
		}
	}
}
