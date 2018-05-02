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
    public class BCategoria
    {
        DCategoria odCategoria = new DCategoria();
        
        public DataTable LlenarCombo()
        {
            return odCategoria.LlenarCombo();
        }
    }
}
