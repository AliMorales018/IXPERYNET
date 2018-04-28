using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Dominio.Core.Entities;
using Infraestructura.Data.SqlServer;

public partial class _Default : System.Web.UI.Page
{
    DUser dUser = new DUser();
    int Acceso;

    public void Page_Load(object sender, EventArgs e)
    {

    }

    public void Validar(object sender, EventArgs e)
    {

        String login = TxtLogin.Text;
        String pass = TxtPass.Text;

        EUser ouser = new EUser
        {
            Login = login,
            CLave = pass
        };

        Acceso = dUser.ValidarUsuario(ouser);

        if (Acceso != 0)
        {
                Mensaje.Text = "";
                Session["idUsuario"] = Acceso;
                Habilitar();
                ListarApli(Acceso);
        }
        else
        {
            Session["idUsuario"] = 0;
            Mensaje.Text = "Usuario no encontrado :(";
        }
    }

    protected void OnChanged(object sender, EventArgs e)
    {
        int idUsuario = Int32.Parse(Session["idUsuario"].ToString());
        ListarPerfApli(idUsuario, Int32.Parse(SelectApli.SelectedValue));
    }

    protected void Redirect(object sender, EventArgs e) {
        if (!SelectApli.SelectedValue.Equals("0") && !SelectPerfil.SelectedValue.Equals("0"))
        {
            int idApli = Int32.Parse(SelectApli.SelectedValue);
            int idPerf = Int32.Parse(SelectPerfil.SelectedValue);
            Mensaje.Text = "Entro al Sistema";
            Response.Redirect("/Aplicaciones/ControlUsuarios/PanelControl.aspx?apli="+idApli+"&perf="+idPerf);
        }
        else
        {
            Mensaje.Text = "Complete todos los campos :)";
        }
    }

    protected void ListarApli(int idUsu)
    {
        Acceso = idUsu;
        DataTable dtTable = dUser.VerApliUsuario(new EUser { idUsuario = idUsu });
        LlenarSelect(dtTable, SelectApli, "V_Aplicacion", "N_IdApli");
        ListarPerfApli(idUsu, Int32.Parse(SelectApli.SelectedValue));
    }

    protected void ListarPerfApli(int idUsu, int idApli)
    {
        DataTable dtTable = dUser.VerPerfApliUsuario(new EUser { idUsuario = idUsu }, new EAplicacion { idApli = idApli });
        LlenarSelect(dtTable, SelectPerfil, "V_Perfil", "N_IdPerfil");
    }

    protected void LlenarSelect(DataTable dtTable, DropDownList ddl, String Texto, String Valor)
    {
        ddl.DataSource = dtTable;
        ddl.DataTextField = Texto;
        ddl.DataValueField = Valor;
        ddl.DataBind();
    }

    protected void Habilitar() {
        BtnIngresar.Enabled = true;
    }
}