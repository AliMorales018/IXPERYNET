﻿var idFila = 1;
var cFila = 1;

<<<<<<< HEAD
$(document).ready(function () {
    $('#btnNuevo').click(function () {
        idFila++;
        cFila++;
        funcNuevaFam(idFila);
        document.getElementById("Hc").value = cFila;
    });

    $('#btn' + idFila).click(function () {
        eliminar(this.id);
    });
});
function eliminar(id) {
    if (id.length == 4) {
        var id = id.substring(3, 4);
        $('#' + id).remove();
        Reordenar();
        cFila = cFila - 1;
        document.getElementById("Hc").value = cFila;
    }
    else {
        var id = id.substring(3, 5);
        $('#' + id).remove();
        Reordenar();
        cFila = cFila - 1;
        document.getElementById("Hc").value = cFila;
    }
}

function funcNuevaFam(cont) {
    $("#tblFamilia")
        .append
        (
        $('<tr>').attr('id', idFila)
=======
      $(document).ready(function(){
          $('#btnNuevo').on('click',function(){
              idFila++;
              cFila++;
              funcNuevaLinea(idFila);
              document.getElementById("Hc").value = cFila;
          });

          $('#btn'+idFila).click(function(){
                eliminar(this.id);
          });
      });

      function eliminar(id){
          if(id.length == 4){
              var id = id.substring(3,4);
              $('#'+id).remove();
              Reordenar();
              cFila = cFila - 1;
              document.getElementById("Hc").value = cFila;
          }
          else{
              var id = id.substring(3,5);
              $('#'+id).remove();
              Reordenar();
              cFila = cFila - 1;
              document.getElementById("Hc").value = cFila;
          }
      }

    function funcNuevaLinea(cont) {
        $("#tblUsuarios>tbody")
        .append
        (
            $('<tr>').attr('id',idFila)
            .append
            (
                $('<td>')
                .append
                (
                  $('<p>').text(idFila)
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
                    "<input type='text' runat='server' id='"+'txtNombre'+idFila+"' name='"+'txtNombre'+idFila+"'class='form-control'/>"
                  )
                )
            )
>>>>>>> 25d34e979951cb2507ed09069c99748e92ee495d
            .append
            (
            $('<td>')
                .append
                (
<<<<<<< HEAD
                $('<p>').text(idFila)
=======
                  $('<div>').addClass('input-group input-group-sm')
                  .append
                  (
                    "<input type='text' runat='server' id='"+'txtApellidoP'+idFila+"' name='"+'txtApellidoP'+idFila+"' class='form-control'/>"
                  )
>>>>>>> 25d34e979951cb2507ed09069c99748e92ee495d
                )
            )
            .append
            (
            $('<td>')
                .append
                (
<<<<<<< HEAD
                $('<div>').addClass('input-group input-group-sm')
                    .append
                    (
                    "<input type='text' id='" + 'txtNomFam' + cont + "'  name='" + 'txtNomFam' + cont + "' runat='server' class='form-control' />"
                    )
=======
                  $('<div>').addClass('input-group input-group-sm')
                  .append
                  (
                    "<input type='text' runat='server' id='"+'txtApellidoM'+idFila+"' name='"+'txtApellidoM'+idFila+"' class='form-control'/>"
                  )
>>>>>>> 25d34e979951cb2507ed09069c99748e92ee495d
                )
            )
            .append
            (
            $('<td>')
                .append
                (
<<<<<<< HEAD
                "<button class='btn btn-sm btn-danger' id='" + 'btn' + idFila + "' onclick='eliminar(this.id)'>Eliminar</button>"
                )
            )
        );
    Reordenar();
}


function Reordenar() {
    var num = 1;
    $('#tblFamilia tr td p').each(function () {
        $(this).text(num);
        num++;
    });
}

function Reordenar() {
    var num = 1;
    $('#tblFamilia tr td p').each(function () {
        $(this).text(num);
        num++;
    });
    ReordenarId();
}

function ReordenarId() {
    var r = 0;
    $('#tblFamilia tbody tr').each(function () {
        $(this).find('td div input').each(function (index) {
            $(this).removeAttr('id');
            $(this).removeAttr('name');
            switch (index) {
                case 0: $(this).attr('id', 'txtNomFam' + r);
                        $(this).attr('name', 'txtNomFam' + r);
                    break;
                default:
            }
        });
        r++;
    });
}
=======
                  $('<div>').addClass('input-group input-group-sm')
                  .append
                  (
                    "<input type='text' runat='server' id='" + 'txtUsuario' + idFila + "' name='" + 'txtUsuario' + idFila + "' class='form-control'/>"
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
                    "<input type='text' runat='server' id='" + 'txtClave' + idFila + "' name='" + 'txtClave' + idFila + "' class='form-control'/>"
                  )
                )
            )
            .append
            (
                $('<td>')
                .append
                (
                  "<button class='btn btn-sm btn-danger' id ='"+'btn'+idFila+"' onclick='eliminar(this.id)'>Eliminar</button>"
                )
            )
            ,);
        Reordenar();
      }

      
      function Reordenar(){
          var num = 1;
          $('#tblUsuarios tr td p').each(function(){
            $(this).text(num);
            num++;
          });
          ReordenarId();
      }

      function ReordenarId() {    
          var r = 0;
          $('#tblUsuarios tbody tr').each(function () {    
              $(this).find('td div input').each(function (index) {
                  $(this).removeAttr('id');
                  switch (index) {
                      case 0:   $(this).attr('id', 'txtNombre' + r);
                                break;
                      case 1:   $(this).attr('id', 'txtApellidoP' + r);
                                break;
                      case 2:   $(this).attr('id', 'txtApellidoM' + r);
                                break;
                      case 3:   $(this).attr('id', 'txtUsuario' + r);
                                break;
                      case 4:   $(this).attr('id', 'txtClave' + r);
                                break;
                      default:
                  }             
              });
              r++;
          });
      }


>>>>>>> 25d34e979951cb2507ed09069c99748e92ee495d
