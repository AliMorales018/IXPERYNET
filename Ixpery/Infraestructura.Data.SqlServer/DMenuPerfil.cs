using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;
using Utilitario;

namespace Infraestructura.Data.SqlServer{
    public class DMenuPerfil{
        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> lista = new List<SqlParameter>();

        private void LlenarObj(EMenuPerfil oMenuPerfil){
            SqlParameter idMenuPerfil = new SqlParameter("@IdMenuPerfil", oMenuPerfil.idMenuPerfil);
            SqlParameter idMenu = new SqlParameter("@IdMenu", oMenuPerfil.oMenu.idMenu);
            SqlParameter idPerfil = new SqlParameter("@IdPerfil", oMenuPerfil.oPerfil.oPerfil);
            SqlParameter estado = new SqlParameter("@Estado", oMenuPerfil.Estado);
            SqlParameter visible = new SqlParameter("@Visible", oMenuPerfil.Visible);
            lista.Add(idMenuPerfil); lista.Add(idMenu); lista.Add(idPerfil); lista.Add(estado); lista.Add(visible);
        }

        public void InsertarPerfilUsu(EMenuPerfil oMenuPerfil){
            try{
                LlenarObj(oMenuPerfil);
                com.TransUnica("LOG_XTBD_MENUPERFIL_INSERTAR", lista);
                lista.Clear();
            }
            catch (Exception ex){
                throw new Exception("DB - Error " + ex.Message, ex);
            }
        }
    }
}