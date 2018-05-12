using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using Dominio.Main.Module;

public partial class Aplicaciones_ControlUsuarios_MaterUsuarios : System.Web.UI.Page{

    BUsuario obUsuario = new BUsuario();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtParseado = new DataTable();
        DataTable dt = obUsuario.LlenarComboEmpleado();
        String NomComp;
        String Id;
        dtParseado.Columns.Add("NOMBRE COMPLETO");
        dtParseado.Columns.Add("ID EMPLEADO");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow f = dtParseado.NewRow();
            DataRow row = dt.Rows[i];
            NomComp = row["NOMBRE"].ToString() +" "+row["APELLIDO PATERNO"].ToString()+" "+row["APELLIDO MATERNO"].ToString();
            Id = row["ID EMPLEADO"].ToString();
            f[0] = NomComp;
            f[1] = Id;
            dtParseado.Rows.Add(f);
        }
        select1.DataSource = dtParseado;
        select1.DataTextField = "NOMBRE COMPLETO";
        select1.DataValueField = "ID EMPLEADO";
        select1.DataBind();
    }

    DataTable dtUser = new DataTable();

    protected void RecorrerTabla() {
        DataTable DTcol1 = new DataTable("XTBC_USER");
        DTcol1.Columns.Add("V_Nombres");
        DTcol1.Columns.Add("V_Paterno");
        DTcol1.Columns.Add("V_Materno");
        DTcol1.Columns.Add("V_Login");
        DTcol1.Columns.Add("V_Clave");
        DTcol1.Columns.Add("N_IdPersonal");
        int fila = Convert.ToInt32(HctblUsuarios.Value);
        int cont = 1;

        for (int i = 0; i < fila; i++)
        {
            DataRow f = DTcol1.NewRow();
            f[0] = Request["txtNombre" + cont];
            f[1] = Request["txtApellidoP" + cont];
            f[2] = Request["txtApellidoM" + cont];
            f[3] = Request["txtUsuario" + cont];
            f[4] = Request["txtClave" + cont];
            f[5] = Request["select" + cont];
            DTcol1.Rows.Add(f);
            cont++;
        }
        //DTcol1.WriteXml("F:/usuarios.xml",);
    }

    private String CovertDataTableToXML(DataTable dt) {
        MemoryStream str = new MemoryStream();
        dt.WriteXml(str,true);
        str.Seek(0,SeekOrigin.Begin);
        StreamReader sr = new StreamReader(str);
        string xmlstr;
        xmlstr = sr.ReadToEnd();
        return (xmlstr);
    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        RecorrerTabla();
    }

    protected void Guardar() {

    }
}