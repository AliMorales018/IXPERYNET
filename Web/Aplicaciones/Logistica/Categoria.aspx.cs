using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Dominio.Core.Entities;
using Dominio.Main.Module;
using Infraestructura.Data.SqlServer;
public partial class Aplicaciones_Logistica_Categoria : System.Web.UI.Page
{
    BCategoria obCate = new BCategoria();
    ECategoria oeCate = new ECategoria();
    BFamilia obFami = new BFamilia();
    List<string> lista = new List<string>();
    List<string> listaBuscar = new List<string>();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        obCate.llenarLista();
        int conList = obCate.getListCate().Count;
        for (int i = 1; i < conList; i++)
        {
            dt.Columns.Add(obCate.getListCate()[i]);
        }
        if (!IsPostBack)
        {
            cmbFam1.DataSource = obFami.Listar();
            cmbFam1.DataTextField = "NOMFAMILIA";
            cmbFam1.DataValueField = "IDFAMILIA";
            cmbFam1.DataBind();
        }
    }
    public static string DataTable_HTML2(DataTable dt, DataTable dtFamilia)
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
                    html += "<td style='display: none;'><div id='campo2' class='input-group input-group-sm'><input type = 'text' runat='server' id='txtIdCat" + cont + "' name='txtIdCat" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 1)
                {
                    html += "<td><div id='campo3' class='input-group input-group-sm'><input type='text' runat='server' id='txtCategoria" + cont + "' name='txtCategoria" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 2)
                {
                    int idFam = Convert.ToInt32(dt.Rows[i][j]);
                    string option = "";
                    for (int k = 0; k < dtFamilia.Rows.Count; k++)
                    {
                        if (idFam == Convert.ToInt32(dtFamilia.Rows[k][0]))
                        {
                            option += "<option value='" + dtFamilia.Rows[k][0] + "' selected>" + dtFamilia.Rows[k][1] + "</option>";
                        }
                        else
                        {
                            option += "<option value='" + dtFamilia.Rows[k][0] + "'>" + dtFamilia.Rows[k][1] + "</option>";
                        }
                    }
                    html += "<td><div id='campo4' class='input-group input-group-sm'><select runat='server' class='form-control' id='cmbFam" + cont + "' name='cmbFam" + cont + "'>" + option + "</select></div></td>";
                }
                else if (j == 3)
                {
                    html += "<td><div id='campo5'><button type='button' class='btn btn-danger mr-sm-2 btn-sm' id='btnE' runat='server' onclick='Dcate(" + dt.Rows[i][0].ToString() + "," + c + ");'>Eliminar</button></div></td>";
                    html += "<td><div id='campo6'><button type='button' class='btn btn-danger mr-sm-2 btn-sm' id='btnA' runat='server' onclick='Ucate(" + c + ");' >Actualizar</button></div></td>";
                }
            html += "</tr>";
        }
        //html += "</body>";
        return html;
    }
    void busCate()
    {
        string cateBus = txtBusCat.Value;
        divControlCat.Attributes.Add("style", "display:block;");
        string valores = "";
        string nom = cateBus;
        for (int i = 1; i < 2; i++)
        {
            listaBuscar.Add(obCate.getListCate()[i]);
        }
        if (txtBusCat.Value == "")
        {
            nom = "%";
        }

        valores = nom;
        DataTable dt = obCate.Buscar(listaBuscar, valores);
        DataTable dtFami = obFami.Listar();
        tbodyCol.InnerHtml = DataTable_HTML2(dt, dtFami);
    }
    protected void btnBusCat_Click(object sender, EventArgs e)
    {
        busCate();
    }
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (HctblCategoria.Value.Equals(""))
        {
            HctblCategoria.Value = "1";
        }
        for (int i = 0; i < Convert.ToInt32(HctblCategoria.Value); ++i)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows[i][0] = Request["txtCategoria" + (i + 1)];
            dt.Rows[i][1] = Request["cmbFam" + (i + 1)];
        }
        ds.Tables.Add(dt);
        obCate.Insertar(ds);
    }
    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        oeCate.idCategoria = Convert.ToInt32(Hdcate.Value);
        obCate.Eliminar(oeCate);
        busCate();
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int idFila = Convert.ToInt32(Hdcate.Value);
        int contLista = obCate.getListCate().Count;
        for (int i = 0; i < contLista; i++)
        {
            listaBuscar.Add(obCate.getListCate()[i]);
        }
        oeCate.idCategoria = Convert.ToInt32(Request["txtIdCat" + idFila]);
        string nom = Request["txtCategoria" + idFila];
        int idFam = Convert.ToInt32(Request["cmbFam" + idFila]);

        string valores = nom + ";" + idFam;
        obCate.Modificar(oeCate, listaBuscar, valores);
    }
}