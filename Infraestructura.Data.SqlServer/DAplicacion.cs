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
		#endregion

		#region INSTANCIACIONES
		/**LLAMADOS A OTRAS CLASES**/
		DtUtilitario com = new DtUtilitario();
		List<SqlParameter> listaParametros = new List<SqlParameter>();
		private List<string> lstAppReal = new List<string>();
		public List<string> lstAppAli = new List<string>();
		DGeneral odGeneral = new DGeneral();
		XDocument xml = new XDocument();
		#endregion

		#region LISTA DE CAMPOS DEL DB
		private List<string> LstAppReal()
		{
			/*
			lstAppReal[0] = "N_IdApli";
			lstAppReal[1] = "V_Aplicacion";
			lstAppReal[2] = "S_Estado";
			lstAppReal[3] = "N_Version";
			lstAppReal[4] = "V_Abreviatura";
			*/
			lstAppReal.Add("N_IdApli");
			lstAppReal.Add("V_Aplicacion");
			lstAppReal.Add("S_Estado");
			lstAppReal.Add("N_Version");
			lstAppReal.Add("V_Abreviatura");
			return lstAppReal;
		}
		#endregion

		#region LISTA DE CAMPOS CON ALIAS DEL DB
		private List<string> LstAppAli()
		{
			/*
			lstAppAli[0]. = "IdApli";
			lstAppAli[1] = "Aplicacion";
			lstAppAli[2] = "Estado";
			lstAppAli[3] = "Version";
			lstAppAli[4] = "Abreviatura";
			*/
			lstAppAli.Add("IdApli");
			lstAppAli.Add("Aplicacion");
			lstAppAli.Add("Estado");
			lstAppAli.Add("Version");
			lstAppAli.Add("Abreviatura");


			return lstAppAli;
		}
		#endregion

		#region MODIFICAR DATASET
		public DataSet FixDataSet(DataSet ds)
		{
			try
			{
				LstAppAli();
				LstAppReal();
				DataTable dtPos = new DataTable();
				DataTable prueba = new DataTable();
				prueba = ds.Tables[0];
				listaParametros.Clear();
				SqlParameter pTabla = new SqlParameter("@tabla", tablaApli);
				listaParametros.Add(pTabla);
				dtPos = com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
				int numero = Convert.ToInt32(dtPos.Rows[0][0].ToString());
				ds.Tables[0].Columns.Add(lstAppAli[0]).SetOrdinal(0);

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
		/**VALIDACIONES DE LOS NOMBRES DE LAS TABLAS Y CAMPOS**/
		public DataSet ValidarDataSet(DataSet ds)
		{
			ds.Tables[0].TableName = tablaApli;
			int numFilas = lstAppReal.Count;

			for (int i = 0; i < numFilas; i++)
			{
				ds.Tables[0].Columns[LstAppAli()[i]].ColumnName = lstAppReal[i];
			}
			if (ds.Tables.Count == 2)
			{
				//LLENAR SEGUN CASO
				//ds.Tables[1].TableName = "NOMBRE";
				//ds.Tables[1].Columns[""].ColumnName = "";
			}
			return ds;
		}
		/**VALIDACIONES DE LISTAS**/
		public string ValidarCampos(List<string> lista)
		{
			string campos = string.Empty;		
			List<string> camposTabla = new List<string>();
			for (int j = 1; j < lstAppReal.Count; ++j)
			{
				camposTabla.Add(lstAppReal[j]);
			}

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
				SqlParameter pSalid = new SqlParameter("@salid", "");
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
