<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categoria.aspx.cs" Inherits="Aplicaciones_Logistica_Categoria" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <% Response.WriteFile("/Includes/filesCss.html"); %><% Response.WriteFile("/Includes/filesJs.html"); %>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro_Categoria</title>
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
                <h1 class="text-center mt-5">REGISTRO DE CATEGORIAS</h1>
                <asp:HiddenField ID="Hc" runat="server" Value="1" />
                <asp:HiddenField ID="HBuscar" runat="server" Value="0"/>
                <div class="container">
                    <div class="form-group">
                        <div class="table-responsive-lg text-size-sm">
                            <%--<div id="divTabla" runat="server" visible="true">--%>
                                <table class="table" id="tblCategoria">
                                    <thead class="thead-light" runat="server">
                                        <tr>
                                            <th class="text-center">N°</th>
                                            <th class="text-center">Familia</th>
                                            <th id="thColCate" class="text-center" runat="server">
                                            <div id="divControl" runat="server"><%--style="display: none;"--%>
                                                <input type="text" id="txtBusCate" name='txtBuscCate' placeholder='Buscar Categoria' class='form - control' runat="server" />
                                                <asp:Button ID="btnBusCat" Text="Buscar" runat="server" OnClick="btnBusCat_Click" />
                                            </div>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyCol" runat="server">
                                        <tr>
                                            <td>
                                                <p>1</p>
                                            </td>

                                            <td>
                                                <div class="input-group input-group-sm">
                                                    <select id="cmbFam1" name="cmbFam1" size="1" class="form-control" runat="server"></select>
                                                </div>
                                            </td>
                                            <td>

                                                <div class="input-group input-group-sm">
                                                    <input type="text" id="txtCategoria1" name="txtCategoria1" class="form-control" runat="server"/>
                                                </div>
                                            </td>
                                            <td class="text-left">
                                                <button type="button" class="btn btn-danger mr-sm-2 btn-sm">Eliminar</button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            <%--</div>--%>
                            <asp:GridView ID="gvCategoria" runat="server" AutoGenerateColumns="false" ShowFooter="true" Visible="false"
                                ShowHeaderWhenEmpty="true"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="gvCategoria_RowCommand" OnRowUpdating="gvCategoria_RowUpdating">
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
                                            <asp:Label ID="lblIdCate" Text='<%# Eval("ID DE CATEGORIA") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="lblIdCate" Text='<%# Eval("ID DE CATEGORIA") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Familia">
                                        <ItemTemplate>
                                            <asp:TextBox ID="cmbFamilia" Text='<%# Eval("ID DE FAMILIA") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="cmbFamilia" Text='<%# Eval("ID DE FAMILIA") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Categoria">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCat" Text='<%# Eval("NOMBRE DE CATEGORIA") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCat" Text='<%# Eval("NOMBRE DE CATEGORIA") %>' runat="server" />
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
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
            </form>
        </div>

    </div>

   
    <select id="cmbFamC" name="cmbFamC" runat="server" size="1" class="form-control">
    </select>

    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
 
    

</body>
</html>
