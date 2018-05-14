using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Dominio.Core.Entities;
using Dominio.Main.Module;
using Infraestructura.Data.SqlServer;
public partial class Aplicaciones_Logistica_Categoria : System.Web.UI.Page
{
    BCategoria obCat = new BCategoria();
    ECategoria oeCat = new ECategoria();
    DFamilia odFam = new DFamilia();
    BFamilia obFam = new BFamilia();
    List<string> lista = new List<string>();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt.Columns.Add("NomCategoria");
        dt.Columns.Add("IdFamilia");
        if (!IsPostBack)
        {
            //LLENANDO EL COMBO CON LOS DATOS DE FAMILIA
            cmbFam1.DataSource = obFam.LlenarCombo();
            cmbFam1.DataTextField = "NOMBRE FAMILIA";
            cmbFam1.DataValueField = "ID FAMILIA";
            cmbFam1.DataBind();
        }
    }
    protected void btnBusCat_Click(object sender, EventArgs e)
    {
        gvCategoria.Columns[0].Visible = false;
        //int fila = Convert.ToInt32(HBuscar.Value);
        //if (fila==1)
        //{
        string catBus = txtBusCate.Value;
        int contIdFam = 0;
        tbodyCol.Attributes.Add("style", "display:none;");
        divControl.Attributes.Add("style", "display:block;");
        gvCategoria.Visible = true;
        DataTable dt = obCat.BuscarCategoria(catBus);
        gvCategoria.DataSource = dt;
        gvCategoria.DataBind();
        DataTable dtFam = obFam.ListarFamilia();
        foreach (GridViewRow item in gvCategoria.Rows)
        {
            int idFam = Convert.ToInt32(dt.Rows[contIdFam][2]);
            ((DropDownList)item.FindControl("cmbFamilia")).DataSource = dtFam;
            ((DropDownList)item.FindControl("cmbFamilia")).DataTextField = "NOMBRE FAMILIA";
            ((DropDownList)item.FindControl("cmbFamilia")).DataValueField = "ID FAMILIA";
            ((DropDownList)item.FindControl("cmbFamilia")).SelectedValue = idFam.ToString();
            ((DropDownList)item.FindControl("cmbFamilia")).DataBind();
            contIdFam++;
        }
        txtCategoria1.Value = "";
    }
    protected void gvCategoria_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int idCate = Convert.ToInt32((gvCategoria.Rows[e.RowIndex].FindControl("lblIdCate") as Label).Text.Trim());
        string nomCate = (gvCategoria.Rows[e.RowIndex].FindControl("txtCat") as TextBox).Text.Trim();
        int idFam = Convert.ToInt32((gvCategoria.Rows[e.RowIndex].FindControl("cmbFamilia") as DropDownList).SelectedValue);
        obCat.UpdateCategoria(nomCate, idFam, idCate);
    }
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (HctblCategoria.Value.Equals(string.Empty))
        {
            HctblCategoria.Value = "1";
        }
        for (int i = 0; i < Convert.ToInt32(HctblCategoria.Value); ++i)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows[i][0] = Request["txtCategoria" + (i + 1)];
            dt.Rows[i][1] = Request["cmbFam" + (i + 1)];
        }
        //grid.DataSource = dt;
        //grid.DataBind();
        ds.Tables.Add(dt);
        obCat.InsertCategoria(ds);
    }
    protected void gvCategoria_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int idCat = Convert.ToInt32((gvCategoria.Rows[e.RowIndex].FindControl("lblIdCate") as Label).Text.Trim());
        obCat.DeleteCategoria(idCat);
    }
    protected void gvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}