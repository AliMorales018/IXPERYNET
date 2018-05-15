﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Dominio.Core.Entities;
using Dominio.Main.Module;
using Infraestructura.Data.SqlServer;
using System.Web.UI.HtmlControls;
public partial class Aplicaciones_Logistica_Empleado : System.Web.UI.Page
{
    //   DEmpleado odEmpl = new DEmpleado();
    BEmpleado obEmpl = new BEmpleado();
    EEmpleado oeEmpl = new EEmpleado();
    BArea obArea = new BArea();
    List<string> lista = new List<string>();
    List<string> listaBuscar = new List<string>();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        obEmpl.llenarLista();
        int conList = obEmpl.getListEmpl().Count;
        for (int i = 1; i < conList; i++)
        {
            dt.Columns.Add(obEmpl.getListEmpl()[i]);
        }
        if (!IsPostBack)
        {

            //LLENANDO EL COMBO CON LOS DATOS DE ÁREA---ESPERAR A MIGUEL QUE CREE LA TABLA AREA
            cmbArea1.DataSource = obArea.LlenarCombo();
            cmbArea1.DataTextField = "Nombre";
            cmbArea1.DataValueField = "IdArea";
            cmbArea1.DataBind();
        }
    }
    public static string DataTable_HTML2(DataTable dt, DataTable dtArea)
    {
        string html = "";
        int cont = 0;
        int columnas = dt.Columns.Count;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int c = i+1;
            html += "<tr id='" + c + "'>";
           
            for (int j = -1; j < columnas; j++)

                if (j == -1)
                {
                    cont++;
                    html += "<td>" + cont + "</td>";
                }
                else if (j == 0)
                {
                    int idArea = Convert.ToInt32(dt.Rows[i][j]);
                    string option = "";
                    for (int k = 0; k < dtArea.Rows.Count; k++)
                    {
                        if (idArea == Convert.ToInt32(dtArea.Rows[k][0]))
                        {
                            option += "<option value='" + dtArea.Rows[k][0] + "' selected>" + dtArea.Rows[k][1] + "</option>";
                        }
                        else
                        {
                            option += "<option value='" + dtArea.Rows[k][0] + "'>" + dtArea.Rows[k][1] + "</option>";
                        }
                    }
                    html += "<td><div id='campo2' class='input-group input-group-sm'><select runat='server' class='form-control' id='cmbArea" + cont + "' >" + option + "</select></div></td>";
                }
            else if(j==1)
                {
                    html += "<td style='display:none;'><div id='campo3' class='input-group input-group-sm'><input type = 'text' runat='server' id='txtIdEmple" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 2)
                {
                    html += "<td><div id='campo4' class='input-group input-group-sm'><input type='text' runat='server' id='txtDni" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 3)
                {
                    html += "<td><div id='campo5' class='input-group input-group-sm'><input type = 'text' runat='server' id='txtNombre" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 4)
                {
                    html += "<td><div id='campo6' class='input-group input-group-sm'><input type='text' runat='server' id='txtApePa" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 5)
                {
                    html += "<td><div id ='campo7' class='input-group input-group-sm'><input type = 'text' runat='server' id='txtApeMat" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 6)
                {
                    html += "<td><div id='campo8' class='input-group input-group-sm'><input type='text' runat='server' id='txtTelef" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 7)
                {
                    html += "<td><div id='campo9' class='input-group input-group-sm'><input type = 'text' runat='server' id='txtDirec" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 8)
                {
                    html += "<td><div id='campo10' class='input-group input-group-sm'><input type='date' runat='server' id='txtFNac" + cont + "' class='form-control' value='" + dt.Rows[i][j].ToString() + "'/></div></td>";
                }
                else if (j == 9)
                {
                    string sel = dt.Rows[i][j].ToString();
                    string inputSel = "";
                    if (sel == "M")
                    {
                        inputSel = "<option value='M' selected>M</option><option value='F'>F</option>";
                    }
                    else
                    {
                        inputSel = "<option value='M'>M</option><option value='F' selected>F</option>";
                    }
                    html += "<td><div id='campo11' class='input-group input-group-sm'><select runat='server' id='cmbSex" + cont + "' class'form-control'>" + inputSel + "</select></div></td>";
                }
                else if (j == 10)
                {
                    html += "<td><div id='campo12'><button type='button' class='btn btn-danger mr-sm-2 btn-sm' id='btnE' runat='server' onclick='Demple(" + dt.Rows[i][0].ToString() + "," + i + ");'>Eliminar</button></div></td>";
                    html += "<td><div id='campo13'><button type='button' class='btn btn-danger mr-sm-2 btn-sm' id='btnA' runat='server' onclick='Uemple(" + c + ");' >Actualizar</button></div></td>";
                }
            html += "</tr>";
        }
        //html += "</body>";
        return html;
    }

    protected void btnBusDni_Click(object sender, EventArgs e)
    {
        busDni();
    }

    void busDni()
    {
        string dniBus = txtBusDni.Value;
        divControlDni.Attributes.Add("style", "display:block;");
        string valores = "";
        string dni = txtBusDni.Value;
        string nom = txtBusNom.Value;
        string pat = txtBusPat.Value;
        string mat = txtBusMat.Value;
        for (int i = 2; i < 6; i++)
        {
            listaBuscar.Add(obEmpl.getListEmpl()[i]);
        }
        if (txtBusDni.Value == "")
        {
            dni = "%";
        }
        if (txtBusNom.Value == "")
        {
            nom = "%";
        }
        if (txtBusPat.Value == "")
        {
            pat = "%";
        }
        if (txtBusMat.Value == "")
        {
            mat = "%";
        }
        valores = dni + ";" + nom + ";" + pat + ";" + mat;


        //odEmpl.lstEmplAli;
        DataTable dt = obEmpl.Buscar(listaBuscar, valores);
        DataTable dtArea = obArea.ListarArea();
        tbodyCol.InnerHtml = DataTable_HTML2(dt, dtArea);
    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (HctblEmpleado.Value.Equals(""))
        {
            HctblEmpleado.Value = "1";
        }
        for (int i = 0; i < Convert.ToInt32(HctblEmpleado.Value); ++i)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows[i][0] = Request["cmbArea" + (i + 1)];
            dt.Rows[i][1] = Request["txtDni" + (i + 1)];
            dt.Rows[i][2] = Request["txtNombre" + (i + 1)];
            dt.Rows[i][3] = Request["txtApePat" + (i + 1)];
            dt.Rows[i][4] = Request["txtApeMat" + (i + 1)];
            dt.Rows[i][5] = Request["txtTelef" + (i + 1)];
            dt.Rows[i][6] = Request["txtDirec" + (i + 1)];
            dt.Rows[i][7] = Request["txtFNac" + (i + 1)];
            dt.Rows[i][8] = Request["cmbSex" + (i + 1)];
            dt.Rows[i][9] = 1;

        }
        //grid.DataSource = dt;
        //grid.DataBind();
        ds.Tables.Add(dt);
        obEmpl.Insertar(ds);
    }

    protected void btnBusPat_Click(object sender, EventArgs e)
    {

    }

    protected void btnBusMat_Click(object sender, EventArgs e)
    {

    }


    protected void btnBusNom_Click(object sender, EventArgs e)
    {

    }

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        oeEmpl.idEmpleado = Convert.ToInt32(Hdemp.Value);
        obEmpl.Eliminar(oeEmpl);
        busDni();
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int idFila = Convert.ToInt32(Hdemp.Value);
        int contLista = obEmpl.getListEmpl().Count;
        for (int i = 0; i < contLista; i++)
        {
            listaBuscar.Add(obEmpl.getListEmpl()[i]);
        }
        //string cad = Request["txtNombre" + idFila];
        string cad = Request["txtTelef1"];
        //int idArea = Convert.ToInt32((WebControl)tblEmpleado.Rows[idFila].Cells[1].FindControl("cmbArea" + idFila));
        //char dni = Convert.ToChar((WebControl)tblEmpleado.Rows[idFila].Cells[2].FindControl("txtDni" + idFila));
        string nom = Convert.ToString((HtmlInputText)Page.FindControl("txtNombre" + idFila));
        //string apePat = Convert.ToString((WebControl)tblEmpleado.Rows[idFila].Cells[4].FindControl("txtApePat" + idFila));
        //int apeMat = Convert.ToInt32((WebControl)tblEmpleado.Rows[idFila].Cells[5].FindControl("txtApeMat" + idFila));
        //int tel = Convert.ToInt32((WebControl)tblEmpleado.Rows[idFila].Cells[6].FindControl("txtTelef" + idFila));
        //int dir = Convert.ToInt32((WebControl)tblEmpleado.Rows[idFila].Cells[7].FindControl("txtDirec" + idFila));
        //int fNac = Convert.ToInt32((WebControl)tblEmpleado.Rows[idFila].Cells[8].FindControl("txtFNac" + idFila));
        //int sexo = Convert.ToInt32((WebControl)tblEmpleado.Rows[idFila].Cells[9].FindControl("cmbSex" + idFila));
        int idEstado = 1;
        
        //string dniBus = txtBusDni.Value;
        //divControlDni.Attributes.Add("style", "display:block;");
        //string valores = "";
        //string dni = txtBusDni.Value;
        //string nom = txtBusNom.Value;
        //string pat = txtBusPat.Value;
        //string mat = txtBusMat.Value;


        
        
        //valores = dni + ";" + nom + ";" + pat + ";" + mat;
    }
}