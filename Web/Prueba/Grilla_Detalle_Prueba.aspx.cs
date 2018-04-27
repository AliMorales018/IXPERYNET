using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Npgsql;
namespace Grilla_Detalle_Prueba
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string SQL_CONN_STRING = @"Server=localhost;Port=5432;User Id=postgres;Password=admin;Database=PRODUCTOS";
        private static NpgsqlConnection connection;
        private static List<DetalleVentas> lista = new List<DetalleVentas>();
        DetalleVentas d1 = new DetalleVentas();
        public class DetalleVentas
        {
            public string ProductName { get; set; }
            public string PrecioName { get; set; }
            public string CantidadName { get; set; }
            public string SubtotalName { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridviewPGSQL();
            }
        }
        /*void PopulateGridviewSQL()
        {
            string conn = @"Data Source=.\SQLEXPRESS; Integrated Security=true; Initial Catalog=PRODUCTOS";
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Producto", sqlCon);
                sqlDa.Fill(dtbl);
                if (dtbl.Rows.Count > 0)
                {
                    gvProductos.DataSource = dtbl;
                    gvProductos.DataBind();
                }
                else
                {
                    dtbl.Rows.Add(dtbl.NewRow());
                    gvProductos.DataSource = dtbl;
                    gvProductos.DataBind();
                    gvProductos.Rows[0].Cells.Clear();
                    gvProductos.Rows[0].Cells.Add(new TableCell());
                }
            }
        }*/
        void PopulateGridviewPGSQL()
        {
            DataTable dtDetV = new DataTable();
            connection = new NpgsqlConnection(SQL_CONN_STRING);
            connection.Open();
            NpgsqlCommand cmdProd = new NpgsqlCommand("select * from detalleventa", connection);
            NpgsqlDataAdapter ds = new NpgsqlDataAdapter(cmdProd);
            ds.Fill(dtDetV);
            /*DataTable dt = new DataTable();
            DataTable dtDetV = new DataTable();
            connection = new NpgsqlConnection(SQL_CONN_STRING);
            connection.Open();
            NpgsqlCommand cmdProd = new NpgsqlCommand("select * from producto", connection);
            NpgsqlDataAdapter ds = new NpgsqlDataAdapter(cmdProd);
            ds.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvProductos.DataSource = dt;
                gvProductos.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvProductos.DataSource = dt;
                gvProductos.DataBind();
                gvProductos.Rows[0].Cells.Clear();
                gvProductos.Rows[0].Cells.Add(new TableCell());
            }*/
            //dtDetV.Columns.Add("IdProduct");
            //dtDetV.Columns.Add("ProductName");
            //dtDetV.Columns.Add("PrecioName");
            //dtDetV.Columns.Add("CantidadName");
            //dtDetV.Columns.Add("SubtotalName");
            if (dtDetV.Rows.Count <= 0)
            {
                dtDetV.Rows.Add(dtDetV.NewRow());
                gvProductos.DataSource = dtDetV;
                gvProductos.DataBind();
                gvProductos.Rows[0].Cells.Clear();
                gvProductos.Rows[0].Cells.Add(new TableCell());
            }
            cargaCombo();
        }
        private void cargaCombo()
        {
            DataTable dt = new DataTable();
            connection = new NpgsqlConnection(SQL_CONN_STRING);
            connection.Open();
            NpgsqlCommand cmdProd = new NpgsqlCommand("select * from producto", connection);
            NpgsqlDataAdapter ds = new NpgsqlDataAdapter(cmdProd);
            ds.Fill(dt);
            ((DropDownList)gvProductos.FooterRow.FindControl("cmbProductNameFooter")).DataSource = dt;
            ((DropDownList)gvProductos.FooterRow.FindControl("cmbProductNameFooter")).DataTextField = "ProductName";
            ((DropDownList)gvProductos.FooterRow.FindControl("cmbProductNameFooter")).DataValueField = "IdProduct";
            ((DropDownList)gvProductos.FooterRow.FindControl("cmbProductNameFooter")).DataBind();
        }
        private List<DetalleVentas> ObtenerNuevaLista()
        {
            List<DetalleVentas> lista = new List<DetalleVentas>();
            DetalleVentas d1 = new DetalleVentas();
            d1.ProductName = "";
            d1.PrecioName = "";
            d1.CantidadName = "";
            d1.SubtotalName = "";
            lista.Add(d1);
            lista.Clear();
            return lista;
        }
        private List<DetalleVentas> ObtenerLista()
        {
            if (Session["lista"] == null)
            {
                return this.ObtenerNuevaLista();
            }
            else
            {
                return (List<DetalleVentas>)Session["lista"];
            }
        }
        private List<DetalleVentas> GuardarLista(DetalleVentas detalleventas)
        {
            if (Session["lista"] == null)
            {
                List<DetalleVentas> d = this.ObtenerNuevaLista();
                d.Add(detalleventas);
                Session["lista"] = d;
            }
            else
            {
                List<DetalleVentas> d = (List<DetalleVentas>)Session["lista"];
                d.Add(detalleventas);
                Session["lista"] = d;
            }
            return (List<DetalleVentas>)Session["lista"];
        }
        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                DropDownList cmbProductNameFooter = (DropDownList)(gvProductos.FooterRow.FindControl("cmbProductNameFooter"));
                TextBox txtPrecioNameFooter = (TextBox)(gvProductos.FooterRow.FindControl("txtPrecioNameFooter"));
                TextBox txtCantidadNameFooter = (TextBox)(gvProductos.FooterRow.FindControl("txtCantidadNameFooter"));
                TextBox txtSubtotalNameFooter = (TextBox)(gvProductos.FooterRow.FindControl("txtSubtotalNameFooter"));
                DetalleVentas d = new DetalleVentas();
                d.ProductName = cmbProductNameFooter.SelectedItem.Text;
                d.PrecioName = txtPrecioNameFooter.Text.Trim();
                d.CantidadName = txtCantidadNameFooter.Text.Trim();
                d.SubtotalName = txtSubtotalNameFooter.Text.Trim();
                this.GuardarLista(d);
                this.gvProductos.DataSource = this.ObtenerLista();
                this.gvProductos.DataBind();
                cargaCombo();
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DataTable dtV = new DataTable("detalleventa");
            DataTable dt = new DataTable("tabla");
            connection = new NpgsqlConnection(SQL_CONN_STRING);
            connection.Open();
            NpgsqlCommand cmdDetV = new NpgsqlCommand("select * from detalleventa", connection);
            NpgsqlDataAdapter dsDetV = new NpgsqlDataAdapter(cmdDetV);
            dsDetV.Fill(dt);
            //AGREGA CABECERAS DE GRIDVIEW
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dtV.Columns.Add(dt.Columns[i].ColumnName);

            }
            foreach (GridViewRow dato in gvProductos.Rows)
            {
                DataRow f = dtV.NewRow();
                f[0] = ((Label)dato.FindControl("cmbProducto")).Text.Trim();
                f[1] = ((TextBox)dato.FindControl("txtPrecio")).Text.Trim();
                f[2] = ((TextBox)dato.FindControl("txtCantidad")).Text.Trim();
                f[3] = ((TextBox)dato.FindControl("txtSubtotal")).Text.Trim();
                dtV.Rows.Add(f);
            }
            GuardaDetalle(dtV);
            //dtV.WriteXml("E:/IXPERY.xml");
            //ConvertDatatableToXML(dtV);           
        }
        private string GuardaDetalle(DataTable DtDetProd)
        {
            InsDetV_ProdAlm("padetventas", DtDetProd);
            string xd = "";
            return (xd);
        }
        private string InsDetV_ProdAlm(String nomsp, DataTable DtDetProd)
        {
            String Resultado = "";
            NpgsqlParameter objParam;
            // String vConsulta = "";
            NpgsqlTransaction t;
            NpgsqlCommand objCmd = new NpgsqlCommand(nomsp, connection);
            objCmd.CommandType = CommandType.StoredProcedure;
            //objCmd.Connection = connection;
            t = connection.BeginTransaction();
            try
            {
                //vConsulta= " select * from " +  nomsp + "(";
                String Detalle = "{";
                Boolean sw = false;
                foreach (DataRow fila in DtDetProd.Rows)
                {
                    if (sw)
                    {
                        Detalle = Detalle + ",";
                    }
                    Detalle = Detalle + "{";
                    Detalle = Detalle + "" + fila[0] + ",";
                    Detalle = Detalle + "" + fila[1] + ",";
                    Detalle = Detalle + "" + fila[2] + ",";
                    Detalle = Detalle + "" + fila[3] + "";
                    Detalle = Detalle + "}";
                    sw = true;
                }
                Detalle = Detalle + "}";
                objParam = new NpgsqlParameter();
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                objParam.ParameterName = "detalle_venta";
                if (Detalle == "{}")
                {
                    objParam.Value = DBNull.Value;
                }
                else
                {
                    objParam.Value = Detalle;
                }
                objParam.Direction = ParameterDirection.Input;
                objCmd.Parameters.Add(objParam);
                NpgsqlDataReader objReader = objCmd.ExecuteReader();
                /* if(Detalle=="array[]")
                 {
                     Detalle = "null";
                 }
                 vConsulta = vConsulta + Detalle + "::varchar[]";
                 objCmd.CommandText = vConsulta;*/
                //objParam = new NpgsqlParameter();
                //objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                //objParam.ParameterName = "outid";
                //objParam.Value = 0;
                //objParam.Direction = ParameterDirection.Output;
                //objCmd.Parameters.Add(objParam);
                //objParam = new NpgsqlParameter();
                //objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                //objParam.ParameterName = "outDescription";
                //objParam.Value = 0;
                //objParam.Direction = ParameterDirection.Output;
                //objCmd.Parameters.Add(objParam);
                objCmd.ExecuteNonQuery();
                t.Commit();
                t.Dispose();
                // Resultado = IIf(IsDBNull(objCmd.Parameters("outDescription").Value), "", objCmd.Parameters("outDescription").Value);
            }
            catch (Exception)
            {
                throw;
            }
            return Resultado;
        }
        //EL SGTE CODIGO ES PARA MANDAR A XML MEDIANTE LA LISTA DE LA SESSION
        /*protected void Button1_Click(object sender, EventArgs e)
        {
            List<DetalleVentas> ObtenerLista = (List<DetalleVentas>)Session["lista"];
            DataTable dt = new DataTable("tabla");   
            for (int i = 0; i < gvProductos.HeaderRow.Cells.Count - 1; i++)
            {
                dt.Columns.Add(gvProductos.HeaderRow.Cells[i].Text);
            }
            foreach (DetalleVentas dato in ObtenerLista)
            {
                DataRow f = dt.NewRow();
                f[0] = dato.ProductName;
                f[1] = dato.PrecioName;
                f[2] = dato.CantidadName;
                f[3] = dato.SubtotalName;
                dt.Rows.Add(f);
            }
            dt.WriteXml("E:/IXPERY.xml");
            //ConvertDatatableToXML(dt);
            }*/
        private string ConvertDatatableToXML(DataTable dt)
        {
            MemoryStream str = new MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            //NpgsqlCommand cmd = connection.CreateCommand();
            //cmd.CommandText = xmlstr;
            //NpgsqlDataReader dR = cmd.ExecuteReader();
            //NpgsqlCommand cmd = new NpgsqlCommand("paregistradetventa", connection);
            //cmd.CommandType = CommandType.StoredProcedure;
            // NpgsqlDataReader objReader = cmd.ExecuteReader();

            return (xmlstr);
        }

        protected void textbox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
