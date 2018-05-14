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
    public class BProducto
    {
        DProducto odPro = new DProducto();

        public DataTable BuscarProducto(string proBuscar)
        {
             return odPro.BuscarProducto(proBuscar);
        }

        #region METODOS
        public void InsertProducto(DataSet ds)
        {
            odPro.InsertProducto(ds);
        }
        public void UpdateProducto(int idProd, string nomProd, int canProd, int idCat, int idUMed)
        {
            odPro.UpdateProducto(idProd, nomProd, canProd, idCat, idUMed);
        }
        public void DeleteProducto(int idProd)
        {
            odPro.DeleteProducto(idProd);
        }
        #endregion
    }
}
