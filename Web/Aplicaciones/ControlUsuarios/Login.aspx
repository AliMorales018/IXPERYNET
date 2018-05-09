<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Login</title>
</head>
    
<body class="bg-light">
      <div class="container">
        <div class="row justify-content-center">
            <form id="form1" runat="server" class="col-lg-4 col-md-5 col-sm-12 mt-4">
                <h1 class="text-center text-dark mt-5">Acceso</h1>
                <h6 class="text-center mt-3 lead text-size-sm">Registre sus credenciales</h6>
                <div class="form-group">
                    <label for="exampleInputEmail1">Usuario</label>
                    <div class="input-group">
                        <div class="input-group-prepend">
                          <div class="input-group-text"><i class="icon-user-tie"></i></div>
                        </div>
                        <asp:TextBox ID="TxtLogin" class="form-control" type="text" runat="server" placeholder="Usuario"  required=""></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Password</label>
                    <div class="input-group">
                        <div class="input-group-prepend">
                          <div class="input-group-text"><i class="icon-lock"></i></div>
                        </div>
                        <asp:TextBox ID="TxtPass" class="form-control" type="password" runat="server" placeholder="Password"  required="" OnTextChanged="Validar" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
              
                <div class="form-group">
                    <label for="exampleInputEmail1">Seleccione Aplicación</label>
                    <div class="input-group">
                        <div class="input-group-prepend">
                          <div class="input-group-text"><i class="icon-rocket"></i></div>
                        </div>
                        <asp:DropDownList ID="SelectApli" class="custom-select" runat="server" OnSelectedIndexChanged="OnChanged" AutoPostBack="true">
                                <asp:ListItem value="0"> - Seleccione - </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Seleccione Perfil</label>
                    <div class="input-group">
                        <div class="input-group-prepend">
                          <div class="input-group-text"><i class="icon-man"></i></div>
                        </div>
                        <asp:DropDownList ID="SelectPerfil" class="custom-select" runat="server">
                                <asp:ListItem value="0"> - Seleccione - </asp:ListItem>
                        </asp:DropDownList>
                    </div>  
                </div>  
                
                <div class="row justify-content-center">
                    <div class="col-lg-4 col-md-6 col-sm-12">
                      <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" type="button" class="btn btn-danger btn-lg mb-5" OnClick="Redirect"/>
                    </div>
                </div>
                <asp:Label ID="Mensaje" class="mt-5 text-center" runat="server"></asp:Label>
            </form>
         </div>
     </div>
<% Response.WriteFile("/Includes/filesCss.html"); %> 
<% Response.WriteFile("/Includes/filesJs.html"); %> 
</body>
</html>
