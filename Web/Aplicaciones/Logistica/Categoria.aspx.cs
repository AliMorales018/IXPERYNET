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
public partial class Aplicaciones_Logistica_Categoria : System.Web.UI.Page
{
    private int cont = 1;

    //DataTable dtCate = new DataTable();
    //DFamilia ofam = new DFamilia();

    DCategoria odcat = new DCategoria();
    BCategoria obcat = new BCategoria();

    protected void Page_Load(object sender, EventArgs e)
    {
        BFamilia obFamilia = new BFamilia();
        if (!IsPostBack)
        {
            //LLENANDO EL COMBO CON LOS DATOS DE FAMILIA
            cmbFam1.DataSource = obFamilia.LlenarCombo();
            cmbFam1.DataTextField = "NOMBRE FAMILIA";
            cmbFam1.DataValueField = "ID FAMILIA";
            cmbFam1.DataBind();
        }
    }



    protected void btnBusCat_Click(object sender, EventArgs e)
    {
        ////int fila = Convert.ToInt32(HBuscar.Value);
        ////if (fila==1)
        ////{
        //    string catBus = "";
        //    catBus = txtBusCate.Value;
        //    DataTable dt = obcat.BuscarCategoria(catBus);
        //    tbodyCol.Attributes.Add("style", "display:none;");
        //    gvCategoria.Visible = true;
        //    gvCategoria.DataSource = dt;
        //    gvCategoria.DataBind();
        //    divControl.Attributes.Add("style", "display:block;");
        //    txtCategoria1.Value = "";
        //}
        
    }

    protected void gvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }

    protected void gvCategoria_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {      
        //string  nomCate = "";
        //int idFam, idCate=0;
        //idCate = Convert.ToInt32((gvCategoria.Rows[e.RowIndex].FindControl("lblIdCate") as Label).Text.Trim());
        //nomCate = (gvCategoria.Rows[e.RowIndex].FindControl("txtCat") as TextBox).Text.Trim();
        //idFam = Convert.ToInt32((gvCategoria.Rows[e.RowIndex].FindControl("cmbFamilia") as TextBox).Text.Trim());
        //obcat.UpdateCategoria(nomCate,idFam,idCate);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "mostrarmensaje", "prueba();", true);
    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        XDocument xmlDoc = new XDocument();
        xmlDoc.Declaration = new XDeclaration("1.0", "utf-8", "yes");
        XElement root = new XElement("ROOT");
        xmlDoc.Add(root);
        string xmlString = "";
        // int fila = 1;
        int fila = Convert.ToInt32(HctblCategoria.Value);
        // int cont = 1;
        for (int i = 0; i < fila; i++)
        {
            //NOMBRE DE LAS COLUMNAS DE CATEGORÍA SEGÚN LAS BASE DATOS
            string atriNomCat = odcat.nombreCat;
            string atriIdFam = odcat.idFam;
            string atriTabCat = odcat.nomTabCat;
            //CAPTURAMOS LOS VALORES DE LOS OBJETOS
            string txtCateg = Request["txtCategoria" + cont];
            string cmbIdFam = Request["cmbFam" + cont];
            XElement elemento = new XElement(atriTabCat, new XAttribute(atriNomCat, txtCateg), new XAttribute(atriIdFam, cmbIdFam));
            root.Add(elemento);
            cont++;

        }
        //CONVERTIR A XML
        xmlString = root.ToString();
        obcat.InsertCategoria(xmlString);
        txtCategoria1.Value = "";
        root.RemoveAll();
    }
}