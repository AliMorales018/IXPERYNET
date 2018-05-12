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
		DAplicacion odApli = new DAplicacion();

		#region ATRIBUTOS
		/**LLAMADO DE LOS ATRIBUTOS EN LA CAPA DE DATOS**/
		public string ApliValue()
		{
			return odApli.cIdApp;
		}

		public string ApliText()
		{
			return odApli.cNomApp;
		}
		#endregion

		#region METODOS
		/**LLAMADO DE LOS METODOS EN LA CAPA DE DATOS**/
		public void Insertar(DataSet ds)
		{
			odApli.InsertarAplicacion(ds);
		}

		public void Modificar(EAplicacion oeApli, List<string> campos, string valores)
		{
			odApli.ModificarAplicacion(oeApli, campos, valores);
		}

		public void Eliminar(EAplicacion oeApli)
		{
			odApli.EliminarAplicacion(oeApli);
		}
		#endregion

		#region FUNCIONES
		/**LLAMADO DE LAS FUNCIONES EN LA CAPA DE DATOS**/
		public DataTable Listar()
		{
			return odApli.ListarAplicaciones();
		}

		public DataTable Buscar(List<string> campos, string valores)
		{
			return odApli.BuscarAplicacion(campos, valores);
		}
		#endregion

	}
}