//void PopulateGridview
//{
//    string conn = @"Data Source=.\SQLEXPRESS; Integrated Security=true; Initial Catalog=PRODUCTOS";
//    using (SqlConnection sqlCon = new SqlConnection(conn))
//    {
//        sqlCon.Open();
//        SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Producto", sqlCon);
//        sqlDa.Fill(dtbl);
//        if (dtbl.Rows.Count > 0)
//        {
//            gvProductos.DataSource = dtbl;
//            gvProductos.DataBind();
//        }
//        else
//        {
//            dtbl.Rows.Add(dtbl.NewRow());
//            gvProductos.DataSource = dtbl;
//            gvProductos.DataBind();
//            gvProductos.Rows[0].Cells.Clear();
//            gvProductos.Rows[0].Cells.Add(new TableCell());
//        //    gvProductos.Rows[1].Cells.Clear();
//        //    gvProductos.Rows[1].Cells.Add(new TableCell());
//            //gvProductos.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
//            //gvProductos.Rows[0].Cells[0].Text = "No Hay Datos...";
//            //gvProductos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
//        }
//    }
//    //this.DropDownList1.DataSource = dtbl;
//    //this.DropDownList1.SelectedValue = "IdProduct";
//    //this.DropDownList1.DataValueField = "ProductName";
//    //this.DropDownList1.SelectedIndex = 0;
//}
//protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
//{
//    if (e.CommandName.Equals("AddNew"))
//    {
//        if(c<=0)
//        { 
//            //gvProductos.Rows[c].Cells.Add(new TableCell());
//            gvProductos.Rows[c].Cells[0].Text = (gvProductos.FooterRow.FindControl("txtProductNameFooter") as TextBox).Text.Trim();
//            gvProductos.Rows[c].Cells[1].Text = (gvProductos.FooterRow.FindControl("txtPrecioNameFooter") as TextBox).Text.Trim();
//            gvProductos.Rows[c].Cells[2].Text = (gvProductos.FooterRow.FindControl("txtCantidadNameFooter") as TextBox).Text.Trim();
//            gvProductos.Rows[c].Cells[3].Text = (gvProductos.FooterRow.FindControl("txtSubtotalNameFooter") as TextBox).Text.Trim();
//             dtbl =gvProductos.DataSource as DataTable;
//        }
//        else
//        {
//            dtbl.Rows.Add(dtbl.NewRow());
//            gvProductos.DataSource = dtbl;
//            gvProductos.DataBind();
//            gvProductos.Rows[c].Cells.Clear();
//            gvProductos.Rows[c].Cells.Add(new TableCell());
//            gvProductos.Rows[c].Cells[0].Text = (gvProductos.FooterRow.FindControl("txtProductNameFooter") as TextBox).Text.Trim();
//            gvProductos.Rows[c].Cells[1].Text = (gvProductos.FooterRow.FindControl("txtPrecioNameFooter") as TextBox).Text.Trim();
//            gvProductos.Rows[c].Cells[2].Text = (gvProductos.FooterRow.FindControl("txtCantidadNameFooter") as TextBox).Text.Trim();
//            gvProductos.Rows[c].Cells[3].Text = (gvProductos.FooterRow.FindControl("txtSubtotalNameFooter") as TextBox).Text.Trim();
//        }
//        c++;
//        //table.Rows.Add(row);
//        //gvProductos.DataSource = table;
//        //gvProductos.DataBind();
//    }
//   // hfIdProduct.Value = Convert.ToString(c);
//}
//private static void ImprimirPersona(DetalleVentas detalleventas)
//{
//    Console.WriteLine("ProductName: {0}\nPrecioName: {1},\nCantidadName: {2},\nSubtotalName",
//        pActual.Id.ToString(), pActual.Nombre, pActual.Edad.ToString());
//}
