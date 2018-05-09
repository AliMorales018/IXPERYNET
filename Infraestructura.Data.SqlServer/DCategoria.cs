using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;
using Utilitario;
using System.IO;

namespace Infraestructura.Data.SqlServer
{
    public class DCategoria
    {
        DtUtilitario com = new DtUtilitario();
        public string nomTabFam { get => "TBC_FAMILIA"; }//NOMBRE TABLA FAMILIA BD
        public string nomTabCat { get => "TBC_CATEGORIA"; }//NOMBRE TABLA CATEGORIA BD

        public string nombreCat { get => "V_NomCategoria"; }//COL BD NOMBRE DE LA CATEGORIA
        public string idFam { get => "N_IdFamilia"; }//COL BD IDFAMILIA(FK->FAMILIA)
        private string xmlString = "";//SE CAPTURA EL XML COMO CADENA @fichero
        //private string nodoHijo = "V_NomCategoria, N_IdFamilia";//@parametros BD
        private string campoUpd = "V_NomCategoria; N_IdFamilia";
        private string salida = "";
        List<SqlParameter> lista = new List<SqlParameter>();

        public DataTable LlenarCombo()
        {
            try
            {
                lista.Clear();
                //SqlParameter tabla = new SqlParameter("@tabla", nomTab);
                //lista.Add(tabla);
                return com.EjecutaConsulta("LOG_TBC_CATEGORIA_LISTAR", lista, 1);

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }

        private void ListaParametros(int tipo,string nomCat,int idFam,int idCat)
        {
            SqlParameter pNomTabla = new SqlParameter("@tabla", nomTabCat);//NOMBRE TABLA LOG.TBC_CATEGORIA @tabla
            SqlParameter pCampoEval = new SqlParameter("@campo", nombreCat);//NOMBRE DE LA COL BD NOMBRE DE LA CATEGORIA
            if (tipo==0)//tipo 0: grabar
            {
                SqlParameter pXml = new SqlParameter("@xml", xmlString);//@fichero BD
                SqlParameter pSalida = new SqlParameter("@salida", salida);//@parametros
                lista.Add(pXml);
                lista.Add(pCampoEval);
                lista.Add(pSalida);
                //lista.Add(pNomTabla);
                //lista.Add(pNodoHijo);
                
            }
            else if(tipo==1)//tipo 1:actualizar
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
            else//tipo listar
            {

            }
        }
        private void ListaCategorias(string catBuscar)
        {
            //SqlParameter pCampo = new SqlParameter("@campo", nomCat);
            SqlParameter pValor = new SqlParameter("@valor", catBuscar);
            //lista.Add(pCampo);
            lista.Add(pValor);
        }
        public void InsertCategoria(String xml)
        {
            int tipo = 0;
            xmlString = xml;
            ListaParametros(tipo,"",0,0);
            try
            {
                com.TransUnica("GEN_INSERTAR_XML", lista);
            }
            catch (Exception ex)
            {
                com.DeshaceTransaccion();
                throw new Exception(ex.Message, ex);
            }
            lista.Clear();
        }
        public void UpdateCategoria(string nomCat, int idFam, int idCat)
        {
            int tipo = 1;
            ListaParametros(tipo,nomCat,idFam,idCat);
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
            lista.Clear();
        }


    }
}

