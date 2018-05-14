using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Dominio.Core.Entities;
using Infraestructura.Data.SqlServer;
using System.Xml.Linq;

namespace Dominio.Main.Module
{
    public class BCategoria
    {
        DCategoria odCat = new DCategoria();
        #region FUNCIONES
        public DataTable LlenarCombo()
        {
            return odCat.LlenarCombo();
        }
        public DataTable BuscarCategoria(string catBuscar)
        {
            return odCat.BuscarCategoria(catBuscar);
        }
        #endregion
        #region METODOS
        public void InsertCategoria(DataSet ds)
        {
            odCat.InsertCategoria(ds);
        }
        public void UpdateCategoria(string nomCat, int idFam, int idCat)
        {
            odCat.UpdateCategoria(nomCat, idFam, idCat);
        }
        public void DeleteCategoria(int idCat)
        {
            odCat.DeleteCategoria(idCat);
        }
        #endregion
        public DataTable ListarCategoria()
        {
            return odCat.ListarCategoria();
        }
        
    }
}
