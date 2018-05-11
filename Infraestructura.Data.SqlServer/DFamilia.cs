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
    public class DFamilia
    {
        public string nomTab { get => "XTBC_FAMILIA"; }//NOMBRE DE LA TABLA BD
        public string nomFam { get => "V_NomFamilia"; }//nombre de la columna de la BD
        public string idFam { get => "N_IdFamilia"; }//COL BD IDFAMILIA(FK->FAMILIA)
        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> lista = new List<SqlParameter>();
        private void LlenarObj(EFamilia oFam)
        {
            //SqlParameter id = new SqlParameter("@IdFamilia", oFam.idFamilia);
            SqlParameter nombre = new SqlParameter("@NomFamilia", oFam.nomFamilia);
            //lista.Add(id); 
            lista.Add(nombre);
        }
        public void InsertarFamilia(EFamilia oFam)
        {
            try
            {
                LlenarObj(oFam);
                com.TransUnica("LOG_XTBC_FAMILIA_INSERTAR", lista);
                lista.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("DB - Error" + ex.Message, ex);
            }
            finally
            {
            }
        }

        public DataTable LlenarCombo()
        {
            try
            {
                lista.Clear();
                //SqlParameter tabla = new SqlParameter("@tabla", nomTab);
                //lista.Add(tabla);
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
