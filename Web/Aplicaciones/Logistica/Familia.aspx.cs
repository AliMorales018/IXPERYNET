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
    List<string> listaBuscar = new List<string>();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        obFam.llenarLista();
        int conList = obFam.getListFam().Count;
        for (int i = 1; i < conList; i++)
        {
            dt.Columns.Add(obFam.getListFam()[i]);
        }
    }
    public static string DataTable_HTML2(DataTable dt)
    {
        string html = "";
        int cont = 0;
        int columnas = dt.Columns.Count + 1;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int c = i + 1;
            html += "<tr id='" + c + "'>";
            for (int j = -1; j < columnas; j++)
                if (j == -1)
                {
                    cont++;
                    html += "<td>" + cont + "</td>";
                }
                else if (j == 0)
                {
                    html += "<td style='display: none;'><div id='campo2' class='input-group input-group-sm'><input type = 'text' runat='server' id='txtIdFam" + cont + "' name='txtIdFam" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 1)
                {
                    html += "<td><div id='campo3' class='input-group input-group-sm'><input type = 'text' runat='server' id='txtFamilia" + cont + "' name='txtFamilia" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 2)
                {
                    html += "<td><div id='campo4'><button type='button' class='btn btn-danger mr-sm-2 btn-sm' id='btnE' runat='server' onclick='Demple(" + dt.Rows[i][0].ToString() + "," + i + ");'>Eliminar</button></div></td>";
                    html += "<td><div id='campo5'><button type='button' class='btn btn-danger mr-sm-2 btn-sm' id='btnA' runat='server' onclick='Uemple(" + c + ");' >Actualizar</button></div></td>";
                }
            html += "</tr>";
        }
        //html += "</body>";
        return html;
    }
    void busFam()
    {
        string famBus = txtBusFam.Value;
        divControlFam.Attributes.Add("style", "display:block;");
        string valores = "";
        string fam = txtBusFam.Value;

        for (int i = 1; i < 2; i++)
        {
            listaBuscar.Add(obFam.getListFam()[i]);
        }
        if (txtBusFam.Value == "")
        {
            fam = "%";
        }
        valores = fam;
        DataTable dt = obFam.Buscar(listaBuscar, valores);
        tbodyCol.InnerHtml = DataTable_HTML2(dt);
    }
    protected void btnBusFam_Click(object sender, EventArgs e)
    {
        busFam();
    }
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (HctblFamilia.Value.Equals(""))
        {
            HctblFamilia.Value = "1";
        }
        for (int i = 0; i < Convert.ToInt32(HctblFamilia.Value); ++i)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows[i][0] = Request["txtFamilia" + (i + 1)];
        }
        ds.Tables.Add(dt);
        obFam.Insertar(ds);
    }
    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        oeFam.idFamilia = Convert.ToInt32(Hdfam.Value);
        obFam.Eliminar(oeFam);
        busFam();
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int idFila = Convert.ToInt32(Hdfam.Value);
        int contLista = obFam.getListFam().Count;
        for (int i = 0; i < contLista; i++)
        {
            listaBuscar.Add(obFam.getListFam()[i]);
        }
        oeFam.idFamilia = Convert.ToInt32(Request["txtIdFam" + idFila]);
        string nomFam = Request["txtFamilia" + idFila];

        string valores = nomFam;
        obFam.Modificar(oeFam, listaBuscar, valores);
    }
}