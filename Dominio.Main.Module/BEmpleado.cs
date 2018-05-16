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
       
        #region ATRIBUTOS
        /**LLAMADO DE LOS ATRIBUTOS EN LA CAPA DE DATOS**/
        //public string ApliValue()
        //{
        //	return odApli.cIdApp;
        //}

        //public string ApliText()
        //{
        //	return odApli.cNomApp;
        //}
        #endregion

        #region METODOS
        /**LLAMADO DE LOS METODOS EN LA CAPA DE DATOS**/
        public void Insertar(DataSet ds)
        {
            odEmpl.InsertarEmpleado(ds);
        }

        public void Modificar(EEmpleado oeEmpl, List<string> campos, string valores)
        {
            odEmpl.ModificarEmpleado(oeEmpl, campos, valores);
        }

        public void Eliminar(EEmpleado oeEmpl)
        {
            odEmpl.EliminarEmpleado(oeEmpl);
        }
        #endregion

        #region FUNCIONES
        /**LLAMADO DE LAS FUNCIONES EN LA CAPA DE DATOS**/
        public DataTable Listar()
        {
            return odEmpl.ListarEmpleados();
        }
        public List<string> getListEmpl()
        {
            return odEmpl.getListaEmpl();
        }
        public List<string> llenarLista()
        {
            return odEmpl.LstEmplAli();
        }
        public DataTable Buscar(List<string> campos, string valores)
        {
            return odEmpl.BuscarEmpleados(campos, valores);
        }


        #endregion

    }
}
