using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Main.Module
{
    public class BUsuario
    {
        DEmpleado odEmpleado = new DEmpleado();

        public DataTable LlenarComboEmpleado()
        {
            return odEmpleado.LlenarCombo();
        }
    }
}
