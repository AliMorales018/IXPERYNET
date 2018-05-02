using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.Core.Entities;
using Dominio.Main.Module;

public partial class Aplicaciones_Logistica_Categoria : System.Web.UI.Page
{
    private int cont = 1;
    BCategoria obCategoria = new BCategoria();
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataTable TBNomFam = new DataTable();
        cmbFam.DataSource = obCategoria.LlenarCombo();
        cmbFam.DataTextField = "NOMBRE DE CATEGORIA";
        cmbFam.DataValueField = "ID DE CATEGORIA";
        cmbFam.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable DTcol1 = new DataTable("TBCATEGORIA");
        DTcol1.Columns.Add("Familia");//columna 1
        DTcol1.Columns.Add("Categoria");//columna 2
        int fila = Convert.ToInt32(Hc.Value);
        for (int i = 0; i < fila; i++)
        {
            DataRow f = DTcol1.NewRow();
            f[0] = Request["txtNomFam" + cont];
            f[1] = Request["txtNomFam" + cont];
            DTcol1.Rows.Add(f);
            cont++;
        }
        //DTcol1.WriteXml("E:/Familia.xml");
        //ConvertDatatableToXML(DTcol1);
    }
}