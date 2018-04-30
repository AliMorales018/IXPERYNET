<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaterUsuarios.aspx.cs" Inherits="Aplicaciones_ControlUsuarios_MaterUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
       <div class="container mt-5">
        <label for="">      
              <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo">Nuevo Registro</button>
        </label>
        <div class="form-group">
          <div class="table-responsive-lg text-size-sm">
            <table class="table table-bordered" id="tblUsuarios">
              <thead class="thead-dark">
              <tr>
                  <th class="text-center font-weight-light">N°</th>
                  <th class="text-center font-weight-light">Nombre</th>
                  <th class="text-center font-weight-light">Apellido Paterno</th>
                  <th class="text-center font-weight-light">Apellido Materno</th>
                  <th class="text-center font-weight-light">Usuario</th>
                  <th class="text-center font-weight-light">Email</th>
                  <th class="text-center font-weight-light">Eliminar</th>
                </tr>
              </thead>
              <tr id="1">
                  <td><p>1</p></td>
                  <td><div class="input-group input-group-sm"><input type="text" class="form-control"/></div></td>
                  <td><div class="input-group input-group-sm"><input type="text" class="form-control"/></div></td>
                  <td><div class="input-group input-group-sm"><input type="text" class="form-control"/></div></td>
                  <td><div class="input-group input-group-sm"><input type="text" class="form-control"/></div></td>
                  <td><div class="input-group input-group-sm"><input type="text" class="form-control"/></div></td>
                  <td class="text-center">
                      <button type="button" class="btn btn-danger mr-sm-2 btn-sm" id="btn1">Eliminar</button>
                  </td>
              </tr>
            </table>
            <div class="container text-center">
              <button class="btn btn-success btn-sm">Guardar</button>  
            </div>
          </div>
        </div>
    </div>
    </form>
<% Response.WriteFile("/Includes/filesCss.html"); %> 
<% Response.WriteFile("/Includes/filesJs.html"); %> 
</body>
</html>
