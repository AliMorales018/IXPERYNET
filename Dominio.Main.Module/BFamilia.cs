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
        DFamilia odFam = new DFamilia();

        #region METODOS
        /**LLAMADO DE LOS METODOS EN LA CAPA DE DATOS**/
        public void Insertar(DataSet ds)
        {
            odFam.InsertarFamilia(ds);
        }

        public void Modificar(EFamilia oeFam, List<string> campos, string valores)
        {
            odFam.ModificarFamilia(oeFam, campos, valores);
        }

        public void Eliminar(EFamilia oeFam)
        {
            odFam.EliminarFamilia(oeFam);
        }
        #endregion

        #region FUNCIONES
        /**LLAMADO DE LAS FUNCIONES EN LA CAPA DE DATOS**/
        public DataTable Listar()
        {
            return odFam.ListarFamilias();
        }
        public List<string> getListFam()
        {
            return odFam.getListaFam();
        }
        public List<string> llenarLista()
        {
            return odFam.LstFamAli();
        }
        public DataTable Buscar(List<string> campos, string valores)
        {
            return odFam.BuscarFamilias(campos, valores);
        }
        //public void Actualizar(List<string> campos, string valores, int cod)
        //{
        //    odFam.ActualizarFamilias(campos, valores, cod);
        //}
        #endregion
    }
}