<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Producto.aspx.cs" Inherits="Aplicaciones_Logistica_Producto" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro_Productos</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="/Resources/css/bootstrap.min.css">
    <link rel="stylesheet" href="/Resources/css/icons/styles.css">
    <link rel="stylesheet" href="/Resources/css/core.css">
    <link rel="stylesheet" href="/Resources/css/colors.css">
    <style type="text/css">
        .auto-style1 {
            width: 78px;
        }

        .auto-style3 {
            width: 840px;
        }
    </style>
</head>
<body class="bg-light">
    <div class="container">
        <div class="row justify-content-center">
            <form id="form1" runat="server" class="">
                <h1 class="text-center mt-5">REGISTRO DE PRODUCTOS</h1>
                <asp:HiddenField ID="Hc" runat="server" Value="1" />
                <asp:HiddenField ID="HBuscar" runat="server" Value="0" />
                <div class="container">
                    <div class="form-group">
                        <div class="table-responsive-lg text-size-sm">
                            <%--<div id="divTabla" runat="server" visible="true">--%>
                            <table class="table" id="tblProducto">
                                <thead class="thead-light" runat="server">
                                    <tr>
                                        <th class="text-center">N°</th>
                                        <th id="thColCate" class="text-center" runat="server">
                                            <div id="divControlCate" runat="server">
                                                <input type="text" id="txtBusCate" name='txtBuscCate' placeholder='Buscar Categoria' class='form - control' runat="server" />
                                                <asp:Button ID="btnBusCate" Text="Buscar" runat="server" OnClick="btnBusCate_Click" Enabled="false"/>
                                            </div>
                                        </th>
                                        <th id="thColNomProd" class="text-center" runat="server">
                                            <div id="divControlProd" runat="server">
                                                <%--style="display: none;"--%>
                                                <input type="text" id="txtBusProd" name='txtBuscCate' placeholder='Buscar Producto' class='form - control' runat="server" />
                                                <asp:Button ID="btnBusProd" Text="Buscar" runat="server" OnClick="btnBusProd_Click" />
                                            </div>
                                        </th>
                                        <th class="text-center">Cantidad</th>
                                        <th class="text-center">Unidad_Medida</th>
                                    </tr>
                                </thead>
                                <tbody id="tbodyCol" runat="server">
                                    <tr>
                                        <td>
                                            <p>1</p>
                                        </td>

                                        <td>
                                            <div class="input-group input-group-sm">
                                                <select id="cmbCat1" name="cmbCat1" size="1" class="form-control" runat="server"></select>
                                            </div>
                                        </td>

                                        <td>
                                            <div class="input-group input-group-sm">
                                                <input type="text" id="txtProducto1" name="txtProducto1" placeholder="Nombre de Producto" class="form-control" runat="server" />
                                            </div>
                                        </td>

                                        <td>
                                            <div class="input-group input-group-sm">
                                                <input type="text" id="txtCantidad1" name="txtCantidad1" placeholder="Cantidad" class="form-control" runat="server" />
                                            </div>
                                        </td>

                                        <td>
                                            <div class="input-group input-group-sm">
                                                <select id="cmbUmed1" name="cmbUmed1" size="1" class="form-control" runat="server"></select>
                                            </div>
                                        </td>
                                        <td class="text-left">
                                            <button type="button" class="btn btn-danger mr-sm-2 btn-sm">Eliminar</button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <%--</div>--%>
                            <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="false" ShowFooter="true" Visible="false"
                                ShowHeaderWhenEmpty="true"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="gvProducto_RowCommand" OnRowUpdating="gvProducto_RowUpdating">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />

                                <Columns>
                                    <asp:TemplateField HeaderText="N°">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdProd" Text='<%# Eval("ID PRODUCTO") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="lblIdProd" Text='<%# Eval("ID PRODUCTO") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Categoria">
                                        <ItemTemplate>
                                            <asp:TextBox ID="cmbCategoria" Text='<%# Eval("ID CATEGORIA") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="cmbCategoria" Text='<%# Eval("ID CATEGORIA") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Producto">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtProd" Text='<%# Eval("NOMBRE PRODUCTO") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtProd" Text='<%# Eval("NOMBRE PRODUCTO") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCant" Text='<%# Eval("CANTIDAD PRODUCTO") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCant" Text='<%# Eval("CANTIDAD PRODUCTO") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UMedida">
                                        <ItemTemplate>
                                            <asp:TextBox ID="cmbUMedida" Text='<%# Eval("ID MEDIDA") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="cmbUMedida" Text='<%# Eval("ID MEDIDA") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <table class="table">
                        <tr>
                            <td class="auto-style3">
                                <div class="input-group input-group-sm">
                                    <asp:Button ID="btnSave" runat="server" Text="Guardar" class="btn btn-dark btn-lg mb-5" OnClick="btnSave_Click" />
                                </div>
                            </td>
                            <td class="auto-style3">
                                <div class="input-group input-group-sm">
                                    <%--<button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnBuscar" >Buscar</button>--%>
                                </div>
                            </td>
                            <td class="auto-style1">
                                <div class="input-group input-group-sm" style="left: -357px; top: 0px; width: 558%">
                                    <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo">Nuevo</button>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>

    </div>

    <% Response.WriteFile("/Includes/filesCss.html"); %><% Response.WriteFile("/Includes/filesJs.html"); %>
    <%--<script type="text/javascript" src="../../Resources/js/SProducto.js"></script>--%>
  <%--  <select id="cmbCatT" name="cmbCatT" runat="server" size="1" class="form-control">
    </select>
    <select id="cmbUmedT" name="cmbUmedT" runat="server" size="1" class="form-control">
    </select>--%>

    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>



</body>
</html>
