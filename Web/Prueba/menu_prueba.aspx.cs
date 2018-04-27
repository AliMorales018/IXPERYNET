using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prueba_menu_prueba : System.Web.UI.Page
{
    public string valor = "";
    public string valor2 = "";
    public string valor3 = "";
    public string valor4 = "";
    private int cantMaes = 0;
    TreeNode padre = null;
    TreeNode hijo = null;
    TreeNode subhijo = null;
    TreeNode nieto = null;
    protected void Page_Load(object sender, EventArgs e){}
    protected void Button1_Click(object sender, EventArgs e)
    {
       /* consultaItems();
       // int cantMaes = 0;
        cantMaes = Menu1.Items.Count;*/  
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TV1.Nodes.Clear();
        consutaItems2();
    }
    protected void consutaItems2()
    {
        TreeNode padre = null;
        TreeNode hijo = null;
        foreach (MenuItem item in Menu1.Items)
        {
          //  MenuItem Oneitem = new MenuItem();
            valor = item.Text;//obtengo nombre cabecera
            padre = new TreeNode(valor);//add al nodo principal
            foreach (MenuItem otroItem in item.ChildItems)
            {
                valor2 = otroItem.Text;//nombre del hijo
                hijo = new TreeNode(valor2);//
                padre.ChildNodes.Add(hijo);
                    if (otroItem.ChildItems.Count > 0)
                    {
                        SubMenu(otroItem,hijo);
                    }
            }
            TV1.Nodes.Add(padre);
        }
    }
    private void SubMenu(MenuItem otroItem, TreeNode hijo)
    {
        foreach (MenuItem subitem in otroItem.ChildItems)
        {
            valor3 = subitem.Text;
            subhijo = new TreeNode(valor3);
            hijo.ChildNodes.Add(subhijo);
            if (subitem.ChildItems.Count > 0)
            {
                foreach (MenuItem nietoitem in subitem.ChildItems)
                {
                    if(nietoitem.ChildItems.Count>0)
                    {
                        SubMenu(nietoitem, subhijo);
                    }
                }
            }
        }
    }
}