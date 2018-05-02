<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detalle_Prueba.aspx.cs" Inherits="Prueba_Detalle_Prueba" %>

<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../Resources/css/bootstrap.min.css">
    <link rel="stylesheet" href="../Resources/css/styles.css">
    <link rel="stylesheet" href="../Resources/css/core.css">
    <link rel="stylesheet" href="../Resources/css/colors.css">

    <title>Prueba</title>
  </head>
  <body>

    <div class="container">
        <label for="">
            <div>
              <button type="button" class="btn btn-primary mr-sm-2 btn-sm" id="btnNuevo" onclick="funcNuevaLinea();">Nuevo</button>
            </div>
        </label>
        <div class="form-group">
          <div class="table-responsive-lg text-size-sm">
            <table class="table" id="tblUsuarios">
              <thead class="thead-light">
                <tr>
                  <th class="text-center">N°</th>
                  <th class="text-center">Nombre</th>
                  <th class="text-center">Apellido Paterno</th>
                  <th class="text-center">Apellido Materno</th>
                  <th class="text-center">Usuario</th>
                  <th class="text-center">Email</th>
                  <th class="text-center">Eliminar</th>
                </tr>
              </thead>
              <tr>
                  <td><p>1</p></td>
                  <td><div class="input-group input-group-sm"><input type="text" class="form-control"></div></td>
                  <td><div class="input-group input-group-sm"><input type="text" class="form-control"></div></td>
                  <td><div class="input-group input-group-sm"><input type="text" class="form-control"></div></td>
                  <td><div class="input-group input-group-sm"><input type="text" class="form-control"></div></td>
                  <td><div class="input-group input-group-sm"><input type="text" class="form-control"></div></td>
                  <td class="text-center">
                      <button type="button" class="btn btn-danger mr-sm-2 btn-sm">Eliminar</button>
                  </td>
              </tr>
            </table>
          </div>
        </div>
    </div>
   
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="../Resources/js/jquery-3.2.1.slim.min.js"></script>
    <script src="../Resources/js/popper.min.js"></script>
    <script src="../Resources/js/bootstrap.min.js"></script>
    <script src="../Resources/js/smooth-scroll.min.js"></script>

    <script>

      var cont = 1;

      function funcNuevaLinea(){
        cont++;
        $("#tblUsuarios")
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
                      $('<input>').attr('type','text').addClass('form-control')
                  )
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
                      $('<input>').attr('type','text').addClass('form-control')
                  )
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
                      $('<input>').attr('type','text').addClass('form-control')
                  )
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
                      $('<input>').attr('type','text').addClass('form-control')
                  )
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
                      $('<input>').attr('type','text').addClass('form-control')
                  )
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

    </script>
  </body>
  <!-- End Body -->
</html>