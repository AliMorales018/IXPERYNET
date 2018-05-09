using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Dominio.Core.Entities;
using Dominio.Main.Module;
using Infraestructura.Data.SqlServer;

public partial class Aplicaciones_Logistica_Producto : System.Web.UI.Page
{
    private int cont = 1;
    DProducto odpro = new DProducto();
    BProducto obpro = new BProducto();

    protected void Page_Load(object sender, EventArgs e)
    {
        BCategoria obCategoria = new BCategoria();
        BUnidMedida obUmedida = new BUnidMedida();
        if (!IsPostBack)
        {
            //LLENANDO EL COMBO CON LOS DATOS DE CATEGORÍA
            cmbCat1.DataSource = obCategoria.LlenarCombo();
            cmbCat1.DataTextField = "NOMBRE CATEGORIA";
            cmbCat1.DataValueField = "ID CATEGORIA";
            cmbCat1.DataBind();
            //LLENANDO EL COMBO CON LOS DATOS DE UNIDAD MEDIDA
            cmbUmed1.DataSource = obUmedida.LlenarCombo();
            cmbUmed1.DataTextField = "NOMBRE UMEDIDA";
            cmbUmed1.DataValueField = "ID UMEDIDA";
            cmbUmed1.DataBind();
        }

    }

    protected void gvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gvProducto_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }

    protected void btnBusCate_Click(object sender, EventArgs e)
    {
       
    }

    protected void btnBusProd_Click(object sender, EventArgs e)
    {
        string prodBus = "";
        prodBus = txtBusProd.Value;
        DataTable dt = obpro.BuscarProducto(prodBus);
        tbodyCol.Attributes.Add("style", "display:none;");
        gvProducto.Visible = true;
        gvProducto.DataSource = dt;
        gvProducto.DataBind();
        divControlProd.Attributes.Add("style", "display:block;");
        txtProducto1.Value = "";
    }

 
}