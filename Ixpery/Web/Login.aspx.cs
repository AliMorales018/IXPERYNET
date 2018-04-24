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
            Session["idUsuario"] = Acceso;
            //ContSelec.Visible = true;
            //Deshabilitar(true);
            ListarApli(Acceso);
        }
        else
        {
            ContSelec.Visible = false;
            //Deshabilitar(false);
            Mensaje.Text = "Usuario no encontrado :(";
        }
    }

    protected void OnChanged(object sender, EventArgs e)
    {
        int idUsuario = Int32.Parse(Session["idUsuario"].ToString());
        ListarPerfApli(idUsuario, Int32.Parse(SelectApli.SelectedValue));
    }

    protected void Enter(object sender, EventArgs e) {
        Mensaje.Text = "enter";
    }

    protected void ListarApli(int idUsu)
    {
        Acceso = idUsu;
        DataTable dtTable = dUser.VerApliUsuario(new EUser { idUsuario = idUsu });
        LlenarSelect(dtTable, SelectApli, "V_Aplication", "N_IdApli");
        ListarPerfApli(idUsu, Int32.Parse(SelectApli.SelectedValue));
    }

    protected void ListarPerfApli(int idUsu, int idApli)
    {
        Mensaje.Text = "IDU: " +Acceso + "IDA: " +idApli;
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

    protected void HabilitarSelect() {
        SelectApli.Enabled = true;
        SelectPerfil.Enabled = true;
    }

    /*protected void Deshabilitar(bool estado)
    {
        TxtLogin.Enabled = estado;
        TxtPass.Enabled = estado;
    }*/
}