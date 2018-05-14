using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Dominio.Core.Entities;
using Dominio.Main.Module;
using Infraestructura.Data.SqlServer;

public partial class Familia : System.Web.UI.Page
{
    BFamilia obFam = new BFamilia();
    EFamilia oeFam = new EFamilia();
    List<string> lista = new List<string>();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt.Columns.Add("NomFamilia");
    }
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (HctblFamilia.Value.Equals(string.Empty))
        {
            HctblFamilia.Value = "1";
        }
        for (int i = 0; i < Convert.ToInt32(HctblFamilia.Value); ++i)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows[i][0] = Request["txtFamilia" + (i + 1)];
        }
        //grid.DataSource = dt;
        //grid.DataBind();
        ds.Tables.Add(dt);
        obFam.InsertFamilia(ds);
    }
    protected void gvFamilia_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gvFamilia_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int idFam = Convert.ToInt32((gvFamilia.Rows[e.RowIndex].FindControl("lblIdFam") as Label).Text.Trim());
        string nomFam = (gvFamilia.Rows[e.RowIndex].FindControl("txtFam") as TextBox).Text.Trim();
        obFam.UpdateFamilia(idFam, nomFam);
    }

    protected void gvFamilia_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int idFam = Convert.ToInt32((gvFamilia.Rows[e.RowIndex].FindControl("lblIdFam") as Label).Text.Trim());
        obFam.DeleteFamilia(idFam);
    }

    protected void btnBusFam_Click(object sender, EventArgs e)
    {
        gvFamilia.Columns[0].Visible = false;
        string famBus = txtBusFam.Value;
        tbodyCol.Attributes.Add("style", "display:none;");
        divControl.Attributes.Add("style", "display:block;");
        gvFamilia.Visible = true;
        DataTable dt = obFam.BuscarFamilia(famBus);
        gvFamilia.DataSource = dt;
        gvFamilia.DataBind();
        txtFamilia1.Value = "";
    }


}