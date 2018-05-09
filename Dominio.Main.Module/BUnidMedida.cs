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
    public class BUnidMedida
    {
        DUnidMedida odUme = new DUnidMedida();

        public DataTable LlenarCombo()
        {
            return odUme.LlenarCombo();
        }

        //public DataTable BuscarUmedida(string catBuscar)
        //{
        //    return odUme.BuscarUmedida(catBuscar);
        //}
        //public void InsertUmedida(String xml)
        //{
        //    odUme.InsertUmedida(xml);
        //}
        //public void UpdateCategoria(string nomCat, int idFam, int idCat)
        //{
        //    odUme.UpdateUmedida(nomCat, idFam, idCat);
        //}
    }
}
