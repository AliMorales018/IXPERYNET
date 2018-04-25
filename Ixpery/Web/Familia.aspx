<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Familia.aspx.cs" Inherits="Familia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro_familia</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css"/>
</head>
<body class="bg-light">
      <div class="container">
        <div class="row justify-content-center">
            <form id="form1" runat="server" class="col-lg-4 col-md-5 col-sm-12 mt-5">
                <h1 class="text-center mt-5">REGISTRO DE FAMILIAS</h1>
                <div class="form-group">
                    <label for="exampleInputEmail1">NOMBRE</label>
                    <asp:TextBox ID="txtNomFamilia" class="form-control" type="text" runat="server" placeholder="nombre"  required="" ></asp:TextBox>
                </div>
                <div class="row justify-content-center">
                    <div class="col-lg-4 col-md-6 col-sm-12">
                      <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="btn btn-dark btn-lg mb-5" OnClick="btnRegistrar_Click"/>
                    </div>
                </div>
                <asp:Label ID="Mensaje" class="mt-5 text-center" runat="server"></asp:Label>
            </form>
         </div>
     </div>
</body>
</html>
