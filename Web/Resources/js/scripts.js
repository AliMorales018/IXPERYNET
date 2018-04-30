var idFila = 1;

      $("#btnGuardar").click(function () {
            var mitabla = [];
            $("#tblUsuarios tbody tr").each(function () {
                var tr = [];
                $(this).find("td div").each(function () {
                    tr.push($(this).text());
                });
                mitabla.push(tr)
            });
            alert(mitabla);
      });

      $(document).ready(function(){
          $('#btnNuevo').click(function(){
                idFila++;
                funcNuevaLinea(idFila);
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
          }
          else{
              var id = id.substring(3,5);
              $('#'+id).remove();
              Reordenar();
          }
      }

      function funcNuevaLinea(cont){
        $("#tblUsuarios")
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
                  "<button class='btn btn-sm btn-danger' id ='"+'btn'+idFila+"' onclick='eliminar(this.id)'>Eliminar</button>"
                )
            )
        );
        Reordenar();
      }

      
      function Reordenar(){
          var num = 1;
          $('#tblUsuarios tr td p').each(function(){
            $(this).text(num);
            num++;
          });
      }

