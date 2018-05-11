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

    DFamilia odfam = new DFamilia();
    BFamilia obfam = new BFamilia();
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
        //int fila = Convert.ToInt32(HBuscar.Value);
        //if (fila==1)
        //{
        string catBus = "";
        catBus = txtBusCate.Value;
        
        DataTable dtFam = obfam.ListarFamilia();
        cmbFam1.DataSource = dtFam;
        cmbFam1.DataTextField = "NOMBRE FAMILIA";
        cmbFam1.DataValueField = "ID FAMILIA";
        cmbFam1.DataBind();

        DataTable dt = obcat.BuscarCategoria(catBus);
        tbodyCol.Attributes.Add("style", "display:none;");
        gvCategoria.Visible = true;
        gvCategoria.DataSource = dt;
        gvCategoria.DataBind();
        // Bind the data to the control.


        //// Set the default selected item, if desired.
        //cmbFam1.SelectedIndex = 0;




        divControl.Attributes.Add("style", "display:block;");
        txtCategoria1.Value = "";
    }



    protected void gvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }

    protected void gvCategoria_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string nomCate = "";
        int idFam, idCate = 0;
        idCate = Convert.ToInt32((gvCategoria.Rows[e.RowIndex].FindControl("lblIdCate") as Label).Text.Trim());
        nomCate = (gvCategoria.Rows[e.RowIndex].FindControl("txtCat") as TextBox).Text.Trim();
        idFam = Convert.ToInt32((gvCategoria.Rows[e.RowIndex].FindControl("cmbFamilia") as TextBox).Text.Trim());
        obcat.UpdateCategoria(nomCate, idFam, idCate);
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
        int fila = Convert.ToInt32(HctblCategoria.Value);

        DataTable dt = obcat.RecuperarId();
        int id = Convert.ToInt16(dt.Rows[0][0].ToString());
        string sms = dt.Rows[0][1].ToString();
        for (int i = 0; i < fila; i++)
        {
            //NOMBRE DE LAS COLUMNAS DE CATEGORÍA SEGÚN LAS BASE DATOS
            string atriIdCat = odcat.idCat;
            string atriNomCat = odcat.nombreCat;
            string atriIdFam = odcat.idFam;
            string atriTabCat = odcat.nomTabCat;
            //CAPTURAMOS LOS VALORES DE LOS OBJETOS
            string txtCateg = Request["txtCategoria" + cont];
            string cmbIdFam = Request["cmbFam" + cont];

            XElement elemento = new XElement(atriTabCat,new XAttribute(atriIdCat,id), new XAttribute(atriNomCat, txtCateg), new XAttribute(atriIdFam, cmbIdFam));
            root.Add(elemento);
            cont++;
            id = id + 1;
        }
        //CONVERTIR A XML7
        xmlString = root.ToString();

        obcat.InsertCategoria(xmlString);
        txtCategoria1.Value = "";
        root.RemoveAll();
    }
}