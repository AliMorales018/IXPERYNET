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
        dt.Columns.Add("IdArea");
        dt.Columns.Add("Dni");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("ApePaterno");
        dt.Columns.Add("ApeMaterno");
        dt.Columns.Add("Telefono");
        dt.Columns.Add("Direccion");
        dt.Columns.Add("FechaNac");
        dt.Columns.Add("Sexo");
        dt.Columns.Add("Estado");
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
        gvEmpleado.Columns[0].Visible = false;
        string dniBus = txtBusDni.Value;
        int contId = 0;
        tbodyCol.Attributes.Add("style", "display:none;");
        divControlDni.Attributes.Add("style", "display:block;");
        gvEmpleado.Visible = true;
        DataTable dt = obEmpl.BuscarEmpleado(dniBus);
        gvEmpleado.DataSource = dt;
        gvEmpleado.DataBind();
        DataTable dtArea = obArea.ListarArea();
        DataTable dtSexo = obEmpl.ListarSexo();
        foreach (GridViewRow item in gvEmpleado.Rows)
        {
            int idArea = Convert.ToInt32(dt.Rows[contId][1]);
            char sexo = Convert.ToChar(dt.Rows[contId][9]);
            ((DropDownList)item.FindControl("cmbArea")).DataSource = dtArea;
            ((DropDownList)item.FindControl("cmbArea")).DataTextField = "Nombre";
            ((DropDownList)item.FindControl("cmbArea")).DataValueField = "IdArea";
            ((DropDownList)item.FindControl("cmbArea")).SelectedValue = idArea.ToString();
            ((DropDownList)item.FindControl("cmbArea")).DataBind();

            ((DropDownList)item.FindControl("cmbSexo")).DataSource = dtSexo;
            ((DropDownList)item.FindControl("cmbSexo")).DataTextField = "Sexo";
            ((DropDownList)item.FindControl("cmbSexo")).DataValueField = "Sexo";
            ((DropDownList)item.FindControl("cmbSexo")).SelectedValue = sexo.ToString();
            ((DropDownList)item.FindControl("cmbSexo")).DataBind();
            contId++;
        }
        txtDni1.Value = "";
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
            dt.Rows[i][7] = Request["txtFNac" + (i + 1)];
            dt.Rows[i][8] = Request["cmbSex" + (i + 1)];
            dt.Rows[i][9] = 1;
            
        }
        //grid.DataSource = dt;
        //grid.DataBind();
        ds.Tables.Add(dt);
        obEmpl.InsertEmpleado(ds);
    }

    protected void btnBusPat_Click(object sender, EventArgs e)
    {

    }

    protected void btnBusMat_Click(object sender, EventArgs e)
    {

    }


    protected void btnBusNom_Click(object sender, EventArgs e)
    {

    }
}