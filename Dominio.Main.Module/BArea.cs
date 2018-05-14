using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Dominio.Core.Entities;
using Infraestructura.Data.SqlServer;
namespace Dominio.Main.Module
{
    public class BArea
    {
        DArea odArea = new DArea();

        public DataTable BuscarArea(string areaBuscar)
        {
            return odArea.BuscarArea(areaBuscar);
        }
        public DataTable LlenarCombo()
        {
            return odArea.LlenarCombo();
        }
        #region METODOS
        public void InsertArea(DataSet ds)
        {
            odArea.InsertArea(ds);
        }
        public void UpdateProducto(int idProd, string nomProd, int canProd, int idCat, int idUMed)
        {
            odArea.UpdateArea(idProd, nomProd, canProd, idCat, idUMed);
        }
        public void DeleteArea(int idProd)
        {
            odArea.DeleteArea(idProd);
        }
        #endregion
    }
}
