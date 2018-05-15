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
    public class DEmpleado
    {
        //#region ATRIBUTOS DE APLICACION
        ///**NOMBRE TABLAS**/

        internal string nomTabEmpl { get => "TBC_EMPLEADO"; }
        private List<string> lstEmplReal = new List<string>();
        private List<string> lstEmplAli = new List<string>();
        #region LISTA DE CAMPOS DEL DB
        private List<string> LstEmplReal()
        {
            lstEmplReal.Add("N_IdEmpleado");
            lstEmplReal.Add("N_IdArea");
            lstEmplReal.Add("C_Dni");
            lstEmplReal.Add("V_Nombre");
            lstEmplReal.Add("V_ApellidoPaterno");
            lstEmplReal.Add("V_ApellidoMaterno");
            lstEmplReal.Add("C_Telefono");
            lstEmplReal.Add("V_Direccion");
            lstEmplReal.Add("D_FechaNac");
            lstEmplReal.Add("C_Sexo");
            lstEmplReal.Add("S_Estado");
            return lstEmplReal;
        }
        public List<string> LstEmplAli()
        {
            lstEmplAli.Add("IdEmpleado");
            lstEmplAli.Add("IdArea");
            lstEmplAli.Add("Dni");
            lstEmplAli.Add("Nombre");
            lstEmplAli.Add("ApellidoPaterno");
            lstEmplAli.Add("ApellidoMaterno");
            lstEmplAli.Add("Telefono");
            lstEmplAli.Add("Direccion");
            lstEmplAli.Add("FechaNac");
            lstEmplAli.Add("Sexo");
            lstEmplAli.Add("Estado");
            return lstEmplAli;
        }
        public List<string> getListaEmpl()
        {
            return lstEmplAli;
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
        private void ListaEmpleados(string prodBuscar)
        {
            //SqlParameter pCampo = new SqlParameter("@campo", nomCat);
            SqlParameter pValor = new SqlParameter("@valor", prodBuscar);
            //lista.Add(pCampo);
            lista.Add(pValor);
        }
        public DataTable BuscarEmpleado(string emplBuscar)
        {

            ListaEmpleados(emplBuscar);
            try
            {
                return com.EjecutaConsulta("LOG_TBC_Empleado_Buscar", lista, 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }
        public DataTable ListarSexo()
        {
            try
            {
                DataTable dtsexo = new DataTable();
                dtsexo.Columns.Add("Sexo");

                dtsexo.Rows.Add("M");
                dtsexo.Rows.Add("F");
                return dtsexo;
                //lista.Clear();
                //return com.EjecutaConsulta("LOG_TBC_AREA_LISTAR", lista, 1);
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
            ds.Tables[0].TableName = nomTabEmpl;
            int numFilas = lstEmplReal.Count;

            for (int i = 0; i < numFilas; i++)
            {
                ds.Tables[0].Columns[LstEmplAli()[i]].ColumnName = lstEmplReal[i];
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
            LstEmplReal();
            string campos = string.Empty;
            List<string> camposTabla = new List<string>();
            for (int j = 1; j < lstEmplReal.Count; ++j)
            {
                camposTabla.Add(lstEmplReal[j]);
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
                LstEmplReal();
                DataTable dtPos = new DataTable();
                DataTable prueba = new DataTable();
                prueba = ds.Tables[0];
                listaParametros.Clear();
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabEmpl);
                listaParametros.Add(pTabla);
                dtPos = com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
                int numero = Convert.ToInt32(dtPos.Rows[0][0].ToString());
                ds.Tables[0].Columns.Add(lstEmplAli[0]).SetOrdinal(0);

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
        public void InsertarEmpleado(DataSet ds)
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
        public void ModificarEmpleado(EEmpleado oeEmpl, List<string> campos, string valores)
        {
            try
            {
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabEmpl);
                SqlParameter pId = new SqlParameter("@id", oeEmpl.idEmpleado);
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
        public void EliminarEmpleado(EEmpleado oEmpl)
        {
            try
            {
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabEmpl);
                SqlParameter pId = new SqlParameter("@id", oEmpl.idEmpleado);
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
        public DataTable ListarEmpleados()
        {
            listaParametros.Clear();
            SqlParameter pTabla = new SqlParameter("@tabla", nomTabEmpl);
            listaParametros.Add(pTabla);
            return com.EjecutaConsulta("GEN_LISTAR", listaParametros, 1);
        }
        #endregion

        #region BUSCAR REGISTROS DETERMINADOS EN APLICACION
        /**FUNCION BUSCAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public DataTable BuscarEmpleados(List<string> campos, string valores)
        {
            listaParametros.Clear();
            SqlParameter pTabla = new SqlParameter("@tabla", nomTabEmpl);
            SqlParameter pCampos = new SqlParameter("@campos", ValidarCampos(campos));
            SqlParameter pValores = new SqlParameter("@valores", valores);
            listaParametros.Add(pTabla); listaParametros.Add(pCampos); listaParametros.Add(pValores);
            return com.EjecutaConsulta("GEN_FILTRAR", listaParametros, 1);
        }
        #endregion
    }
}
