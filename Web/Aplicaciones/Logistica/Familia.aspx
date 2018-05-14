<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Familia.aspx.cs" Inherits="Familia" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro_Familia</title>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <asp:HiddenField ID="HctblFamilia" runat="server" />
        <div class="container mt-5">
            <div class="text-center m-2">
                <p class="lead mt-4">Control Familias</p>
            </div>
            <label for="">
                <button type="button" class="btn btn-secondary mr-sm-2 btn-sm" id="btnBuscar">Buscar</button>
            </label>
            <div class="form-group">
                <div class="table-responsive-lg text-size-sm">
                    <table class="table table-bordered" id="tblFamilia">
                        <thead class="bg-dark" runat="server">
                            <tr class="bg-dark text-white border border-dark">
                                <th class="text-center font-weight-light">N°</th>
                                <th class="text-center font-weight-light"><div id="divControl" runat="server"><%--style="display: none;"--%>
                                                <input type="text" id="txtBusFam" name='txtBusFam' placeholder='Buscar Familia' class='form - control' runat="server" />
                                                <asp:Button ID="btnBusFam" Text="Buscar" runat="server" OnClick="btnBusFam_Click" />
                                            </div></th>
                                <th class="text-center font-weight-light">Eliminar</th>
                            </tr>
                        </thead>
                        <tbody id="tbodyCol" runat="server">
                            <tr id="firstRowBody">
                                <td><div id="campo1"><p>1</p></div></td>
                                <td><div id="campo2" class="input-group input-group-sm"><input type="text" runat="server" id="txtFamilia1" class="form-control" /></div></td>
                                <td class="text-center"><div id="campo3"><button type="button" class="btn btn-danger mr-sm-2 btn-sm" id="btn1">Eliminar</button></div></td>                     
                            </tr>
                        </tbody>
                    </table>
                    <asp:GridView ID="gvFamilia" runat="server" AutoGenerateColumns="false" ShowFooter="true" Visible="false"
                                ShowHeaderWhenEmpty="true"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="gvFamilia_RowCommand" OnRowUpdating="gvFamilia_RowUpdating"  OnRowDeleting="gvFamilia_RowDeleting">
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
                                            <asp:Label ID="lblIdFam" Text='<%# Eval("ID FAMILIA") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdFam" Text='<%# Eval("ID FAMILIA") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Familia">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFam" Text='<%# Eval("NOMBRE FAMILIA") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFam" Text='<%# Eval("NOMBRE FAMILIA") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                            <asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <%--<asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />--%>
                                            <%--<asp:ImageButton ImageUrl="~/images/0.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />--%>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                    <div class="container text-center">
                        <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo">Nuevo</button>
                        <asp:Button ID="BtnGuardar" runat="server" class="btn btn-success btn-sm" Text="Guardar" OnClick="BtnGuardar_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    <% Response.WriteFile("/Includes/filesCss.html"); %>
    <% Response.WriteFile("/Includes/filesJs.html"); %>
    </form>
    </body>
</html>

