using System;
using System.Collections.Generic;


using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Utilitario;


namespace Infraestructura.Data.SqlServer
{
    public class DCategoria
    {
        #region ATRIBUTOS DE APLICACION
        /**NOMBRE TABLAS**/
        internal string nomTabFam { get => "TBC_FAMILIA"; }
        internal string nomTabCat { get => "TBC_CATEGORIA"; }
        /**NOMBRE DE CAMPOS EN LA BASE DE DATOS**/
        internal string idCat { get => "N_IdCategoria"; }
        internal string nombreCat { get => "V_NomCategoria"; }//COL BD NOMBRE DE LA CATEGORIA
        internal string idFam { get => "N_IdFamilia"; }//COL BD IDFAMILIA(FK->FAMILIA)
        /**NOMBRE DE CAMPOS PARA LA PRESENTACION**/
        public string cIdCat { get => "IdCate"; }
        public string cNomCat { get => "NomCategoria"; }
        public string cIdFam { get => "IdFamilia"; }
        #endregion
        #region DECLARACION DE VARIABLES
        /****/
        private string campoUpd = "V_NomCategoria; N_IdFamilia";
        #endregion
        #region INSTANCIACIONES
        /**LLAMADOS A OTRAS CLASES**/
        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> listaParametros = new List<SqlParameter>();
        List<SqlParameter> lista = new List<SqlParameter>();
        DGeneral odGeneral = new DGeneral();
        XDocument xml = new XDocument();
        #endregion
        #region LLENAR COMBO CATEGORÍA
        public DataTable LlenarCombo()
        {
            try
            {
                lista.Clear();
                return com.EjecutaConsulta("LOG_TBC_CATEGORIA_LISTAR", lista, 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }
        #endregion
        #region LISTAPARAMETROS
        private void ListaCategorias(string catBuscar)
        {
            SqlParameter pValor = new SqlParameter("@valor", catBuscar);
            lista.Add(pValor);
        }
        public DataTable ListarCategoria()
        {
            try
            {
                lista.Clear();
                return com.EjecutaConsulta("LOG_TBC_CATEGORIA_LISTAR", lista, 1);
            }
            catch (Exception ex)
            {

                throw new Exception("Error" + ex.Message, ex);
            }
        }
        private void ListaParametros(int tipo, string nomCat, int idFam, int idCat)
        {
            SqlParameter pNomTabla = new SqlParameter("@tabla", nomTabCat);//NOMBRE TABLA LOG.TBC_CATEGORIA @tabla
            SqlParameter pCampoEval = new SqlParameter("@campo", nombreCat);//NOMBRE DE LA COL BD NOMBRE DE LA CATEGORIA
           if (tipo == 1)//tipo 1:actualizar
            {
                string valores = nomCat + ";" + idFam;
                SqlParameter pCampos = new SqlParameter("@campos", campoUpd);
                SqlParameter pValores = new SqlParameter("@valores", valores);
                SqlParameter pIdCat = new SqlParameter("@id", idCat);
                lista.Add(pNomTabla);
                lista.Add(pCampos);
                lista.Add(pValores);
                lista.Add(pIdCat);
            }
            else
            {
                SqlParameter pIdCat = new SqlParameter("@id", idCat);
                lista.Add(pIdCat);
                lista.Add(pNomTabla);
            }
        }
        #endregion
        #region VALIDACIONES
        /**VALIDACIONES DE LOS NOMBRES DE LAS TABLAS**/
        public DataSet ValidarDataSet(DataSet ds)
        {
            ds.Tables[0].TableName = nomTabCat;
            ds.Tables[0].Columns[cIdCat].ColumnName = idCat;
            ds.Tables[0].Columns[cNomCat].ColumnName = nombreCat;
            ds.Tables[0].Columns[cIdFam].ColumnName = idFam;
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
            camposTabla.Add(nombreCat);
            camposTabla.Add(idFam);
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
        #region INSERTAR NUEVO REGISTRO EN CATEGORÍA
        /**METODO INSERTAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void InsertCategoria(DataSet ds)
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
                com.TransUnica("GEN_INSERTAR_XML_CON_ID", listParInsert);
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
        #region MODIFICAR DATASET
        public DataSet FixDataSet(DataSet ds)
        {
            try
            {
                DataTable dtPos = new DataTable();
                listaParametros.Clear();
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabCat);
                listaParametros.Add(pTabla);
                dtPos = com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
                int numero = Convert.ToInt32(dtPos.Rows[0][0].ToString());
                ds.Tables[0].Columns.Add("IdCate").SetOrdinal(0);

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
        #region MODIFICAR REGISTRO EXISTENTE EN CATEGORÍA
        /**METODO MODIFICAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void UpdateCategoria(string nomCat, int idFam, int idCat)
        {
            int tipo = 1;
            ListaParametros(tipo, nomCat, idFam, idCat);
            try
            {
                com.TransUnica("GEN_ACTUALIZAR", lista);
            }
            catch (Exception ex)
            {
                com.DeshaceTransaccion();
                throw new Exception(ex.Message, ex);
            }
            lista.Clear();
        }
        #endregion
        #region ELIMINAR REGISTRO EXISTENTE EN CATEGORÍA
        /**METODO ELIMINAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void DeleteCategoria(int idCat)
        {
            int tipo = 3;
            ListaParametros(tipo, "", 0, idCat);
            try
            {
                com.TransUnica("GEN_ELIMINAR", lista);
                lista.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region BUSCAR REGISTROS DETERMINADOS EN CATEGORÍA
        /**FUNCION BUSCAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public DataTable BuscarCategoria(string catBuscar)
        {

            ListaCategorias(catBuscar);
            try
            {
                return com.EjecutaConsulta("LOG_TBC_Categoria_Buscar", lista, 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }
        #endregion
    }
}

