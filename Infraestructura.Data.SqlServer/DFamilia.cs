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
        #region ATRIBUTOS DE APLICACION
        /**NOMBRE TABLAS**/
        internal string nomTab { get => "TBC_FAMILIA"; }
        /**NOMBRE DE CAMPOS EN LA BASE DE DATOS**/
        internal string idFam { get => "N_IdFamilia"; }
        internal string nomFam { get => "V_NomFamilia"; }//COL BD NOMBRE DE LA CATEGORIA
        /**NOMBRE DE CAMPOS PARA LA PRESENTACION**/
        public string cIdFam { get => "IdFami"; }
        public string cNomFam { get => "NomFamilia"; }
        #endregion
        #region DECLARACIÓN DE VARIABLES
        private string campoUpd = "V_NomFamilia";
        #endregion
        #region INSTANCIACIONES
        /**LLAMADOS A OTRAS CLASES**/
        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> listaParametros = new List<SqlParameter>();
        List<SqlParameter> lista = new List<SqlParameter>();
        DGeneral odGeneral = new DGeneral();
        XDocument xml = new XDocument();
        #endregion
        #region LISTAPARAMETROS
        private void ListaFamilias(string famBuscar)
        {
            SqlParameter pValor = new SqlParameter("@valor", famBuscar);
            lista.Add(pValor);
        }
        private void ListaParametros(int tipo,int idFam, string nFam)
        {
            SqlParameter pNomTabla = new SqlParameter("@tabla", nomTab);//NOMBRE TABLA LOG.TBC_CATEGORIA @tabla
            SqlParameter pCampoEval = new SqlParameter("@campo", nomFam);//NOMBRE DE LA COL BD NOMBRE DE LA CATEGORIA
            if (tipo == 1)//tipo 1:actualizar
            {
                string valores = nFam;
                SqlParameter pCampos = new SqlParameter("@campos", campoUpd);
                SqlParameter pValores = new SqlParameter("@valores", valores);
                SqlParameter pIdFam = new SqlParameter("@id", idFam);
                lista.Add(pNomTabla);
                lista.Add(pCampos);
                lista.Add(pValores);
                lista.Add(pIdFam);
            }
            else
            {
                SqlParameter pIdFam = new SqlParameter("@id", idFam);
                lista.Add(pIdFam);
                lista.Add(pNomTabla);
            }
        }
        #endregion
        #region BUSCAR REGISTROS DETERMINADOS EN FAMILIA
        /**FUNCION BUSCAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public DataTable BuscarFamilia(string famBuscar)
        {

            ListaFamilias(famBuscar);
            try
            {
                return com.EjecutaConsulta("LOG_TBC_FAMILIA_BUSCAR", lista, 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }
        #endregion

        private void LlenarObj(EFamilia oFam)
        {
            //SqlParameter id = new SqlParameter("@IdFamilia", oFam.idFamilia);
            SqlParameter nombre = new SqlParameter("@NomFamilia", oFam.nomFamilia);
            //lista.Add(id); 
            lista.Add(nombre);
        }
        #region MODIFICAR DATASET
        public DataSet FixDataSet(DataSet ds)
        {
            try
            {
                DataTable dtPos = new DataTable();
                listaParametros.Clear();
                SqlParameter pTabla = new SqlParameter("@tabla", nomTab);
                listaParametros.Add(pTabla);
                dtPos = com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
                int numero = Convert.ToInt32(dtPos.Rows[0][0].ToString());
                ds.Tables[0].Columns.Add("IdFami").SetOrdinal(0);

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
            ds.Tables[0].TableName = nomTab;
            ds.Tables[0].Columns[cIdFam].ColumnName = idFam;
            ds.Tables[0].Columns[cNomFam].ColumnName = nomFam;
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
            camposTabla.Add(nomFam);
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
        public void InsertFamilia(DataSet ds)
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
        #region MODIFICAR REGISTRO EXISTENTE EN FAMILIA
        /**METODO MODIFICAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void UpdateFamilia(int idFam, string nomFam)
        {
            int tipo = 1;
            ListaParametros(tipo,idFam, nomFam);
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
        public void DeleteFamilia(int idFam)
        {
            int tipo = 3;
            ListaParametros(tipo,idFam,"");
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
        public DataTable LlenarCombo()
        {
            try
            {
                lista.Clear();
                return com.EjecutaConsulta("LOG_TBC_Familia_Listar",lista,1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }

        public DataTable ListarFamilia()
        {
            try
            {
                lista.Clear();
                return com.EjecutaConsulta("LOG_TBC_FAMILIA_LISTAR", lista, 1);
            }
            catch (Exception ex)
            {

                throw new Exception("Error" + ex.Message,ex);
            }
        }

    }
}
