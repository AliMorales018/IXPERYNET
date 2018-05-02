<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Producto.aspx.cs" Inherits="Aplicaciones_Logistica_Producto" %>

<!DOCTYPE html>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro_familia</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="/Resources/css/bootstrap.min.css">
    <link rel="stylesheet" href="/Resources/css/icons/styles.css">
    <link rel="stylesheet" href="/Resources/css/core.css">
    <link rel="stylesheet" href="/Resources/css/colors.css">
    <style type="text/css">
        .auto-style1 {
            width: 72px;
        }
    </style>
</head>
<body class="bg-light">
      <div class="container">
        <div class="row justify-content-center">
            <form id="form1" runat="server" class="">
                <h1 class="text-center mt-5">REGISTRO DE PRODUCTOS</h1>

                <div class="container">
                <%--<label for="">
                    <div>
                      <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo" onclick="funcNuevaLinea();">Nuevo</button>
                    </div>
                </label>--%>
                <div class="form-group">
                  <div class="table-responsive-lg text-size-sm">



                    <table class="table" id="tblFamilia" runat="server">
                      <thead class="thead-light">
                        <tr>
                          <th class="text-center">N°</th>
                          <th class="text-center">Categoria</th>
                          <th class="text-center">Nombre Producto</th>
                          <th class="text-center">Cant.</th>
                          <th class="text-center">Unidad Medida</th>
                        </tr>
                      </thead>
                      <tr>
                          <td><p>1</p></td>
                          <td>
                              <div class="input-group input-group-sm">
                                <%--<input type="text" id="txtNomFam" class="form-control">--%>
                                <asp:DropDownList ID="cmbFami"   runat="server" class="form-control" />
                              </div>
                          </td>
                           <td>
                              <div class="input-group input-group-sm">
                                <%--<input type="text" id="txtNomFam" class="form-control">--%>
                                <asp:TextBox ID="txtProd"   runat="server" class="form-control" />
                              </div>
                          </td>
                          <td>
                              <div class="input-group input-group-sm">
                                <%--<input type="text" id="txtNomFam" class="form-control">--%>
                                <asp:TextBox ID="txtCant"   runat="server" class="form-control" />
                              </div>
                          </td>
                          <td>
                              <div class="input-group input-group-sm">
                                <%--<input type="text" id="txtNomFam" class="form-control">--%>
                                <asp:DropDownList ID="cmbUmed"   runat="server" class="form-control" />
                              </div>
                          </td>
                          <td class="auto-style1">
                              <label for="">
                                    <div>
                                      <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo" onclick="funcNuevaLinea();">Nuevo</button>
                                    </div>
                                </label>
                          </td>
                          <td>
                              <button type="button" class="btn btn-danger mr-sm-2 btn-sm">Eliminar</button>
                          </td>
                      </tr>
                    </table>




                  </div>
                </div>
               <asp:Button ID="btnSave" runat="server" Text="Guardar" class="btn btn-dark btn-lg mb-5"/>
    </div>
            </form>
         </div>
     </div>

    
   
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="/Resources/js/jquery-3.2.1.slim.min.js"></script>
    <script src="/Resources/js/popper.min.js"></script>
    <script src="/Resources/js/bootstrap.min.js"></script>
    <script src="/Resources/js/smooth-scroll.min.js"></script>

    <script>

      var cont = 1;

      function funcNuevaLinea(){
        cont++;
        $("#tblFamilia")
        .append
        (
            $('<tr>')
            .append
            (
                $('<td>')
                .append
                (
                  $('<p>').attr('id','cont').text(cont)
                )
            )
            .append
            (
                $('<td>')
                .append
                (
                  $('<div>').addClass('input-group input-group-sm')
                  .append
                    (
                    //$('<asp:TextBox>').attr('ID', 'txtNomFam').addClass('form-control')
                      //<input name="txtNomFam" type="text" id="txtNomFam" class="form-control">
                    $('<input>').attr('type', 'text').attr('id','txtNomFam').attr('name','txtNomFam').addClass('form-control')
                      //$('<asp>').attr('type','text')
                    
                    //$('<asp:>').append('TextBox').addClass('form-control')
                       <%--<input type="text" id="txtNomFam"class="form-control">--%>
                               <%-- <asp:TextBox ID="txtNomFam" Text='<%# Eval("Familia") %>' runat="server" />--%>
                    )
                )
            )
             .append
            (
                $('<td>')
                .append
                (
                  $('<div>').addClass('btn btn-primary mr-sm-2 btn-sm').text('Nuevo')
                )

            )
            .append
            (
                $('<td>')
                .append
                (
                  $('<div>').addClass('btn btn-danger btn-sm').text('Eliminar')
                )

            )
        );
          
        }
        function dihola() {
            alert('Hola');
        }
    </script>
</body>
</html>

