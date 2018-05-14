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
        #region ATRIBUTOS DE APLICACION
        /**NOMBRE TABLAS**/
        internal string nomTabEmpl { get => "TBC_EMPLEADO"; }
        /**NOMBRE DE CAMPOS EN LA BASE DE DATOS**/
        internal string idEmpleado { get => "N_IdEmpleado"; }
        internal string idArea { get => "N_IdArea"; }
        internal string Dni { get => "C_Dni"; }
        internal string Nombres { get => "V_Nombre"; }
        internal string ApePat { get => "V_ApellidoPaterno"; }
        internal string ApeMat { get => "V_ApellidoMaterno"; }
        internal string Telefono { get => "C_Telefono"; }
        internal string Direccion { get => "V_Direccion"; }
        internal string FechaNac { get => "D_FechaNac"; }
        internal string Sexo { get => "C_Sexo"; }
        internal string Estado { get => "S_Estado"; }
        /**NOMBRE DE CAMPOS PARA LA PRESENTACION**/
        public string cIdEmpl { get => "IdEmpl"; }
        public string cIdArea { get => "IdArea"; }
        public string cDni { get => "Dni"; }
        public string cNombres { get => "Nombre"; }
        public string cApePat { get => "ApePaterno"; }
        public string cApeMat { get => "ApeMaterno"; }
        public string cTel { get => "Telefono"; }
        public string cDir { get => "Direccion"; }
        public string cFNac { get => "FechaNac"; }
        public string cSexo { get => "Sexo"; }
        public string cEstado { get => "Estado"; }
        #endregion
        #region DECLARACION DE VARIABLES
        /****/
        private string campoUpd = "N_IdEmpleado;N_IdArea;C_Dni;V_Nombre;V_ApellidoPaterno;V_ApellidoMaterno;C_Telefono;V_Direccion;D_FechaNac;C_Sexo;S_Estado";
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
        /**VALIDACIONES DE LOS NOMBRES DE LAS TABLAS**/
        public DataSet ValidarDataSet(DataSet ds)
        {
            ds.Tables[0].TableName = nomTabEmpl;
            ds.Tables[0].Columns[cIdEmpl].ColumnName = idEmpleado;
            ds.Tables[0].Columns[cIdArea].ColumnName = idArea;
            ds.Tables[0].Columns[cDni].ColumnName = Dni;
            ds.Tables[0].Columns[cNombres].ColumnName = Nombres;
            ds.Tables[0].Columns[cApePat].ColumnName = ApePat;
            ds.Tables[0].Columns[cApeMat].ColumnName = ApeMat;
            ds.Tables[0].Columns[cTel].ColumnName = Telefono;
            ds.Tables[0].Columns[cDir].ColumnName = Direccion;
            ds.Tables[0].Columns[cFNac].ColumnName = FechaNac;
            ds.Tables[0].Columns[cSexo].ColumnName = Sexo;
            ds.Tables[0].Columns[cEstado].ColumnName = Estado;
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
            camposTabla.Add(idArea);
            camposTabla.Add(Dni);
            camposTabla.Add(Nombres);
            camposTabla.Add(ApePat);
            camposTabla.Add(ApeMat);
            camposTabla.Add(Telefono);
            camposTabla.Add(Direccion);
            camposTabla.Add(FechaNac);
            camposTabla.Add(Sexo);
            camposTabla.Add(Estado);
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
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabEmpl);
                listaParametros.Add(pTabla);
                dtPos = com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
                int numero = Convert.ToInt32(dtPos.Rows[0][0].ToString());
                ds.Tables[0].Columns.Add("IdEmpl").SetOrdinal(0);

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
        public void InsertEmpleado(DataSet ds)
        {
            string salida = "";
            try
            {
                List<SqlParameter> listParInsert = new List<SqlParameter>();
                SqlParameter pXml = new SqlParameter("@xml", Convert.ToString(odGeneral.generarXML(ValidarDataSet(FixDataSet(ds)))));
                //SqlParameter pCampo = new SqlParameter("@campo", campo);
                SqlParameter pSalid = new SqlParameter("@salid", salida);
                pSalid.Direction = ParameterDirection.InputOutput;
                pSalid.SqlDbType=SqlDbType.NVarChar;
                pSalid.Size = 100;
                listParInsert.Add(pXml);
                listParInsert.Add(pSalid);
                //listaParametros.Add(pCampo);
                //listaParametros.Add(pSalid);
                com.TransUnica("GEN_INSERTAR_XML_CON_ID", listParInsert);
                string a = pSalid.Value.ToString();
                listParInsert.Clear();
            }
            catch (Exception ex)
            {
                com.DeshaceTransaccion();
                throw new Exception("DB - Error" + ex.Message, ex);
            }
        }
        #endregion
        private void ListaParametros(int tipo, int idEmpl, int idArea, char dni, string nombre, string paterno, string materno, char telef, string direc, string fNac, char sex, char esta)
        {
            SqlParameter pNomTabla = new SqlParameter("@tabla", nomTabEmpl);//NOMBRE TABLA LOG.TBC_CATEGORIA @tabla
            SqlParameter pCampoEval = new SqlParameter("@campo", Dni);//NOMBRE DE LA COL BD NOMBRE DE LA CATEGORIA
            if (tipo == 1)//tipo 1:actualizar
            {
                string valores = idArea + ";" + dni + ";" + nombre + ";" + paterno + ";" +  materno + ";" +  telef + ";" +  direc + ";" +  fNac + ";" + sex + ";" +  esta;
                SqlParameter pCampos = new SqlParameter("@campos", campoUpd);
                SqlParameter pValores = new SqlParameter("@valores", valores);
                SqlParameter pIdEmpl = new SqlParameter("@id", idEmpl);
                lista.Add(pNomTabla);
                lista.Add(pCampos);
                lista.Add(pValores);
                lista.Add(pIdEmpl);
            }
            else
            {
                SqlParameter pIdEmpl = new SqlParameter("@id", idEmpl);
                lista.Add(pIdEmpl);
                lista.Add(pNomTabla);
            }
        }
        #region MODIFICAR REGISTRO EXISTENTE EN PRODUCTO
        /**METODO MODIFICAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void UpdateEmpleado(int idEmpl, int idArea, char dni, string nombre, string paterno, string materno, char telef, string direc, string fNac, char sex, char esta)
        {
            int tipo = 1;
            ListaParametros(tipo, idEmpl, idArea, dni, nombre, paterno, materno, telef, direc, fNac, sex, esta);
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
        #region ELIMINAR REGISTRO EXISTENTE EN EMPLEADO
        /**METODO ELIMINAR SEGUN REQUERIMIENTOS DEL PROCEDIMIENTO ALMACENADO**/
        public void DeleteEmpleado(int idEmpl)
        {
            int tipo = 3;
            ListaParametros(tipo, idEmpl,0,'0',"","","",'0',"","",'0','0');
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
                return com.EjecutaConsulta("LOG_TBC_EMPLEADO_LISTAR", lista, 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }
    }
}
