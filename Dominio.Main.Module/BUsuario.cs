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
        DUser odUser = new DUser();

        public DataTable LlenarComboEmpleado()
        {
            return odEmpleado.LlenarCombo();
        }
        public DataTable RecuperarId()
        {
            return odUser.RecuperarId();
        }
        public void InsertUsuario(String xml)
        {
            odUser.InsertUsuario(xml);
        }
    }
}
