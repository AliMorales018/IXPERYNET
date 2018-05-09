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
    public class BProducto
    {
        DProducto odPro = new DProducto();

        public DataTable BuscarProducto(string proBuscar)
        {
             return odPro.BuscarProducto(proBuscar);
        }

        public void InsertProducto(String xml)
        {
            //odPro.InsertProducto(xml);
        }

        public void UpdateProducto(string nomCat, int idFam, int idCat)
        {
            //odPro.UpdateProducto(nomCat, idFam, idCat);
        }
    }
}
