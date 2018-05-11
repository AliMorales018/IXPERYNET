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
    public class DEmpleado
    {
        public string nomTab {get => "RHTBC_EMPLEADO";}
        public string idEmpleado { get => "N_IdEmpleado"; }
        public string idArea { get => "N_IdArea"; }
        public string Dni { get => "C_Dni"; }
        public string Nombres { get => "V_Nombre"; }
        public string ApePat { get => "V_ApellidoPaterno"; }
        public string ApeMat { get => "V_ApellidoMaterno"; }
        public string Telefono { get => "C_Telefono"; }
        public string Direccion { get => "V_Direccion"; }
        public string FechaNac { get => "D_FechaNac"; }
        public string Sexo { get => "C_Sexo"; }
        public string Estado { get => "S_Estado"; }

        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> lista = new List<SqlParameter>();

        public DataTable LlenarCombo()
        {
            try
            {
                return com.EjecutaConsulta("LOG_TBC_EMPLEADO_LISTAR", lista, 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message, ex);
            }
        }
    }
}
