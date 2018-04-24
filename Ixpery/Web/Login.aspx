<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Login</title>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css"/>

</head>

<body class="bg-light">
      <div class="container">
        <div class="row justify-content-center">
            <form id="form1" runat="server" class="col-lg-4 col-md-5 col-sm-12 mt-5">
                <h1 class="text-center mt-5">Login</h1>
                <div class="form-group">
                    <label for="exampleInputEmail1">Usuario</label>
                    <asp:TextBox ID="TxtLogin" class="form-control" type="text" runat="server" placeholder="Usuario"  required=""></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Password</label>
                    <asp:TextBox ID="TxtPass" class="form-control" type="password" runat="server" placeholder="Password"  required="" OnTextChanged="Validar"></asp:TextBox>
                </div>
                <div id="ContSelec" runat="server">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Seleccione Aplicación</label>
                            <asp:DropDownList ID="SelectApli" class="custom-select" runat="server" OnSelectedIndexChanged="OnChanged" AutoPostBack="true">
                                <asp:ListItem value="0"> - Seleccione - </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Seleccione Perfil</label>
                            <asp:DropDownList ID="SelectPerfil" class="custom-select" runat="server">
                                <asp:ListItem value="1"> - Seleccione - </asp:ListItem>
                            </asp:DropDownList>
                        </div>  
                </div>
                <div class="row justify-content-center">
                    <div class="col-lg-4 col-md-6 col-sm-12">
                      <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" class="btn btn-dark btn-lg mb-5"/>
                    </div>
                </div>
                <asp:Label ID="Mensaje" class="mt-5 text-center" runat="server"></asp:Label>
            </form>
         </div>
     </div>
</body>
</html>
