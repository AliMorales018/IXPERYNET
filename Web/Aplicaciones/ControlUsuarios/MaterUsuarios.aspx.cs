using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class Aplicaciones_ControlUsuarios_MaterUsuarios : System.Web.UI.Page{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    DataTable dtUser = new DataTable();

    protected void RecorrerTabla() {
        DataTable DTcol1 = new DataTable("XTB_USER");
        DTcol1.Columns.Add("V_Nombres");
        DTcol1.Columns.Add("ApellidoPaterno");
        DTcol1.Columns.Add("ApellidoMaterno");
        DTcol1.Columns.Add("Usuario");
        DTcol1.Columns.Add("Clave");
        int fila = Convert.ToInt32(Hc.Value);
        int cont = 1;

        for (int i = 0; i < fila; i++)
        {
            DataRow f = DTcol1.NewRow();
            f[0] = Request["txtNombre" + cont];
            f[1] = Request["txtApellidoP" + cont];
            f[2] = Request["txtApellidoM" + cont];
            f[3] = Request["txtUsuario" + cont];
            f[4] = Request["txtClave" + cont];
            DTcol1.Rows.Add(f);
            cont++;
        }
        DTcol1.WriteXml("F:/usuarios.xml");
    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        RecorrerTabla();
    }

    protected void Guardar() {

    }


}