using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Dominio.Main.Module;
using Infraestructura.Data.SqlServer;

public partial class Aplicaciones_Logistica_Empleado : System.Web.UI.Page
{
    DEmpleado odEmpl = new DEmpleado();
    BEmpleado obEmpl = new BEmpleado();
    BArea obArea = new BArea();
    List<string> lista = new List<string>();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt.Columns.Add("idArea");
        dt.Columns.Add("dni");
        dt.Columns.Add("nombre");
        dt.Columns.Add("paterno");
        dt.Columns.Add("materno");
        dt.Columns.Add("telefono");
        dt.Columns.Add("direccion");
        dt.Columns.Add("fNacimiento");
        dt.Columns.Add("sexo");
        dt.Columns.Add("estado");
        if(!IsPostBack)
        {
            //LLENANDO EL COMBO CON LOS DATOS DE ÁREA---ESPERAR A MIGUEL QUE CREE LA TABLA AREA
            cmbArea1.DataSource = obArea.LlenarCombo();
            cmbArea1.DataTextField = "Nombre";
            cmbArea1.DataValueField = "IdArea";
            cmbArea1.DataBind();
        }
    }

    protected void btnBusDni_Click(object sender, EventArgs e)
    {

    }

    protected void gvEmpleado_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvEmpleado_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void gvEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (HctblEmpleado.Value.Equals(""))
        {
            HctblEmpleado.Value = "1";
        }
        for (int i = 0; i < Convert.ToInt32(HctblEmpleado.Value); ++i)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows[i][0] = Request["cmbArea" + (i + 1)];
            dt.Rows[i][1] = Request["txtDni" + (i + 1)];
            dt.Rows[i][2] = Request["txtNombre" + (i + 1)];
            dt.Rows[i][3] = Request["txtApePat" + (i + 1)];
            dt.Rows[i][4] = Request["txtApeMat" + (i + 1)];
            dt.Rows[i][5] = Request["txtTelef" + (i + 1)];
            dt.Rows[i][6] = Request["txtDirec" + (i + 1)];
            dt.Rows[i][7] = Request["txtFNac1" + (i + 1)];
            dt.Rows[i][8] = Request["cmbSex" + (i + 1)];
            dt.Rows[i][9] = 0;
            
        }
        //grid.DataSource = dt;
        //grid.DataBind();
        ds.Tables.Add(dt);
        obEmpl.InsertEmpleado(ds);
    }
}