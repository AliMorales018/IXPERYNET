<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Aplicaciones_ControlUsuarios_Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="FrmPrincipal" runat="server">
        <div>
            <asp:Panel ID="PnlPrincipal" runat="server">
                <div>
                    <asp:Label ID="LblApli" runat="server" Text="Aplicación"></asp:Label>
                    <asp:DropDownList ID="DdlApli" runat="server" OnSelectedIndexChanged="OnChanged" OnDataBound="OnChanged" AutoPostBack="true" >
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label ID="LblPerfil" runat="server" Text="Perfil"></asp:Label>
                    <asp:DropDownList ID="DdlPerfil" runat="server">
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="MostrarArbol" />
                </div>
                <div>
                    <asp:TreeView ID="TrvMenu" runat="server"></asp:TreeView>
                </div>
                <div>
                    <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" OnClick="evAceptar" />
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="MostrarArbol"/>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
