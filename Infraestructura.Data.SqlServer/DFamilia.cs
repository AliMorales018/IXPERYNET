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
        public string nomFam { get => "V_NomFamilia"; }//nombre de la columna de la BD
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

    }
}
