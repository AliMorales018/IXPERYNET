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
    class DPerfilUser{
        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> lista = new List<SqlParameter>();

        private void LlenarObj(EPerfilUser oPerUse) {
            SqlParameter id = new SqlParameter("@IdPerfilUsuario", oPerUse.idPerfilUser);
            SqlParameter idPerfil = new SqlParameter("@IdPerfil", oPerUse.oPerfil.oPerfil);
            SqlParameter idUsuario = new SqlParameter("@IdUsuario", oPerUse.oUser.idUsuario);
            SqlParameter estado = new SqlParameter("@Estado", oPerUse.Estado);
            lista.Add(id); lista.Add(idPerfil); lista.Add(idUsuario); lista.Add(estado);
        }

        public void InsertarPerfilUsu(EPerfilUser oPerfilUser) {
            try{
                LlenarObj(oPerfilUser);
                com.TransUnica("LOG_XTBD_PERFILUSER_INSERTAR", lista);
                lista.Clear();
            }
            catch (Exception ex){
                throw new Exception("DB - Error " + ex.Message, ex);
            }
        }
    }
}
