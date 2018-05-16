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
        DCategoria odCate = new DCategoria();

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
            odCate.InsertarCategoria(ds);
        }

        public void Modificar(ECategoria oeCate, List<string> campos, string valores)
        {
            odCate.ModificarCategoria(oeCate, campos, valores);
        }

        public void Eliminar(ECategoria oeCate)
        {
            odCate.EliminarCategoria(oeCate);
        }
        #endregion

        #region FUNCIONES
        /**LLAMADO DE LAS FUNCIONES EN LA CAPA DE DATOS**/
        public DataTable Listar()
        {
            return odCate.ListarCategoria();
        }
        public List<string> getListCate()
        {
            return odCate.getListaCate();
        }
        public List<string> llenarLista()
        {
            return odCate.LstCateAli();
        }
        public DataTable Buscar(List<string> campos, string valores)
        {
            return odCate.BuscarCategorias(campos, valores);
        }
        #endregion   
    }
}
