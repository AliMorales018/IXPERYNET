using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.Core.Entities;
using Dominio.Main.Module;
using Infraestructura.Data.SqlServer;

public partial class Aplicaciones_Logistica_Categoria : System.Web.UI.Page
{
    private int cont = 1;
    BFamilia obFamilia = new BFamilia();
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataTable TBNomFam = new DataTable();
        cmbFam1.DataSource = obFamilia.LlenarCombo();
        cmbFam1.DataTextField = "NOMBRE";
        cmbFam1.DataValueField = "ID";
        cmbFam1.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable DTcol1 = new DataTable("TBCATEGORIA");
        DTcol1.Columns.Add("Familia");//columna 1
        DTcol1.Columns.Add("Categoria");//columna 2
        int fila = Convert.ToInt32(Hc.Value);
        string valor = "";
        valor = txtCategoria1.Value;
        for (int i = 0; i < fila; i++)
        {
            DataRow f = DTcol1.NewRow();
            f[0] = Request["cmbFam" + cont];
            f[1] = Request["txtCategoria" + cont];
            DTcol1.Rows.Add(f);
            cont++;
        }
        //DTcol1.WriteXml("E:/Familia.xml");
        //ConvertDatatableToXML(DTcol1);
    }
}