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
	public class DMenu
	{
		//public string perValue { get => "ID"; }
		//public string perText { get => "PERFIL"; }

		//public string KeyMember { get => "N_IdMenu"; }
		//public string DisplayMember { get => "V_descripcion"; }
		//public string ValueMember { get => "N_IdMenu"; }
		//public string ParentMember { get => "N_IdPadre"; }

		//private string tablaMePer { get => "TBD_MENUPERFIL"; }

		#region Atributos Menu
		internal string tablaMenu { get => "TBC_MENU"; }
		#endregion

		#region Listas de campos en tabla
		/**LISTA SIN ALIAS**/
		private List<string> lstMenuReal = new List<string>();
		/**LISTA CON ALIAS**/
		private List<string> lstMenuAli = new List<string>();
		#endregion
		
		
		#region Lleando de lista sin alias
		private void LlenarMenuRe()
		{
			lstMenuReal.Add("N_IdMenu");
			lstMenuReal.Add("V_Descripcion");
			lstMenuReal.Add("N_IdPadre");
			lstMenuReal.Add("N_Posicion");
			lstMenuReal.Add("V_Icono");
			lstMenuReal.Add("S_Habilitado");
			lstMenuReal.Add("V_Url");
			lstMenuReal.Add("N_IdApli");
		}
		#endregion

		#region Llenado de lista con alias
		public void LlenarMenuAl()
		{
			lstMenuAli.Add("IdMenu");
			lstMenuAli.Add("Descripcion");
			lstMenuAli.Add("IdPadre");
			lstMenuAli.Add("Posicion");
			lstMenuAli.Add("Icono");
			lstMenuAli.Add("Habilitado");
			lstMenuAli.Add("Url");
			lstMenuAli.Add("IdApli");
		}
		#endregion

		public List<string> getMenuAl()
		{
			return lstMenuAli;
		}

		DtUtilitario com = new DtUtilitario();
		List<SqlParameter> listaParametros = new List<SqlParameter>();
		DGeneral odGeneral = new DGeneral();

		#region VALIDACIONES
		/**VALIDACIONES DE LOS NOMBRES DE LAS TABLAS Y CAMPOS**/
		public DataSet ValidarDataSet(DataSet ds)
		{
			LlenarMenuRe();
			ds.Tables[0].TableName = tablaMenu;
			int numFilas = lstMenuReal.Count;

			for (int i = 0; i < numFilas; i++)
			{
				ds.Tables[0].Columns[lstMenuAli[i]].ColumnName = lstMenuReal[i];
			}
			if (ds.Tables.Count == 2)
			{
				//LLENAR SEGUN CASO
				//ds.Tables[1].TableName = "NOMBRE";
				//ds.Tables[1].Columns[""].ColumnName = "";
			}
			return ds;
		}
		#endregion

		#region INSERTAR NUEVA LISTA DE MENUES
		/**METODO INSERTAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
		public void InsertarMenu(DataSet ds)
		{
			try
			{
				List<SqlParameter> listParInsert = new List<SqlParameter>();
				com.TransUnica("XXX_MENUPERFIL_MENU_ELIMINAR", listParInsert);
				SqlParameter pXml = new SqlParameter("@xml", Convert.ToString(odGeneral.generarXML(ValidarDataSet(ds))));
				SqlParameter pSalid = new SqlParameter("@salida", "");
				pSalid.Direction = ParameterDirection.InputOutput;
				pSalid.Size = 50;
				//SqlParameter pCampo = new SqlParameter("@campo", campo);
				listParInsert.Add(pXml);
				listParInsert.Add(pSalid);
				//listaParametros.Add(pCampo);
				com.TransUnica("GEN_INSERTAR_XML_CON_ID", listParInsert);
				string retorno = Convert.ToString(pSalid.Value);
				listParInsert.Clear();
			}
			catch (Exception ex)
			{
				com.DeshaceTransaccion();
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}

		#endregion



		#region RECUPERAR ID DEL ULTIMO REGISTRO
		public int SigMenuId()
		{
			DataTable dt = new DataTable();
			listaParametros.Clear();
			SqlParameter pTabla = new SqlParameter("@tabla", tablaMenu);
			listaParametros.Add(pTabla);
			dt= com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
			return Convert.ToInt32(dt.Rows[0][0]);
		}
		#endregion

		#region Buscar todos los menues por perfil de cada aplicación
		public DataTable DataSource(EAplicacion oeApli, EPerfil oePerfil)
		{
			try
			{
				listaParametros.Clear();
				SqlParameter idApli = new SqlParameter("@idapli", oeApli.idApli);
				SqlParameter idPerfil = new SqlParameter("@idperfil", oePerfil.idPerfil);
				listaParametros.Add(idApli); listaParametros.Add(idPerfil);
				return com.EjecutaConsulta("XXX_APLICACION_PERFIL_MENU_LISTAR", listaParametros, 1);
			}
			catch (Exception ex)
			{
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region Actualizar permisos de menues por perfil
		public void ActualizarMenuPerfil(EPerfil oePerfil, string lista)
		{
			try
			{
				SqlParameter cadena = new SqlParameter("@lista", lista);
				SqlParameter idPerfil = new SqlParameter("@idperfil", oePerfil.idPerfil);
				listaParametros.Add(cadena); listaParametros.Add(idPerfil);
				com.TransUnica("XXX_TBD_ActualizarMenuDePerfil", listaParametros);
				listaParametros.Clear();
			}
			catch (Exception ex)
			{
				com.DeshaceTransaccion();
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region Listar todos los perfiles de cada aplicación
		public DataTable ListarPerfilApli(EAplicacion oeApli)
		{
			try
			{
				listaParametros.Clear();
				SqlParameter idApli = new SqlParameter("@idaplicacion", oeApli.idApli);
				listaParametros.Add(idApli);
				return com.EjecutaConsulta("XXX_TBC_PerfilAplicacion", listaParametros, 1);
			}
			catch (Exception ex)
			{
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion
	}
}
