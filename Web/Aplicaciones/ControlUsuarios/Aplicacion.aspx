<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Aplicacion.aspx.cs" Inherits="Aplicaciones_ControlUsuarios_Aplicacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <asp:HiddenField ID="HctblApp" runat="server" />
        <div class="container mt-5">
            <div class="text-center m-2">
                <p class="lead mt-4">APLICACION MASTER</p>
            </div>
            <label for="">
                <button type="button" class="btn btn-secondary mr-sm-2 btn-sm" id="btnBuscar">Buscar</button>
            </label>
            <div class="form-group">
                <div class="table-responsive-lg text-size-sm" runat="server" id="prueba">
                    <table class="table table-bordered" id="tblApp">
                        <thead class="bg-dark" runat="server" id ="thead1">
                            <tr class="bg-dark text-white border border-dark">
                                <th class="text-center font-weight-light">N</th>
                                <th class="text-center font-weight-light"  runat="server" id ="th1">APLICACION</th>
                                <th class="text-center font-weight-light">ESTADO</th>
                                <th class="text-center font-weight-light">VERSION</th>
                                <th class="text-center font-weight-light">ABREVIATURA</th>
                                <th class="text-center font-weight-light">ELIMINAR</th>
                            </tr>
                        </thead>
                        <tbody id="pruebaBody" runat="server">
                            <tr id="firstRowBody">
                                <td><div id="campo1"><p>1</p></div></td>
                                <td><div id="campo2" class="input-group input-group-sm"><input type="text" runat="server" id="txtApp1" class="form-control" /></div></td>
                                <td><div id="campo3" class="input-group input-group-sm"><input type="text" runat="server" id="txtEst1" class="form-control" /></div></td>
                                <td><div id="campo4" class="input-group input-group-sm"><input type="text" runat="server" id="txtVer1" class="form-control" /></div></td>
                                <td><div id="campo5" class="input-group input-group-sm"><input type="text" runat="server" id="txtAbr1" class="form-control" /></div></td>
                                <td class="text-center"><div id="campo6"><button type="button" class="btn btn-danger mr-sm-2 btn-sm" id="btn1">Eliminar</button></div></td>                     
                            </tr>
                        </tbody>
                    </table>
                    <div class="container text-center">
                        <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo">Nuevo</button>
                        <asp:Button ID="BtnGuardar" runat="server" class="btn btn-success btn-sm" Text="Guardar" OnClick="BtnGuardar_Click"></asp:Button>
                    </div>
					<div>
                        <asp:Button ID="BtnListar" runat="server" class="btn btn-success btn-sm" Text="Listar" OnClick="BtnListar_Click"></asp:Button>
					</div>
                    <asp:HiddenField ID="Hc" runat="server" />
                </div>
            </div>
        </div>
		<div>
			<asp:GridView ID="grid" runat="server"></asp:GridView>
			<textarea id="tarea" cols="20" rows="2" ></textarea>
			<input id="te" type="text" runat="server"/>
		</div>
    </form>
    <% Response.WriteFile("/Includes/filesCss.html"); %>
    <% Response.WriteFile("/Includes/filesJs.html"); %>
</body>
</html>
