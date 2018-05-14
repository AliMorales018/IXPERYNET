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
        //Parametros tabla Usuario
        public string NomTabEsquema { get => "XXX.TBC_USER"; }
        public string NomTab { get => "TBC_USER"; }
        public string idUsuario { get => "N_IdUser"; }
        public string Login { get => "V_Login"; }
        public string Nombres { get => "V_Nombres"; }
        public string ApePat { get => "V_Paterno"; }
        public string ApeMat { get => "V_Materno"; }
        public string Estado { get => "S_Estado"; }
        public string Clave { get => "V_Clave"; }
        public string IdPersonal { get => "N_IdPersonal"; }


        DtUtilitario com = new DtUtilitario();
        List<SqlParameter> lista = new List<SqlParameter>();
        private string xmlString = "";

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
            DataTable dtAcceso = com.EjecutaConsulta("XXX_TBC_USER_INGRESAR", lista, 1);
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
            return com.EjecutaConsulta("XXX_TBD_APLICACION_USER_BUSCAR", lista, 1);
        }

        public DataTable VerPerfApliUsuario(EUser oUsu, EAplicacion oApli){
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter idUsu = new SqlParameter("@iduser", oUsu.idUsuario);
            SqlParameter idApli = new SqlParameter("@idaplicacion", oApli.idApli);
            lista.Add(idUsu);lista.Add(idApli);
            return com.EjecutaConsulta("XXX_TBD_PERFIL_APLICACION_USUARIO_BUSCAR", lista, 1);
        }

        private void ListaParametros(int tipo, string nomCat, int idFam, int idCat)
        {
            lista.Clear();
            SqlParameter pNomTabla = new SqlParameter("@tabla", NomTab);
            if (tipo == 0)
            {
                SqlParameter pXml = new SqlParameter("@xml", xmlString);
                lista.Add(pXml);
            }
            else if (tipo == 1)
            {
                //string valores = nomCat + ";" + idFam;
                //SqlParameter pCampos = new SqlParameter("@campos", campoUpd);
                //SqlParameter pValores = new SqlParameter("@valores", valores);
                //SqlParameter pIdCat = new SqlParameter("@id", idCat);
                //lista.Add(pNomTabla);
                //lista.Add(pCampos);
                //lista.Add(pValores);
                //lista.Add(pIdCat);
            }
            else
            {
                lista.Add(pNomTabla);
            }
        }

        public void InsertUsuario(String xml)
        {
            int tipo = 0;
            xmlString = xml;
            ListaParametros(tipo, "", 0, 0);
            try
            {
                com.TransUnica("GEN_INSERTAR_XML_CON_ID", lista);
            }
            catch (Exception ex)
            {
                com.DeshaceTransaccion();
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable RecuperarId()
        {
            int tipo = 2;
            ListaParametros(tipo, "", 0, 0);
            try
            {
                return com.EjecutaConsulta("GEN_RETORNAID", lista, 1);
            }
            catch (Exception ex)
            {
                com.DeshaceTransaccion();
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
