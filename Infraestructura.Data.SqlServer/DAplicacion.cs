using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Dominio.Core.Entities;
using Utilitario;

namespace Infraestructura.Data.SqlServer
{
	public class DAplicacion
	{
		#region Atributos
		private string nombreTabla { get => "XXX.TBC_APLICACION"; }
		public string apliValue { get => "N_IdApli"; }
		public string apliText { get => "V_Aplicacion"; }
		#endregion

		#region Instanciaciones
		DtUtilitario com = new DtUtilitario();
		List<SqlParameter> listaParametros = new List<SqlParameter>();
		#endregion

		#region Llenar lista completa con todos los parámetros
		private void LlenarListaCompleta(EAplicacion oApli)
		{
			SqlParameter idApli = new SqlParameter("@IdApli", oApli.idApli);
			SqlParameter aplicacion = new SqlParameter("@Aplicacion", oApli.Aplicacion);
			SqlParameter estado = new SqlParameter("@Estado", oApli.Estado);
			SqlParameter version = new SqlParameter("@Version", oApli.Version);
			SqlParameter abreviatura = new SqlParameter("@Abreviatura", oApli.Abreviatura);
			listaParametros.Add(idApli); listaParametros.Add(aplicacion); listaParametros.Add(estado); listaParametros.Add(version); listaParametros.Add(abreviatura);
		}
		#endregion

		#region Insertar registro en tabla
		public void InsertarAplicacion(EAplicacion oApli)
		{
			try
			{
				LlenarListaCompleta(oApli);
				com.TransUnica("", listaParametros);
				listaParametros.Clear();
			}
			catch (Exception ex)
			{
				com.DeshaceTransaccion();
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region Modificar registro en tabla
		public void ModificarAplicacion(EAplicacion oApli)
		{
			try
			{
				LlenarListaCompleta(oApli);
				com.TransUnica("", listaParametros);
				listaParametros.Clear();
			}
			catch (Exception ex)
			{
				com.DeshaceTransaccion();
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region Eliminar registro en tabla
		public void EliminarAplicacion(EAplicacion oApli)
		{
			try
			{
				SqlParameter id = new SqlParameter("@IdApli", oApli.idApli);
				listaParametros.Add(id);
				com.TransUnica("", listaParametros);
				listaParametros.Clear();
			}
			catch (Exception ex)
			{
				com.DeshaceTransaccion();
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region Listar registros de la tabla
		public DataTable ListarAplicaciones()
		{
			SqlParameter tabla = new SqlParameter("@tabla", nombreTabla);
			listaParametros.Add(tabla);
			return com.EjecutaConsulta("LOG_TBC_APLICACION_LISTAR", listaParametros, 0);
		}
		#endregion

		#region
		public DataTable BuscarAplicacion(EAplicacion oApli, string pCampo, string pValor)
		{
			SqlParameter valor = new SqlParameter("@valor", pValor);
			SqlParameter campo = new SqlParameter("@campo", pCampo);
			SqlParameter tabla = new SqlParameter("@tabla", nombreTabla);
			listaParametros.Add(valor); listaParametros.Add(campo); listaParametros.Add(tabla);
			return com.EjecutaConsulta("X_XTBC_Buscar", listaParametros, 1);
		}
		#endregion
	}
}
