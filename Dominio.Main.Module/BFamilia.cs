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
    public class BFamilia
    {
        DFamilia odFamilia = new DFamilia();

        public DataTable LlenarCombo()
        {
            return odFamilia.LlenarCombo();
        }
        public DataTable ListarFamilia()
        {
            return odFamilia.ListarFamilia();
        }
    }
}
