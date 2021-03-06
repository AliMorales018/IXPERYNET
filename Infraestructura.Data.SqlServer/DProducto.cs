﻿using System;
using System.Collections.Generic;


using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Utilitario;

namespace Infraestructura.Data.SqlServer
{
    public class DProducto
    {
        #region ATRIBUTOS DE APLICACION
        /**NOMBRE TABLAS**/
        internal string nomTabPro { get => "TBC_PRODUCTO"; }
        /**NOMBRE DE CAMPOS EN LA BASE DE DATOS**/
        internal string idPro { get => "N_IdProducto"; }
        internal string nombrePro { get => "V_NomProducto"; }//COL BD NOMBRE DE LA CATEGORIA
        internal string cantPro { get => "N_CantProducto"; }//COL BD IDFAMILIA(FK->FAMILIA)
        internal string idCat { get => "N_IdCategoria"; }
        internal string idUMed { get => "N_IdUmedida"; }
        /**NOMBRE DE CAMPOS PARA LA PRESENTACION**/
        public string cIdPro { get => "IdProd"; }
        public string cNomPro { get => "NomProd"; }
        public string cCanPro { get => "CantProd"; }
        public string cIdCat { get => "IdCate"; }
        public string cIdUMed { get => "IdUMed"; }
        #endregion
        #region DECLARACION DE VARIABLES
        /****/
        private string campoUpd = "V_NomProducto; N_CantProducto; N_IdCategoria; N_IdUmedida";
        #endregion
        #region INSTANCIACIONES
        /**LLAMADOS A OTRAS CLASES**/
        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> listaParametros = new List<SqlParameter>();
        List<SqlParameter> lista = new List<SqlParameter>();
        DGeneral odGeneral = new DGeneral();
        XDocument xml = new XDocument();
        #endregion
        private void ListaProductos(string prodBuscar)
        {
            //SqlParameter pCampo = new SqlParameter("@campo", nomCat);
            SqlParameter pValor = new SqlParameter("@valor", prodBuscar);
            //lista.Add(pCampo);
            lista.Add(pValor);
        }
        public DataTable BuscarProducto(string prodBuscar)
        {

            ListaProductos(prodBuscar);
            try
            {
                return com.EjecutaConsulta("LOG_TBC_Producto_Buscar", lista, 1);
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
            ds.Tables[0].TableName = nomTabPro;
            ds.Tables[0].Columns[cIdPro].ColumnName = idPro;
            ds.Tables[0].Columns[cNomPro].ColumnName = nombrePro;
            ds.Tables[0].Columns[cCanPro].ColumnName = cantPro;
            ds.Tables[0].Columns[cIdCat].ColumnName = idCat;
            ds.Tables[0].Columns[cIdUMed].ColumnName = idUMed;
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
            camposTabla.Add(nombrePro);
            camposTabla.Add(cantPro);
            camposTabla.Add(idCat);
            camposTabla.Add(idUMed);
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
                SqlParameter pTabla = new SqlParameter("@tabla", nomTabPro);
                listaParametros.Add(pTabla);
                dtPos = com.EjecutaConsulta("GEN_RETORNAID", listaParametros, 1);
                int numero = Convert.ToInt32(dtPos.Rows[0][0].ToString());
                ds.Tables[0].Columns.Add("IdProd").SetOrdinal(0);

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
        public void InsertProducto(DataSet ds)
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
            SqlParameter pNomTabla = new SqlParameter("@tabla", nomTabPro);//NOMBRE TABLA LOG.TBC_CATEGORIA @tabla
            SqlParameter pCampoEval = new SqlParameter("@campo", nombrePro);//NOMBRE DE LA COL BD NOMBRE DE LA CATEGORIA
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
        public void UpdateProducto(int idProd, string nomProd, int canProd, int idCat, int idUMed)
        {
            int tipo = 1;
            ListaParametros(tipo,  idProd,  nomProd,  canProd,  idCat,  idUMed);
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
        public void DeleteProducto(int idProd)
        {
            int tipo = 3;
            ListaParametros(tipo,idProd,"",0,0,0);
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
