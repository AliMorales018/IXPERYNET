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
	public class BMenuPerfil
	{
		DMenuPerfil odMePer = new DMenuPerfil();

		public List<string> LstMePerAli() {
			return odMePer.LstMePerAli();
		}

		public DataTable ConsultarMenuPerfApli(EMenuPerfil oeMePer)
		{
			return odMePer.ConsultarMenuPerfApli(oeMePer);
		}


	}
}
