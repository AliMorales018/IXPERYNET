using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;
using Utilitario;

namespace Infraestructura.Data.SqlServer {

    public class DUser {
        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> lista = new List<SqlParameter>();

        private void LlenarObj(EUser oUsu) {
            SqlParameter id = new SqlParameter("@iduser", oUsu.idUsuario);
            SqlParameter login = new SqlParameter("@login", oUsu.Login);
            SqlParameter nom = new SqlParameter("@nombres", oUsu.Nombres);
            SqlParameter pat = new SqlParameter("@paterno", oUsu.Paterno);
            SqlParameter mat = new SqlParameter("@paterno", oUsu.Materno);
            SqlParameter estado = new SqlParameter("@estado", oUsu.Estado);
            SqlParameter clave = new SqlParameter("@clave", oUsu.CLave);
            SqlParameter idper = new SqlParameter("@id_personal", oUsu.idPersonal);

            lista.Add(id); lista.Add(login); lista.Add(nom); lista.Add(pat);
            lista.Add(mat); lista.Add(estado); lista.Add(clave); lista.Add(idper);
        }

        public int ValidarUsuario(EUser oUsu) {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@login", oUsu.Login);
            SqlParameter clave = new SqlParameter("@clave", oUsu.CLave);
            lista.Add(id); lista.Add(clave);
            DataTable dtAcceso = com.EjecutaConsulta("LOG_XTBC_USER_INGRESAR", lista, 1);
            DataRow row = dtAcceso.Rows[0];

            return (int) row["acceso"];
        }

        public DataTable ListarUsuarios(EUser oUsu){
            List<SqlParameter> lista = new List<SqlParameter>();
            return com.EjecutaConsulta("LOG_XTBC_USER_LISTAR", lista, 0);
        }

        public DataTable VerUsuario(EUser oUsu) {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@iduser", oUsu.idUsuario);
            lista.Add(id);
            return com.EjecutaConsulta("LOG_XTBC_USER_INSERTAR", lista, 1);
        }

        public void BajaUsuario(EUser oUsu) {
            try {
                List<SqlParameter> lista = new List<SqlParameter>();
                SqlParameter id = new SqlParameter("@iduser", oUsu.idUsuario);
                lista.Add(id);
                com.TransUnica("LOG_XTBC_USER_INSERTAR", lista);
            }
            catch (Exception ex) {
                throw new Exception("DB - Error " + ex.Message, ex);
            }
        }

        public void ActualizarUsuario(EUser oUsu) {
            try {
                LlenarObj(oUsu);
                com.TransUnica("LOG_XTBC_USER_ACTUALIZAR", lista);
                lista.Clear();
            }
            catch (Exception ex) {
                throw new Exception("DB - Error " + ex.Message, ex);
            }
        }

        public void InsertarUsuario(EUser oUsu) {
            try {
                LlenarObj(oUsu);
                com.TransUnica("LOG_XTBC_USER_INSERTAR", lista);
                lista.Clear();
            }
            catch (Exception ex) {
                throw new Exception("DB - Error " + ex.Message, ex);
            }
        }

        public DataTable VerApliUsuario(EUser oUsu) {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter id = new SqlParameter("@iduser", oUsu.idUsuario);
            lista.Add(id);
            return com.EjecutaConsulta("LOG_XTBD_APLICACIONXUSER_BUSCAR_", lista, 1);
        }

        public DataTable VerPerfApliUsuario(EUser oUsu, EAplicacion oApli){
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter idUsu = new SqlParameter("@iduser", oUsu.idUsuario);
            SqlParameter idApli = new SqlParameter("@idaplicacion", oApli.idApli);
            lista.Add(idUsu);lista.Add(idApli);
            return com.EjecutaConsulta("LOG_XTBD_PERFILES_APLICACION_USUARIO", lista, 1);
        }
    }
}
