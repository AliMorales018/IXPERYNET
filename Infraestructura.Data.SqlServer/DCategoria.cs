using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;
using Utilitario;
using System.Xml.Linq;

namespace Infraestructura.Data.SqlServer
{
    public class DCategoria
    {
        //#region ATRIBUTOS DE APLICACION
        ///**NOMBRE TABLAS**/

        internal string nomTabCate { get => "TBC_CATEGORIA"; }
        private List<string> lstCateReal = new List<string>();
        private List<string> lstCateAli = new List<string>();
        #region LISTA DE CAMPOS DEL DB
        private List<string> LstCateReal()
        {
            lstCateReal.Add("N_IdCategoria");
            lstCateReal.Add("V_NomCategoria");
            lstCateReal.Add("N_IdFamilia");
            return lstCateReal;
        }
        public List<string> LstCateAli()
        {
            lstCateAli.Add("IdCategoria");
            lstCateAli.Add("NomCategoria");
            lstCateAli.Add("IdFamilia");
            return lstCateAli;
        }
        public List<string> getListaCate()
        {
            return lstCateAli;
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
        private void ListaCategorias(string cateBuscar)
        {
            SqlParameter pValor = new SqlParameter("@valor", cateBuscar);
            lista.Add(pValor);
        }
        public DataTable BuscarCategoria(string cateBuscar)
        {
            ListaCategorias(cateBuscar);
            try
            {
                return com.EjecutaConsulta("LOG_TBC_Categoria_Buscar", lista, 1);
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
            ds.Tables[0].TableName = nomTabCate;
            int numFilas = lstCateReal.Count;

            for (int i = 0; i < numFilas; i++)
            {
                ds.Tables[0].Columns[LstCateAli()[i]].ColumnName = lstCateReal[i];
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
            LstCateReal();
            string campos = string.Empty;
            List<string> camposTabla = new List<string>();
            for (int j = 1; j < lstCateReal.Count; ++j)
            {
                camposTabla.Add(lstCateReal[j]);
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
                LstCateReal();
                DataTable dtPos = new DataTable();
                DataTable prueba = new DataTable();
                prueba = ds.Tables[0];
                listaParametros.Clear();
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabCate);
                listaParametros.Add(pTabla);
                dtPos = com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
                int numero = Convert.ToInt32(dtPos.Rows[0][0].ToString());
                ds.Tables[0].Columns.Add(lstCateAli[0]).SetOrdinal(0);

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
        #region INSERTAR NUEVO REGISTRO EN EMPLEADO
        /**METODO INSERTAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void InsertarCategoria(DataSet ds)
        {
            try
            {
                List<SqlParameter> listParInsert = new List<SqlParameter>();
                SqlParameter pXml = new SqlParameter("@xml", Convert.ToString(odGeneral.generarXML(ValidarDataSet(FixDataSet(ds)))));
                SqlParameter pSalid = new SqlParameter("@salida", "");
                pSalid.Direction = ParameterDirection.InputOutput;
                pSalid.Size = 50;
                listParInsert.Add(pXml);
                listParInsert.Add(pSalid);
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
        #region MODIFICAR REGISTRO EXISTENTE EN CATEGORIA
        /**METODO MODIFICAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void ModificarCategoria(ECategoria oeCate, List<string> campos, string valores)
        {
            try
            {
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabCate);
                SqlParameter pId = new SqlParameter("@id", oeCate.idCategoria);
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
        #region MODIFICAR REGISTRO EXISTENTE EN APLICACION
        ///**METODO ACTUALIZAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        //public void ActualizarEmpleado(List<string> campos, string valores, int cod)
        //{
        //    try
        //    {
        //        SqlParameter pTabla = new SqlParameter("@tabla", nomTabEmpl);
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
        public void EliminarCategoria(ECategoria oeCate)
        {
            try
            {
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabCate);
                SqlParameter pId = new SqlParameter("@id", oeCate.idCategoria);
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
        public DataTable ListarCategoria()
        {
            listaParametros.Clear();
            SqlParameter pTabla = new SqlParameter("@tabla", nomTabCate);
            listaParametros.Add(pTabla);
            return com.EjecutaConsulta("GEN_LISTAR", listaParametros, 1);
        }
        #endregion

        #region BUSCAR REGISTROS DETERMINADOS EN APLICACION
        /**FUNCION BUSCAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public DataTable BuscarCategorias(List<string> campos, string valores)
        {
            listaParametros.Clear();
            SqlParameter pTabla = new SqlParameter("@tabla", nomTabCate);
            SqlParameter pCampos = new SqlParameter("@campos", ValidarCampos(campos));
            SqlParameter pValores = new SqlParameter("@valores", valores);
            listaParametros.Add(pTabla); listaParametros.Add(pCampos); listaParametros.Add(pValores);
            return com.EjecutaConsulta("GEN_FILTRAR", listaParametros, 1);
        }
        #endregion
    }
}

