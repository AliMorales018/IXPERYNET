<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PanelControl.aspx.cs" Inherits="Usuario_PanelControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Panel Usuario</title>
</head>
<body>
    <form id="form2" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-primary">
            <a class="navbar-brand text-white" href="#">MENÚ</a>
               <asp:Menu ID="mnuMain" DynamicHorizontalOffset="2" StaticSubMenuIndent="" MaximumDynamicDisplayLevels="3" Orientation="Horizontal" CssClass="mnuMain" runat="server">
                    <Items>
						<asp:MenuItem Text="Archivo" Value="Archivo">
							<asp:MenuItem Text="Abrir" Value="Abrir"></asp:MenuItem>
							<asp:MenuItem Text="Guardar" Value="Guardar"></asp:MenuItem>
						</asp:MenuItem>
						<asp:MenuItem Text="Editar" Value="Editar">
							<asp:MenuItem Text="Cortar" Value="Cortar"></asp:MenuItem>
							<asp:MenuItem Text="Copiar" Value="Copiar"></asp:MenuItem>
							<asp:MenuItem Text="Pegar" Value="Pegar"></asp:MenuItem>
						</asp:MenuItem>
						<asp:MenuItem Text="Seleccionar" Value="Seleccionar"></asp:MenuItem>
						<asp:MenuItem Text="Vista" Value="Vista">
							<asp:MenuItem Text="Vista 1" Value="Vista 1">
								<asp:MenuItem Text="Vista 2" Value="Vista 2">
									<asp:MenuItem Text="Vista 3" Value="Vista 3">
										<asp:MenuItem Text="Vista 4" Value="Vista 4">
											<asp:MenuItem Text="Vista 5" Value="Vista 5"></asp:MenuItem>
										</asp:MenuItem>
									</asp:MenuItem>
								</asp:MenuItem>
							</asp:MenuItem>
							<asp:MenuItem Text="Default" Value="Default"></asp:MenuItem>
						</asp:MenuItem>
						<asp:MenuItem Text="Analizar" Value="Analizar"></asp:MenuItem>
						<asp:MenuItem Text="Formato" Value="Formato"></asp:MenuItem>
						<asp:MenuItem Text="Tabla" Value="Tabla"></asp:MenuItem>
						<asp:MenuItem Text="Ayuda" Value="Ayuda">
							<asp:MenuItem Text="Ayudame" Value="Ayudame"></asp:MenuItem>
						</asp:MenuItem>
						<asp:MenuItem Text="Administracion Sistema" Value="Prueba">
							<asp:MenuItem Text="Usuario" Value="Usuario"></asp:MenuItem>
							<asp:MenuItem Text="Aplicacion" Value="Aplicacion"></asp:MenuItem>
							<asp:MenuItem Text="Perfil" Value="Perfil"></asp:MenuItem>
							<asp:MenuItem Text="Asignacion de Menu al Perfil" Value="Asignacion de Menu al Perfil"></asp:MenuItem>
						</asp:MenuItem>
					</Items>
                    <StaticMenuStyle CssClass = "nav navbar-nav" /> 
                    <DynamicMenuItemStyle CssClass = "nav-link" /> 
               </asp:Menu>
        </nav>
		<div>
			<asp:Button ID="BtnMenu" runat="server" Text="Guardar" OnClick="BtnMenu_Click" />
		</div>
    </form>
    <div class="container">
        <h4 class="mt-5">Bienvenido</h4>
    </div>
<%Response.WriteFile("/Includes/filesCss.html");%>
<%Response.WriteFile("/Includes/filesJs.html");%> 
</body>
</html>