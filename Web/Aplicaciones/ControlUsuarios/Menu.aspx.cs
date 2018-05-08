using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Xml.Linq;
using Dominio.Core.Entities;
using Dominio.Main.Module;

public partial class Aplicaciones_ControlUsuarios_Menu : System.Web.UI.Page
{
	EMenu oeMenu = new EMenu();
	EAplicacion oeApli = new EAplicacion();
	BAplicacion obApli = new BAplicacion();
	BMenu obMenu = new BMenu();
	DataTable DataSource;
	int apliSelec = 0;
	int perSelec = 0;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			ListarDdlAplicacion();
		}
	}

	protected void ListarDdlAplicacion()
	{
		DdlApli.DataSource = obApli.ListarAplicaciones();
		DdlApli.DataValueField = obApli.ApliValue();
		DdlApli.DataTextField = obApli.ApliText();
		DdlApli.DataBind();
	}

	protected void ListarDdlPerfilApli(EAplicacion oeApli)
	{
		DdlPerfil.DataSource = obMenu.ListarPerfilApli(oeApli);
		DdlPerfil.DataValueField = obMenu.perValue();
		DdlPerfil.DataTextField = obMenu.perText();
		DdlPerfil.DataBind();
	}

	protected void OnChanged(object sender, EventArgs e)
	{
		ListarDdlPerfilApli(new EAplicacion {
			idApli = Convert.ToInt32(DdlApli.SelectedValue)
		});
	}

	protected void Cancelar(object sender, EventArgs e)
	{
		ListarDdlAplicacion();
	}

	protected void MostrarArbol(object sender, EventArgs e)
	{
		TrvMenu.Nodes.Clear();
		perSelec = Convert.ToInt32(DdlPerfil.SelectedValue);
		DataSource = obMenu.DataSource(new EAplicacion {
			idApli = Convert.ToInt32(DdlApli.SelectedValue) }, new EPerfil{
				idPerfil = Convert.ToInt32(DdlPerfil.SelectedValue)
			});
		PopulateTree(TrvMenu);
		TrvMenu.ShowCheckBoxes = TreeNodeTypes.All;
	}

	protected void evAceptar(object sender, EventArgs e)
	{
		perSelec = Convert.ToInt32(DdlPerfil.SelectedValue);
		string checkMenuPer = string.Empty;
		foreach (TreeNode item in this.TrvMenu.CheckedNodes)
		{
			if (checkMenuPer.Equals(string.Empty))
			{
				checkMenuPer = item.Value;
			}
			else
			{
				checkMenuPer = checkMenuPer + ";" + item.Value;
			}
		}
		Response.Write("Cadena: " + checkMenuPer);
		obMenu.ActualizarMenuPerfil(new EPerfil { idPerfil = perSelec }, checkMenuPer);
	}

	private void PopulateTree(TreeView objTreeView)
	{
		foreach (DataRow dataRow in DataSource.Rows)
		{
			if (dataRow[obMenu.ParentMember()] == DBNull.Value)
			{
				TreeNode treeRoot = new TreeNode();
				treeRoot.Text = dataRow[obMenu.DisplayMember()].ToString();
				treeRoot.Value = dataRow[obMenu.KeyMember()].ToString();
				if (Convert.ToBoolean(dataRow["Check"].ToString()))
				{
					treeRoot.Checked = true;
				}
				treeRoot.ExpandAll();
				objTreeView.Nodes.Add(treeRoot);
				foreach (TreeNode childnode in GetChildNode(Convert.ToInt32(dataRow[obMenu.KeyMember()])))
				{
					treeRoot.ChildNodes.Add(childnode);
				}
			}
		}
	}

	private TreeNodeCollection GetChildNode(int parentid)
	{
		TreeNodeCollection childtreenodes = new TreeNodeCollection();
		DataView dataView1 = new DataView(DataSource);
		String strFilter = "" + obMenu.ParentMember() + "=" + parentid.ToString() + "";
		dataView1.RowFilter = strFilter;
		if (dataView1.Count > 0)
		{
			foreach (DataRow dataRow in dataView1.ToTable().Rows)
			{
				TreeNode childNode = new TreeNode();
				childNode.Text = dataRow[obMenu.DisplayMember()].ToString();
				childNode.Value = dataRow[obMenu.KeyMember()].ToString();
				if (Convert.ToBoolean(dataRow["Check"].ToString()))
				{
					childNode.Checked = true;
				}
				childNode.ExpandAll();
				foreach (TreeNode cnode in GetChildNode
		(Convert.ToInt32(dataRow[obMenu.KeyMember()])))
				{
					childNode.ChildNodes.Add(cnode);
				}
				childtreenodes.Add(childNode);
			}
		}
		return childtreenodes;
	}
}