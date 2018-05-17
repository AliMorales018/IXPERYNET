using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Dominio.Core.Entities;
using Dominio.Main.Module;
//using Infraestructura.Data.SqlServer;

public partial class Usuario_PanelControl : System.Web.UI.Page
{
	//DMenuPerfil com = new DMenuPerfil();
	BMenuPerfil obMePer = new BMenuPerfil();
	BMenu obMenu = new BMenu();
	BAplicacion obApp = new BAplicacion();
	DataSet ds = new DataSet();
	DataTable dtMain = new DataTable();
	int sigMeItem = 0;
	int fila = 0;

	protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"]!=null)
			{
                int idApliReq = Int32.Parse(Session["idAplicacion"].ToString());
                int idPerf = Int32.Parse(Session["idPerfil"].ToString());
                DataTable dtMenuItems = obMePer.ConsultarMenuPerfApli(
                    new EMenuPerfil
					{
                        oPerfil = new EPerfil
						{
                            oAplicacion = new EAplicacion
							{
                                idApli = idApliReq
                            },
                            idPerfil = idPerf
                        }
                    }
                );
				DataTable pru = dtMenuItems;
				obMenu.LlenarMenuAl();
				if (Convert.ToInt32(Session["Usuario"]) != 1)
				{
					mnuMain.Items.Clear();
					foreach (DataRow drMenuItem in dtMenuItems.Rows)
					{
						//if (drMenuItem["N_IdMenu"].Equals(drMenuItem["N_IdPadre"]))
						if (drMenuItem[obMenu.getMenuAl()[0]].Equals(drMenuItem[obMenu.getMenuAl()[2]]))
						{
							MenuItem mnuMenuItem = new MenuItem();
							mnuMenuItem.Value = Convert.ToString(drMenuItem[obMenu.getMenuAl()[0]]);
							mnuMenuItem.Text = Convert.ToString(drMenuItem[obMenu.getMenuAl()[1]]);
							mnuMenuItem.ImageUrl = drMenuItem[obMenu.getMenuAl()[4]].ToString();

							mnuMenuItem.NavigateUrl = drMenuItem[obMenu.getMenuAl()[6]].ToString();
							mnuMain.Items.Add(mnuMenuItem);
							AddMenuItem(mnuMenuItem, dtMenuItems);
						}
					}
				}


            }
            else {
                Response.Redirect("/Aplicaciones/ControlUsuarios/Login.aspx");
            }
        }
    }

    public void InitComponents() {
        
    }

    private void AddMenuItem(MenuItem mnuMenuItem, DataTable dtMenuItems)
    {
        foreach (DataRow drMenuItem in dtMenuItems.Rows)
        {
            if (Convert.ToString(drMenuItem[obMenu.getMenuAl()[2]]).Equals(mnuMenuItem.Value)
				&& !drMenuItem[obMenu.getMenuAl()[0]].Equals(drMenuItem[obMenu.getMenuAl()[2]]))
            {
                MenuItem mnuNewMenuItem = new MenuItem();

                mnuNewMenuItem.Value = Convert.ToString(drMenuItem[obMenu.getMenuAl()[0]]);
                mnuNewMenuItem.Text = Convert.ToString(drMenuItem[obMenu.getMenuAl()[1]]);
                mnuNewMenuItem.ImageUrl = Convert.ToString(drMenuItem[obMenu.getMenuAl()[4]]);
                mnuNewMenuItem.NavigateUrl = Convert.ToString(drMenuItem[obMenu.getMenuAl()[6]]);

                mnuMenuItem.ChildItems.Add(mnuNewMenuItem);
                AddMenuItem(mnuNewMenuItem, dtMenuItems);
            }
        }
    }

	

	public void TablaMenu(Menu menu)
	{
		obMenu.LlenarMenuAl();
		//dtMain.Columns.Add("Nro", typeof(Int32));
		//string a = obMenu.getMenuAl()[0];

		dtMain.Columns.Add(obMenu.getMenuAl()[0]);
		dtMain.Columns.Add(obMenu.getMenuAl()[1]);
		dtMain.Columns.Add(obMenu.getMenuAl()[2]);
		dtMain.Columns.Add(obMenu.getMenuAl()[3]);
		dtMain.Columns.Add(obMenu.getMenuAl()[4]);
		dtMain.Columns.Add(obMenu.getMenuAl()[5]);
		dtMain.Columns.Add(obMenu.getMenuAl()[6]);
		dtMain.Columns.Add(obMenu.getMenuAl()[7]);

		foreach (MenuItem menuItem in menu.Items)
		{
			DataRow dr = dtMain.NewRow();
			menuItem.Value= Convert.ToString(fila + 1 + sigMeItem);
			dtMain.Rows.Add(dr);
			dtMain.Rows[fila][0] = menuItem.Value;
			dtMain.Rows[fila][1] = menuItem.Text;
			dtMain.Rows[fila][2] = fila + 1 + sigMeItem;
			dtMain.Rows[fila][3] = 1;
			dtMain.Rows[fila][4] = "";
			dtMain.Rows[fila][5] = true;
			dtMain.Rows[fila][6] = "";
			dtMain.Rows[fila][7] = 1;
			++fila;
			ChildCollection(menuItem);
		}
	}

	
	public MenuItemCollection ChildCollection(MenuItem meItem)
	{
		MenuItemCollection meItCollection = new MenuItemCollection();
		foreach (MenuItem meIt in meItem.ChildItems)
		{
			DataRow drItem = dtMain.NewRow();
			meIt.Value = Convert.ToString(fila + 1 + sigMeItem);
			dtMain.Rows.Add(drItem);
			dtMain.Rows[fila][0] = meIt.Value;
			dtMain.Rows[fila][1] = meIt.Text;
			dtMain.Rows[fila][2] = meIt.Parent.Value;
			dtMain.Rows[fila][3] = 1;
			dtMain.Rows[fila][4] = "";
			dtMain.Rows[fila][5] = true;
			dtMain.Rows[fila][6] = "";
			dtMain.Rows[fila][7] = 1;
			++fila;

			foreach (MenuItem mIt in ChildCollection(meIt))
			{
				string valor = mIt.Value;
				DataRow drItemNew = dtMain.NewRow();
				mIt.Value = Convert.ToString(fila + 1 + sigMeItem);
				dtMain.Rows.Add(drItemNew);
				dtMain.Rows[fila][0] = mIt.Value;
				dtMain.Rows[fila][1] = mIt.Text;
				dtMain.Rows[fila][2] = meIt.Parent.Value;
				dtMain.Rows[fila][3] = 1;
				dtMain.Rows[fila][4] = "";
				dtMain.Rows[fila][5] = true;
				dtMain.Rows[fila][6] = "";
				dtMain.Rows[fila][7] = 1;
				++fila;
			}
		}
		DataTable dtA = dtMain;
		return meItCollection;
	}


	protected void BtnMenu_Click(object sender, EventArgs e)
	{
		TablaMenu(mnuMain);
		ds.Tables.Add(dtMain);
		obMenu.InsertarMenu(ds);
	}
}