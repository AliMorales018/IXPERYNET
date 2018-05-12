using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data;


namespace Infraestructura.Data.SqlServer
{
	public class DGeneral
	{
		public XDocument generarXML(DataSet ds)
		{
			XDocument xmlDoc = new XDocument();
			xmlDoc.Declaration = new XDeclaration("1.0", "utf-8", "yes");
			XElement root = new XElement("ROOT");
			xmlDoc.Add(root);
			int countTable = ds.Tables.Count;

			if (countTable < 1)
			{
				//
			}
			else if (countTable < 2)
			{
				string nomTabla = ds.Tables[0].TableName;
				int countRows = ds.Tables[nomTabla].Rows.Count;
				int countColumns = ds.Tables[nomTabla].Columns.Count;
				for (int i = 0; i < countRows; i++)
				{
					XElement elemento = new XElement(ds.Tables[nomTabla].TableName);
					for (int j = 0; j < countColumns; j++)
					{
						XAttribute atributo = new XAttribute(ds.Tables[nomTabla].Columns[j].ColumnName, ds.Tables[nomTabla].Rows[i][j].ToString());
						elemento.Add(atributo);
						if (j == countColumns - 1)
						{
							root.Add(elemento);
						}
					}
				}
			}
			else if (countTable < 3)
			{
				string nomTabla1 = ds.Tables[0].TableName;
				int countRows1 = ds.Tables[nomTabla1].Rows.Count;
				int countColumns1 = ds.Tables[nomTabla1].Columns.Count;

				string nomTabla2 = ds.Tables[1].TableName;
				int countRows2 = ds.Tables[nomTabla2].Rows.Count;
				int countColumns2 = ds.Tables[nomTabla2].Columns.Count;

				for (int i = 0; i < countRows1; i++)
				{
					XElement elemento1 = new XElement(ds.Tables[nomTabla1].TableName);
					for (int j = 0; j < countColumns1; j++)
					{
						XAttribute atributo = new XAttribute(ds.Tables[nomTabla1].Columns[j].ColumnName, ds.Tables[nomTabla1].Rows[i][j].ToString());
						elemento1.Add(atributo);
						if (j == countColumns1 - 1)
						{
							root.Add(elemento1);
							for (int p = 0; p < countRows2; p++)
							{
								XElement elemento2 = new XElement(ds.Tables[nomTabla2].TableName);
								for (int q = 0; q < countColumns2; q++)
								{
									XAttribute atributo2 = new XAttribute(ds.Tables[nomTabla2].Columns[q].ColumnName, ds.Tables[nomTabla2].Rows[p][q].ToString());
									elemento2.Add(atributo2);
									if (q == countColumns2 - 1)
									{
										elemento1.Add(elemento2);
									}
								}
							}
						}
					}
				}
			}
			//xmlDoc.Save(@"C:\Users\ingdi_000\Desktop\Data.xml");
			return xmlDoc;
		}


	}
}
