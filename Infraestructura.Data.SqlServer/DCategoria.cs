using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;
using Utilitario;
namespace Infraestructura.Data.SqlServer
{
    public class DCategoria
    {
        public string nomTab { get => "XTBC_FAMILIA"; }
        public string nomCat { get => "V_NomCategoria"; }//COL BD NOMBRE DE LA CATEGORIA
        public string idFam { get => "N_IdFamilia"; }//COL BD IDFAMILIA(FK->FAMILIA)
        
        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> lista = new List<SqlParameter>();
        public DataTable LlenarCombo()
        {
            try
            {
                SqlParameter tabla = new SqlParameter("@tabla", nomTab);
                lista.Add(tabla);
                return com.EjecutaConsulta("X_XTBC_Listar", lista, 1);
                
            }
            catch (Exception ex)
            {

                throw new Exception("Error " + ex.Message, ex);
            }

            //SqlParameter id = new SqlParameter("@IdFamilia", oFam.idFamilia);
            //lista.Add(id); 
            //lista.Add(nombre);
        }
    }
}
