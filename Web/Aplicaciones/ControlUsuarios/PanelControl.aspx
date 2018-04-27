﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PanelControl.aspx.cs" Inherits="Usuario_PanelControl" %>

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
                    <StaticMenuStyle CssClass = "nav navbar-nav" /> 
                    <DynamicMenuItemStyle CssClass = "nav-link" /> 
               </asp:Menu>
        </nav>
    </form>
    <div class="container">
        <h4 class="mt-5">Bienvenido</h4>
    </div>
<%Response.WriteFile("/Includes/filesCss.html");%>
<%Response.WriteFile("/Includes/filesJs.html");%> 
</body>
</html>