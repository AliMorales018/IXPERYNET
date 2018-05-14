using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Utilitario;
namespace Infraestructura.Data.SqlServer
{
    public class DArea
    {
        #region ATRIBUTOS DE APLICACION
        /**NOMBRE TABLAS**/
        internal string nomTabArea { get => "TBC_AREA"; }
        /**NOMBRE DE CAMPOS EN LA BASE DE DATOS**/
        internal string idArea { get => "N_IdArea"; }
        internal string nombreArea { get => "V_Nombre"; }
        /**NOMBRE DE CAMPOS PARA LA PRESENTACION**/
        public string cIdArea { get => "IdArea"; }
        public string cNomArea { get => "NomArea"; }
        #endregion
        #region DECLARACION DE VARIABLES
        /****/
        private string campoUpd = "V_Nombre";
        #endregion
        #region INSTANCIACIONES
        /**LLAMADOS A OTRAS CLASES**/
        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> listaParametros = new List<SqlParameter>();
        List<SqlParameter> lista = new List<SqlParameter>();
        DGeneral odGeneral = new DGeneral();
        XDocument xml = new XDocument();
        #endregion
        private void ListaAreas(string areaBuscar)
        {
            //SqlParameter pCampo = new SqlParameter("@campo", nomCat);
            SqlParameter pValor = new SqlParameter("@valor", areaBuscar);
            //lista.Add(pCampo);
            lista.Add(pValor);
        }
        public DataTable BuscarArea(string areaBuscar)
        {

            ListaAreas(areaBuscar);
            try
            {
                return com.EjecutaConsulta("LOG_TBC_Area_Buscar", lista, 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }
        #region LLENAR COMBO AREAS
        public DataTable LlenarCombo()
        {
            try
            {
                DataTable dtprueba = new DataTable();
                dtprueba.Columns.Add("IdArea");
                dtprueba.Columns.Add("Nombre");

                dtprueba.Rows.Add(1, "area1");
                dtprueba.Rows.Add(2, "area2");
                dtprueba.Rows.Add(3, "area3");
                return dtprueba;
                //lista.Clear();
                //return com.EjecutaConsulta("LOG_TBC_AREA_LISTAR", lista, 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }
        #endregion
        #region VALIDACIONES
        /**VALIDACIONES DE LOS NOMBRES DE LAS TABLAS**/
        public DataSet ValidarDataSet(DataSet ds)
        {
            ds.Tables[0].TableName = nomTabArea;
            ds.Tables[0].Columns[cIdArea].ColumnName = idArea;
            ds.Tables[0].Columns[cNomArea].ColumnName = nombreArea;
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
            camposTabla.Add(nombreArea);
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
                DataTable dtPos = new DataTable();
                listaParametros.Clear();
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabArea);
                listaParametros.Add(pTabla);
                dtPos = com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
                int numero = Convert.ToInt32(dtPos.Rows[0][0].ToString());
                ds.Tables[0].Columns.Add("IdArea").SetOrdinal(0);

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
        #region INSERTAR NUEVO REGISTRO EN PRODUCTO
        /**METODO INSERTAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void InsertArea(DataSet ds)
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
        private void ListaParametros(int tipo, int idProd, string nomProd, int canProd, int idCat, int idUMed)
        {
            SqlParameter pNomTabla = new SqlParameter("@tabla", nomTabArea);//NOMBRE TABLA LOG.TBC_CATEGORIA @tabla
            SqlParameter pCampoEval = new SqlParameter("@campo", nombreArea);//NOMBRE DE LA COL BD NOMBRE DE LA CATEGORIA
            if (tipo == 1)//tipo 1:actualizar
            {
                string valores = nomProd + ";" + canProd + ";" + idCat + ";" + idUMed;
                SqlParameter pCampos = new SqlParameter("@campos", campoUpd);
                SqlParameter pValores = new SqlParameter("@valores", valores);
                SqlParameter pIdProd = new SqlParameter("@id", idProd);
                lista.Add(pNomTabla);
                lista.Add(pCampos);
                lista.Add(pValores);
                lista.Add(pIdProd);
            }
            else
            {
                SqlParameter pIdProd = new SqlParameter("@id", idProd);
                lista.Add(pIdProd);
                lista.Add(pNomTabla);
            }
        }
        #region MODIFICAR REGISTRO EXISTENTE EN PRODUCTO
        /**METODO MODIFICAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void UpdateArea(int idProd, string nomProd, int canProd, int idCat, int idUMed)
        {
            int tipo = 1;
            ListaParametros(tipo, idProd, nomProd, canProd, idCat, idUMed);
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
        public void DeleteArea(int idProd)
        {
            int tipo = 3;
            ListaParametros(tipo, idProd, "", 0, 0, 0);
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
    }
}
