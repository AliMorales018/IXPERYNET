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
    public class DUnidMedida
    {
        DtUtilitario com = new DtUtilitario();

        public string nomTabFam { get => "LOG.TBC_UMEDIDA"; }//NOMBRE TABLA UNIDAD DE MEDIDA BD

        List<SqlParameter> lista = new List<SqlParameter>();
        public DataTable LlenarCombo()
        {
            try
            {
                lista.Clear();
                //SqlParameter tabla = new SqlParameter("@tabla", nomTab);
                //lista.Add(tabla);
                return com.EjecutaConsulta("LOG_TBC_UMEDIDA_LISTAR", lista, 1);

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }
    }
}
