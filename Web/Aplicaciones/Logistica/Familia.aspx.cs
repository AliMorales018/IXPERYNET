using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Dominio.Core.Entities;
using Infraestructura.Data.SqlServer;
using System.IO;

public partial class Familia : System.Web.UI.Page
{
    private int cont = 1;

    private string ConvertDatatableToXML(DataTable dt)
    {
        MemoryStream str = new MemoryStream();
        dt.WriteXml(str, true);
        str.Seek(0, SeekOrigin.Begin);
        StreamReader sr = new StreamReader(str);
        string xmlstr;
        xmlstr = sr.ReadToEnd();
        return (xmlstr);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DFamilia ofam = new DFamilia();
        DataTable DTcol1 = new DataTable("XTBC_FAMILIA");
        DTcol1.Columns.Add(ofam.nomFam);//col 1 de la BD
        int fila = Convert.ToInt32(Hc.Value);
        for (int i = 0; i < fila; i++)
        {
            DataRow f = DTcol1.NewRow();
            f[0] = Request["txtNomFam" + cont];
            DTcol1.Rows.Add(f);
            cont++;

        }
        //DTcol1.WriteXml("E:/Familia.xml");
        ConvertDatatableToXML(DTcol1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}