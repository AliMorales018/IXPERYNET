using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Dominio.Main.Module;
using Infraestructura.Data.SqlServer;

public partial class Aplicaciones_Logistica_Producto : System.Web.UI.Page
{
    DProducto odpro = new DProducto();
    BProducto obpro = new BProducto();
    BCategoria obCat = new BCategoria();
    BUnidMedida obUmed = new BUnidMedida();
    List<string> lista = new List<string>();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        dt.Columns.Add("NomProd");
        dt.Columns.Add("CantProd");
        dt.Columns.Add("IdCate");
        dt.Columns.Add("IdUMed");
        if (!IsPostBack)
        {
            //LLENANDO EL COMBO CON LOS DATOS DE CATEGORÍA
            cmbCat1.DataSource = obCat.Listar();
            cmbCat1.DataTextField = "NOMBRE CATEGORIA";
            cmbCat1.DataValueField = "ID CATEGORIA";
            cmbCat1.DataBind();
            //LLENANDO EL COMBO CON LOS DATOS DE UNIDAD MEDIDA
            cmbUni1.DataSource = obUmed.LlenarCombo();
            cmbUni1.DataTextField = "NOMBRE UMEDIDA";
            cmbUni1.DataValueField = "ID UMEDIDA";
            cmbUni1.DataBind();
        }

    }




    protected void btnBusPro_Click(object sender, EventArgs e)
    {
        gvProducto.Columns[0].Visible = false;
        //int fila = Convert.ToInt32(HBuscar.Value);
        //if (fila==1)
        //{
        string proBus = txtBusPro.Value;
        int contId = 0;
        tbodyCol.Attributes.Add("style", "display:none;");
        divControl.Attributes.Add("style", "display:block;");
        gvProducto.Visible = true;
        DataTable dt = obpro.BuscarProducto(proBus);
        gvProducto.DataSource = dt;
        gvProducto.DataBind();
        DataTable dtCat = obCat.Listar();
        DataTable dtUMed = obUmed.ListarUMedida();
        foreach (GridViewRow item in gvProducto.Rows)
        {
            int idCat = Convert.ToInt32(dt.Rows[contId][1]);
            int idUMed = Convert.ToInt32(dt.Rows[contId][4]);
            ((DropDownList)item.FindControl("cmbCategoria")).DataSource = dtCat;
            ((DropDownList)item.FindControl("cmbCategoria")).DataTextField = "NOMBRE CATEGORIA";
            ((DropDownList)item.FindControl("cmbCategoria")).DataValueField = "ID CATEGORIA";
            ((DropDownList)item.FindControl("cmbCategoria")).SelectedValue = idCat.ToString();
            ((DropDownList)item.FindControl("cmbCategoria")).DataBind();

            ((DropDownList)item.FindControl("cmbUnidad")).DataSource = dtUMed;
            ((DropDownList)item.FindControl("cmbUnidad")).DataTextField = "NOMBRE UMEDIDA";
            ((DropDownList)item.FindControl("cmbUnidad")).DataValueField = "ID UMEDIDA";
            ((DropDownList)item.FindControl("cmbUnidad")).SelectedValue = idUMed.ToString();
            ((DropDownList)item.FindControl("cmbUnidad")).DataBind();
            contId++;
        }
        txtProducto1.Value = "";
    }

    protected void gvProducto_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int idProd = Convert.ToInt32((gvProducto.Rows[e.RowIndex].FindControl("lblIdProd") as Label).Text.Trim());
        obpro.DeleteProducto(idProd);
    }

    protected void gvProducto_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int idProd = Convert.ToInt32((gvProducto.Rows[e.RowIndex].FindControl("lblIdProd") as Label).Text.Trim());
        string nomProd = (gvProducto.Rows[e.RowIndex].FindControl("txtProd") as TextBox).Text.Trim();
        int canProd = Convert.ToInt32((gvProducto.Rows[e.RowIndex].FindControl("txtCant") as TextBox).Text.Trim());
        int idCat = Convert.ToInt32((gvProducto.Rows[e.RowIndex].FindControl("cmbCategoria") as DropDownList).SelectedValue);
        int idUMed = Convert.ToInt32((gvProducto.Rows[e.RowIndex].FindControl("cmbUnidad") as DropDownList).SelectedValue);
        obpro.UpdateProducto(idProd,nomProd,canProd,idCat,idUMed);
    }

    protected void gvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (HctblProducto.Value.Equals(string.Empty))
        {
            HctblProducto.Value = "1";
        }
        for (int i = 0; i < Convert.ToInt32(HctblProducto.Value); ++i)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows[i][0] = Request["txtProducto" + (i + 1)];
            dt.Rows[i][1] = Request["txtCantidad" + (i + 1)];
            dt.Rows[i][2] = Request["cmbCat" + (i + 1)];
            dt.Rows[i][3] = Request["cmbUni" + (i + 1)];
        }
        //grid.DataSource = dt;
        //grid.DataBind();
        ds.Tables.Add(dt);
        obpro.InsertProducto(ds);
    }
}