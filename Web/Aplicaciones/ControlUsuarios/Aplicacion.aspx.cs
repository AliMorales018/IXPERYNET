using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

using System.Data;
using Dominio.Core.Entities;
using Dominio.Main.Module;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Aplicaciones_ControlUsuarios_Aplicacion : System.Web.UI.Page
{
	BAplicacion obApli = new BAplicacion();
	EAplicacion oeApli = new EAplicacion();
	List<string> lista = new List<string>();
	DataSet ds = new DataSet();
	DataTable dt = new DataTable();
	protected void Page_Load(object sender, EventArgs e)
	{
		
		dt.Columns.Add("Aplicacion");
		dt.Columns.Add("Estado");
		dt.Columns.Add("Version");
		dt.Columns.Add("Abreviatura");

	}


	public static string DataTable_HTML(DataTable dt)
	{
		string html = "<table>";
		html += "<tr>";
		for (int i = 0; i < dt.Columns.Count; i++)
			html += "<td>" + dt.Columns[i].ColumnName + "</td>";
		html += "</tr>";
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			html += "<tr>";
			for (int j = 0; j < dt.Columns.Count; j++)
				html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
			html += "</tr>";
		}
		html += "</table>";
		return html;
	}

	public static string DataTable_HTML2(DataTable dt)
	{
		string html = "";

		for (int i = 0; i < dt.Rows.Count; i++)
		{
			html += "<tr>";
			for (int j = 0; j < dt.Columns.Count; j++)
				html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
			html += "</tr>";
		}
		//html += "</body>";
		return html;
	}




	protected void BtnListar_Click(object sender, EventArgs e)
	{
		DataTable dt = new DataTable();

		dt.Columns.Add("IdApli");
		dt.Columns.Add("Aplicacion");
		dt.Columns.Add("Estado");
		dt.Columns.Add("Version");
		dt.Columns.Add("Abreviatura");
		dt.Rows.Add(1, "Apli1", true, "ver1", "a1");
		dt.Rows.Add(2, "Apli2", true, "ver2", "a2");
		dt.Rows.Add(3, "Apli3", false, "ver1", "a3");
		dt.Rows.Add(4, "Apli4", true, "ver1", "a4");

		pruebaBody.InnerHtml = DataTable_HTML2(dt);
		
	}


	protected void BtnGuardar_Click(object sender, EventArgs e)
	{
		if (HctblApp.Value.Equals(string.Empty))
		{
			HctblApp.Value = "1";
		}

		for (int i = 0; i < Convert.ToInt32(HctblApp.Value); ++i)
		{
			DataRow dr = dt.NewRow();
			dt.Rows.Add(dr);
			string app = "txtApp" + (i + 1);
			string estado = "txtEst" + (i + 1);
			string version = "txtVer" + (i + 1);
			string abreviatura = "txtAbr" + (i + 1);
			dt.Rows[i][0] = ((HtmlInputText)FindControl(app)).Value;
			dt.Rows[i][1] = ((HtmlInputText)Page.FindControl(estado)).Value;
			dt.Rows[i][2] = ((HtmlInputText)Page.FindControl(version)).Value;
			dt.Rows[i][3] = ((HtmlInputText)Page.FindControl(abreviatura)).Value;

		}

		grid.DataSource = dt;
		grid.DataBind();
		ds.Tables.Add(dt);
		obApli.Insertar(ds);



	}

	

	private string GetDocumentContents(HttpRequestBase Request)
	{
		string documentContents;
		using (Stream receiveStream = Request.InputStream)
		{
			using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
			{
				documentContents = readStream.ReadToEnd();
			}
		}
		return documentContents;
	}




	public DataTable HTMLTable_dt(string HTML)
	{


		DataTable dt = null;
		DataRow dr = null;
		DataColumn dc = null;
		string TableExpression = "<table[^>]*>(.*?)</table>";
		string HeaderExpression = "<th[^>]*>(.*?)</th>";
		string RowExpression = "<tr[^>]*>(.*?)</tr>";
		string ColumnExpression = "<td[^>]*>(.*?)</td>";
		bool HeadersExist = false;
		int iCurrentColumn = 0;
		int iCurrentRow = 0;

		MatchCollection Tables = Regex.Matches(HTML, TableExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

		foreach (Match Table in Tables)
		{

			iCurrentRow = 0;
			HeadersExist = false;

			dt = new DataTable();

			if (Table.Value.Contains("<th"))
			{
				HeadersExist = true;

				MatchCollection Headers = Regex.Matches(Table.Value, HeaderExpression, RegexOptions.Multiline | RegexOptions.IgnoreCase);

				foreach (Match Header in Headers)
				{
					dt.Columns.Add(Header.Groups[1].ToString());
				}
			}
			MatchCollection Rows = Regex.Matches(Table.Value, RowExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
			foreach (Match Row in Rows)
			{

				if (!(iCurrentRow == 0 & HeadersExist == true))
				{

					dr = dt.NewRow();
					iCurrentColumn = 0;
					MatchCollection Columns = Regex.Matches(Row.Value, ColumnExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
					foreach (Match Column in Columns)
					{
						DataColumnCollection columns = dt.Columns;
						dr[iCurrentColumn] = "hola";
						iCurrentColumn += 1;
					}

					dt.Rows.Add(dr);
				}

				iCurrentRow += 1;
			}
		}
		return (dt);
	}

}