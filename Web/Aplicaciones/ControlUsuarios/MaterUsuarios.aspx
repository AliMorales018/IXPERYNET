<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaterUsuarios.aspx.cs" Inherits="Aplicaciones_ControlUsuarios_MaterUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="text-center m-2">
                <p class="lead mt-4">Control de Usuarios</p>
            </div>
            <label for="">
                <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo">Nuevo Registro</button>
                <button type="button" class="btn btn-secondary mr-sm-2 btn-sm" id="btnBuscar">Buscar</button>
            </label>
            <div class="form-group">
                <div class="table-responsive-lg text-size-sm">
                    <table class="table table-bordered" runat="server" id="tblUsuarios">
                        <thead class="bg-dark">
                            <tr class="bg-dark text-white border border-dark">
                                <th class="text-center font-weight-light">N°</th>
                                <th class="text-center font-weight-light">Nombre</th>
                                <th class="text-center font-weight-light">Apellido Paterno</th>
                                <th class="text-center font-weight-light">Apellido Materno</th>
                                <th class="text-center font-weight-light">Usuario</th>
                                <th class="text-center font-weight-light">Clave</th>
                                <th class="text-center font-weight-light">Eliminar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="firstRow">
                                <td>
                                    <p>1</p>
                                </td>
                                <td>
                                    <div class="input-group input-group-sm">
                                        <input type="text" runat="server" id="txtNombre1" class="form-control" /></div>
                                </td>
                                <td>
                                    <div class="input-group input-group-sm">
                                        <input type="text" runat="server" id="txtApellidoP1" class="form-control" /></div>
                                </td>
                                <td>
                                    <div class="input-group input-group-sm">
                                        <input type="text" runat="server" id="txtApellidoM1" class="form-control" /></div>
                                </td>
                                <td>
                                    <div class="input-group input-group-sm">
                                        <input type="text" runat="server" id="txtUsuario1" class="form-control" /></div>
                                </td>
                                <td>
                                    <div class="input-group input-group-sm">
                                        <input type="text" runat="server" id="txtClave1" class="form-control" /></div>
                                </td>
                                <td class="text-center">
                                    <button type="button" class="btn btn-danger mr-sm-2 btn-sm" id="btn1">Eliminar</button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="container text-center">
                        <asp:Button ID="BtnGuardar" runat="server" class="btn btn-success btn-sm" Text="Guardar" OnClick="BtnGuardar_Click"></asp:Button>
                    </div>
                    <asp:HiddenField ID="Hc" runat="server" />
                </div>
            </div>
        </div>
    </form>
    <% Response.WriteFile("/Includes/filesCss.html"); %>
    <% Response.WriteFile("/Includes/filesJs.html"); %>
</body>
</html>
