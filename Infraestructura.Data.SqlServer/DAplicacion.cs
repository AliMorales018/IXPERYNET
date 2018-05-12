using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Dominio.Core.Entities;
using System.Xml.Linq;
using Utilitario;
using System.Data.SqlTypes;
using System.Xml;

namespace Infraestructura.Data.SqlServer
{
	public class DAplicacion
	{
		#region ATRIBUTOS DE APLICACION
		/**NOMBRE TABLA**/
		internal string tablaApli { get => "TBC_APLICACION"; }
		/**NOMBRE DE CAMPOS EN LA BASE DE DATOS**/
		internal string tIdApp { get => "N_IdApli"; }
		internal string tNomApp { get => "V_Aplicacion"; }
		internal string tEstApp { get => "S_Estado"; }
		internal string tVerApp { get => "N_Version"; }
		internal string tAbrApp { get => "V_Abreviatura"; }
		/**NOMBRE DE CAMPOS PARA LA PRESENTACION**/
		public string cIdApp { get => "IdApli"; }
		public string cNomApp { get => "Aplicacion"; }
		public string cEstApp { get => "Estado"; }
		public string cVerApp { get => "Version"; }
		public string cAbrApp { get => "Abreviatura"; }
		#endregion

		#region INSTANCIACIONES
		/**LLAMADOS A OTRAS CLASES**/
		DtUtilitario com = new DtUtilitario();
		List<SqlParameter> listaParametros = new List<SqlParameter>();
		DGeneral odGeneral = new DGeneral();
		XDocument xml = new XDocument();
		#endregion

		#region MODIFICAR DATASET
		public DataSet FixDataSet(DataSet ds)
		{
			try
			{
				DataTable dtPos = new DataTable();
				listaParametros.Clear();
				SqlParameter pTabla = new SqlParameter("@tabla", tablaApli);
				listaParametros.Add(pTabla);
				dtPos = com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
				int numero = Convert.ToInt32(dtPos.Rows[0][0].ToString());
				ds.Tables[0].Columns.Add("IdApli").SetOrdinal(0);

				for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
				{
					ds.Tables[0].Rows[i][0] = numero;
					++numero;
				}
				return ds;
			}
			catch (Exception ex)
			{
				com.DeshaceTransaccion();
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region VALIDACIONES
		/**VALIDACIONES DE LOS NOMBRES DE LAS TABLAS**/
		public DataSet ValidarDataSet(DataSet ds)
		{
			ds.Tables[0].TableName = tablaApli;
			ds.Tables[0].Columns[cIdApp].ColumnName = tIdApp;
			ds.Tables[0].Columns[cNomApp].ColumnName = tNomApp;
			ds.Tables[0].Columns[cEstApp].ColumnName = tEstApp;
			ds.Tables[0].Columns[cVerApp].ColumnName = tVerApp;
			ds.Tables[0].Columns[cAbrApp].ColumnName = tAbrApp;		
			if (ds.Tables.Count == 2)
			{
				//LLENAR SEGUN CASO
				//ds.Tables[1].TableName = "NOMBRE";
				//ds.Tables[1].Columns[""].ColumnName = "";
			}
			return ds;
		}
		/**VALIDACIONES DE LOS NOMBRES DE LOS CAMPOS**/
		public string ValidarCampos(List<string> lista)
		{
			string campos = string.Empty;		
			List<string> camposTabla = new List<string>();
			camposTabla.Add(tNomApp);
			camposTabla.Add(tEstApp);
			camposTabla.Add(tVerApp);
			camposTabla.Add(tAbrApp);
			foreach (string campoLista in lista)
			{
				foreach(string campoTabla in camposTabla)
				{
					if (campoLista.Equals(campoTabla.Substring(2)))
					{
						if (campos.Equals(string.Empty))
						{
							campos = campoTabla;
						}
						else
						{
							campos = campos + ";" + campoTabla;
						}
					}
				}
			}
			return campos;
		}
		#endregion

		#region INSERTAR NUEVO REGISTRO EN APLICACION
		/**METODO INSERTAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
		public void InsertarAplicacion(DataSet ds)
		{
			try
			{
				List<SqlParameter> listParInsert = new List<SqlParameter>();
				SqlParameter pXml = new SqlParameter("@xml", Convert.ToString(odGeneral.generarXML(ValidarDataSet(FixDataSet(ds)))));
				//SqlParameter pCampo = new SqlParameter("@campo", campo);
				//SqlParameter pSalid = new SqlParameter("@salida", salida);
				//pSalid.Direction = ParameterDirection.InputOutput;
				listParInsert.Add(pXml);
				//listaParametros.Add(pCampo);
				//listaParametros.Add(pSalid);
				com.TransUnica("GEN_INSERTAR_XML", listParInsert);
				//string a = Convert.ToString(pSalid.Value);
				listParInsert.Clear();
			}
			catch (Exception ex)
			{
				com.DeshaceTransaccion();
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region MODIFICAR REGISTRO EXISTENTE EN APLICACION
		/**METODO MODIFICAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
		public void ModificarAplicacion(EAplicacion oeApli, List<string> campos, string valores)
		{
			try
			{
				SqlParameter pTabla = new SqlParameter("@tabla", tablaApli);
				SqlParameter pId = new SqlParameter("@id", oeApli.idApli);
				SqlParameter pCampos = new SqlParameter("@campos", ValidarCampos(campos));
				SqlParameter pValores = new SqlParameter("@valores", valores);
				listaParametros.Add(pTabla); listaParametros.Add(pId); listaParametros.Add(pCampos); listaParametros.Add(pValores);
				com.TransUnica("GEN_ACTUALIZAR", listaParametros);
				listaParametros.Clear();
			}
			catch (Exception ex)
			{
				com.DeshaceTransaccion();
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region ELIMINAR REGISTRO EXISTENTE EN APLICACION
		/**METODO ELIMINAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
		public void EliminarAplicacion(EAplicacion oApli)
		{
			try
			{
				SqlParameter pTabla = new SqlParameter("@tabla", tablaApli);
				SqlParameter pId = new SqlParameter("@id", oApli.idApli);
				listaParametros.Add(pId); listaParametros.Add(pTabla);
				com.TransUnica("GEN_ELIMINAR", listaParametros);
				listaParametros.Clear();
			}
			catch (Exception ex)
			{
				com.DeshaceTransaccion();
				throw new Exception("DB - Error" + ex.Message, ex);
			}
		}
		#endregion

		#region LISTAR TODOS LOS REGISTROS EN APLICACION
		/**FUNCION LISTAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
		public DataTable ListarAplicaciones()
		{
			listaParametros.Clear();
			SqlParameter pTabla = new SqlParameter("@tabla", tablaApli);
			listaParametros.Add(pTabla);
			return com.EjecutaConsulta("GEN_LISTAR", listaParametros, 1);
		}
		#endregion

		#region BUSCAR REGISTROS DETERMINADOS EN APLICACION
		/**FUNCION BUSCAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
		public DataTable BuscarAplicacion(List<string> campos, string valores)
		{
			listaParametros.Clear();
			SqlParameter pTabla = new SqlParameter("@tabla", tablaApli);
			SqlParameter pCampos = new SqlParameter("@campos", ValidarCampos(campos));
			SqlParameter pValores = new SqlParameter("@valores", valores);
			listaParametros.Add(pTabla); listaParametros.Add(pCampos); listaParametros.Add(pValores);
			return com.EjecutaConsulta("GEN_FILTRAR", listaParametros, 1);
		}
		#endregion
	}
}
