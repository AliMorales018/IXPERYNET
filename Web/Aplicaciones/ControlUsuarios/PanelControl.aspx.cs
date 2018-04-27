using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Dominio.Core.Entities;
using Infraestructura.Data.SqlServer;

public partial class Usuario_PanelControl : System.Web.UI.Page
{
    DMenuPerfil com = new DMenuPerfil();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int idApliReq = Int32.Parse(Request.QueryString["apli"]);
            int idPerf = Int32.Parse(Request.QueryString["perf"]);

      
            DataTable dtMenuItems = com.ConsultarMenuPerfApli( 
                new EMenuPerfil {
                    oPerfil = new EPerfil {
                                  oAplicacion = new EAplicacion {        
                                      idApli = idApliReq
                                  },

                                  idPerfil = idPerf
                              }
                }        
            );

            foreach (DataRow drMenuItem in dtMenuItems.Rows)
            {
                if (drMenuItem["N_IdMenu"].Equals(drMenuItem["N_IdPadre"]))
                {
                    MenuItem mnuMenuItem = new MenuItem();
                    mnuMenuItem.Value = Convert.ToString(drMenuItem["N_IdMenu"]);
                    mnuMenuItem.Text = Convert.ToString(drMenuItem["V_Descripcion"]);
                    mnuMenuItem.ImageUrl = drMenuItem["V_Icono"].ToString();

                    mnuMenuItem.NavigateUrl = drMenuItem["V_Url"].ToString();
                    mnuMain.Items.Add(mnuMenuItem);
                    AddMenuItem(mnuMenuItem, dtMenuItems);
                }
            }
        }
    }

    public void InitComponents() {
        
    }

    private void AddMenuItem(MenuItem mnuMenuItem, DataTable dtMenuItems)
    {
        foreach (DataRow drMenuItem in dtMenuItems.Rows)
        {
            if (Convert.ToString(drMenuItem["N_IdPadre"]).Equals(mnuMenuItem.Value) && !drMenuItem["N_IdMenu"].Equals(drMenuItem["n_IdPadre"]))
            {
                MenuItem mnuNewMenuItem = new MenuItem();

                mnuNewMenuItem.Value = Convert.ToString(drMenuItem["N_IdMenu"]);
                mnuNewMenuItem.Text = Convert.ToString(drMenuItem["V_Descripcion"]);
                mnuNewMenuItem.ImageUrl = Convert.ToString(drMenuItem["V_Icono"]);
                mnuNewMenuItem.NavigateUrl = Convert.ToString(drMenuItem["V_Url"]);

                mnuMenuItem.ChildItems.Add(mnuNewMenuItem);
                AddMenuItem(mnuNewMenuItem, dtMenuItems);
            }
        }
    }
}