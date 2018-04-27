<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu_prueba.aspx.cs" Inherits="Prueba_menu_prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                <Items>
                    <asp:MenuItem Text="Archivo" Value="Archivo">
                        <asp:MenuItem Text="Abrir1" Value="Abrir">
                            <asp:MenuItem Text="HijoAbrir1" Value="HijoAbrir">
                                <asp:MenuItem Text="NietoAbrir" Value="NietoAbrir"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Abrir2" Value="Abrir2">
                            <asp:MenuItem Text="HijoAbrir2" Value="HijoAbrir2"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Abrir3" Value="Abrir3">
                            <asp:MenuItem Text="HijoAbrir3" Value="HijoAbrir3"></asp:MenuItem>
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Editar" Value="Editar">
                        <asp:MenuItem Text="EditaHijo1" Value="EditaHijo1">
                            <asp:MenuItem Text="HijoEditar1" Value="HijoEditar1"></asp:MenuItem>
                            <asp:MenuItem Text="HijoEditar2" Value="HijoEditar2"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Edita hijo2" Value="Edita hijo2"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Impr" Value="Impr">
                        <asp:MenuItem Text="Vista" Value="Vista"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Compilar" Value="Compilar">
                        <asp:MenuItem Text="Depurar" Value="Depurar"></asp:MenuItem>
                    </asp:MenuItem>
                </Items>
            </asp:Menu>
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="436px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:TreeView ID="TV1" runat="server" ImageSet="Contacts" NodeIndent="10" ShowCheckBoxes="All">
            <HoverNodeStyle Font-Underline="False" />
            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
    </form>
</body>
</html>
