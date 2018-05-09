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
    public class DProducto
    {
        DtUtilitario com = new DtUtilitario();
        public string nomTabCat { get => "XTBC_CATEGORIA"; }//NOMBRE TABLA CATEGORIA BD
        public string nomTabUmed { get => "LOG.TBC_UMEDIDA"; }//NOMBRE TABLA UNIDAD DE MEDIDA BD
        List<SqlParameter> lista = new List<SqlParameter>();
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
            lista.Clear();
        }

    }
}
