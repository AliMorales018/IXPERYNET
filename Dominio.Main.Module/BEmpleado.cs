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
    public class BEmpleado
    {
        DEmpleado odEmpl = new DEmpleado();

        public DataTable BuscarEmpleado(string emplBuscar)
        {
            return odEmpl.BuscarEmpleado(emplBuscar);
        }
        public DataTable ListarSexo()
        {
            return odEmpl.ListarSexo();
        }
        //public DataTable ListarEmpleado()
        //{
        //    //return odEmpl.ListarEmpleado();
        //}
        #region METODOS
        public void InsertEmpleado(DataSet ds)
        {
            odEmpl.InsertEmpleado(ds);
        }
        public void UpdateEmpleado(int idEmpl, int idArea, char dni, string nombre, string paterno, string materno, char telef,string direc, string fNac, char sex, char esta)
        {
            odEmpl.UpdateEmpleado(idEmpl, idArea, dni, nombre, paterno, materno, telef, direc, fNac, sex, esta);
        }
        public void DeleteEmpleado(int idEmpl)
        {
            odEmpl.DeleteEmpleado(idEmpl);
        }
        #endregion
    }
}
