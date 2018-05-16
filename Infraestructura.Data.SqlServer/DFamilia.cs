using System;
using System.Collections.Generic;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;
using Utilitario;
using System.Xml.Linq;

namespace Infraestructura.Data.SqlServer
{
    public class DFamilia
    {
        //#region ATRIBUTOS DE APLICACION
        ///**NOMBRE TABLAS**/

        internal string nomTabFam { get => "TBC_FAMILIA"; }
        private List<string> lstFamReal = new List<string>();
        private List<string> lstFamAli = new List<string>();
        #region LISTA DE CAMPOS DEL DB
        private List<string> LstFamReal()
        {
            lstFamReal.Add("N_IdFamilia");
            lstFamReal.Add("V_NomFamilia");
            return lstFamReal;
        }
        public List<string> LstFamAli()
        {
            lstFamAli.Add("IdFamilia");
            lstFamAli.Add("NomFamilia");
            return lstFamAli;
        }
        public List<string> getListaFam()
        {
            return lstFamAli;
        }
        #endregion
        #region INSTANCIACIONES
        /**LLAMADOS A OTRAS CLASES**/
        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> listaParametros = new List<SqlParameter>();
        List<SqlParameter> lista = new List<SqlParameter>();
        DGeneral odGeneral = new DGeneral();
        XDocument xml = new XDocument();
        #endregion
        private void ListaFamilias(string famBuscar)
        {
            SqlParameter pValor = new SqlParameter("@valor", famBuscar);
            lista.Add(pValor);
        }
        public DataTable BuscarFamilia(string famBuscar)
        {
            ListaFamilias(famBuscar);
            try
            {
                return com.EjecutaConsulta("LOG_TBC_Familia_Buscar", lista, 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }
        #region VALIDACIONES
        /**VALIDACIONES DE LOS NOMBRES DE LAS TABLAS Y CAMPOS**/
        public DataSet ValidarDataSet(DataSet ds)
        {
            ds.Tables[0].TableName = nomTabFam;
            int numFilas = lstFamReal.Count;

            for (int i = 0; i < numFilas; i++)
            {
                ds.Tables[0].Columns[LstFamAli()[i]].ColumnName = lstFamReal[i];
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
            LstFamReal();
            string campos = string.Empty;
            List<string> camposTabla = new List<string>();
            for (int j = 1; j < lstFamReal.Count; ++j)
            {
                camposTabla.Add(lstFamReal[j]);
            }

            foreach (string campoLista in lista)
            {
                foreach (string campoTabla in camposTabla)
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
        #region MODIFICAR DATASET
        public DataSet FixDataSet(DataSet ds)
        {
            try
            {
                //LstEmplAli();
                LstFamReal();
                DataTable dtPos = new DataTable();
                DataTable prueba = new DataTable();
                prueba = ds.Tables[0];
                listaParametros.Clear();
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabFam);
                listaParametros.Add(pTabla);
                dtPos = com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
                int numero = Convert.ToInt32(dtPos.Rows[0][0].ToString());
                ds.Tables[0].Columns.Add(lstFamAli[0]).SetOrdinal(0);

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
        #region INSERTAR NUEVO REGISTRO EN FAMILIAS
        /**METODO INSERTAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void InsertarFamilia(DataSet ds)
        {
            try
            {
                List<SqlParameter> listParInsert = new List<SqlParameter>();
                SqlParameter pXml = new SqlParameter("@xml", Convert.ToString(odGeneral.generarXML(ValidarDataSet(FixDataSet(ds)))));
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
        #region MODIFICAR REGISTRO EXISTENTE EN APLICACION
        /**METODO MODIFICAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void ModificarFamilia(EFamilia oeFam, List<string> campos, string valores)
        {
            try
            {
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabFam);
                SqlParameter pId = new SqlParameter("@id", oeFam.idFamilia);
                SqlParameter pCampos = new SqlParameter("@campos", ValidarCampos(campos));
                SqlParameter pValores = new SqlParameter("@valores", valores);
                listaParametros.Add(pTabla); listaParametros.Add(pCampos); listaParametros.Add(pValores); listaParametros.Add(pId);
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
        #region MODIFICAR REGISTRO EXISTENTE EN APLICACION
        ///**METODO ACTUALIZAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        //public void ActualizarEmpleado(List<string> campos, string valores, int cod)
        //{
        //    try
        //    {
        //        SqlParameter pTabla = new SqlParameter("@tabla", nomTabFam);
        //        SqlParameter pId = new SqlParameter("@id", cod);
        //        SqlParameter pCampos = new SqlParameter("@campos", ValidarCampos(campos));
        //        SqlParameter pValores = new SqlParameter("@valores", valores);
        //        listaParametros.Add(pTabla); listaParametros.Add(pCampos); listaParametros.Add(pValores); listaParametros.Add(pId);
        //        com.TransUnica("GEN_ACTUALIZAR", listaParametros);
        //        listaParametros.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        com.DeshaceTransaccion();
        //        throw new Exception("DB - Error" + ex.Message, ex);
        //    }
        //}
        #endregion
        #region ELIMINAR REGISTRO EXISTENTE EN APLICACION
        /**METODO ELIMINAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void EliminarFamilia(EFamilia oFam)
        {
            try
            {
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabFam);
                SqlParameter pId = new SqlParameter("@id", oFam.idFamilia);
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
        public DataTable ListarFamilias()
        {
            listaParametros.Clear();
            SqlParameter pTabla = new SqlParameter("@tabla", nomTabFam);
            listaParametros.Add(pTabla);
            return com.EjecutaConsulta("GEN_LISTAR", listaParametros, 1);
        }
        #endregion

        #region BUSCAR REGISTROS DETERMINADOS EN APLICACION
        /**FUNCION BUSCAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public DataTable BuscarFamilias(List<string> campos, string valores)
        {
            listaParametros.Clear();
            SqlParameter pTabla = new SqlParameter("@tabla", nomTabFam);
            SqlParameter pCampos = new SqlParameter("@campos", ValidarCampos(campos));
            SqlParameter pValores = new SqlParameter("@valores", valores);
            listaParametros.Add(pTabla); listaParametros.Add(pCampos); listaParametros.Add(pValores);
            return com.EjecutaConsulta("GEN_FILTRAR", listaParametros, 1);
        }
        #endregion
    }
}
