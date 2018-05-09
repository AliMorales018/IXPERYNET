//var idFila = 1;
//var cFila = 1;
//$(document).ready(function () {
//    $('#btnNuevo').click(function () {
//        idFila++;
//        cFila++;
//        funcNuevaFam(idFila);
//        document.getElementById("Hc").value = cFila;
//        //document.getElementById("txtprueba").value = "";
//        //alert(document.getElementById("txtprueba").value);
//    });

//    $('#btn' + idFila).click(function () {
//        eliminar(this.id);
//    });
//});

//function eliminar(id) {
//    if (id.length == 4) {
//        var id = id.substring(3, 4);
//        $('#' + id).remove();
//        Reordenar();
//        cFila = cFila - 1;
//        document.getElementById("Hc").value = cFila;
//    }
//    else {
//        var id = id.substring(3, 5);
//        $('#' + id).remove();
//        Reordenar();
//        cFila = cFila - 1;
//        document.getElementById("Hc").value = cFila;
//    }
//}
//function funcNuevaFam(cont) {
//    $("#tblCategoria")
//        .append
//        (
//        $('<tr>').attr('id', idFila)
//            .append
//            (
//            $('<td>')
//                .append
//                (
//                $('<p>').text(idFila)
//                )
//            )
//            .append
//            (
//            $('<td>')
//                .append
//                (
//                $('<div>').addClass('input-group input-group-sm')
//                    .append
//                    (
//                    //"<select id='" + 'cmbFam' + cont + "'  name='" + 'cmbFam' + cont + "' runat='server' size='1' class='form-control' />"
//                    $('#cmbFam1').clone().attr('id', 'cmbFam' + cont).attr('name', 'cmbFam' + cont).attr('class', 'form-control').attr('runat', 'server').insertAfter('#cmbFam1')
//                    )
//                )
//            )
//            .append
//            (
//            $('<td>')
//                .append
//                (
//                $('<div>').addClass('input-group input-group-sm')
//                    .append
//                    (
//                    "<input type='text' runat='server' id='" + 'txtCategoria' + cont + "' name='" + 'txtCategoria' + cont + "' class='form-control'/>"
//                    )
//                )
//            )
//            .append
//            (
//            $('<td>')
//                .append
//                (
//                "<button class='btn btn-sm btn-danger' id='" + 'btn' + idFila + "' onclick='eliminar(this.id)'>Eliminar</button>"
//                )
//            )
//        );
//    Reordenar();
//}

//function Reordenar() {
//    var num = 1;
//    $('#tblCategoria tr td p').each(function () {
//        $(this).text(num);
//        num++;
//    });
//    ReordenarId();
//}

//function ReordenarId() {
//    var r = 0;
//    $('#tblCategoria tbody tr').each(function () {
//        $(this).find('td div input').each(function (index) {
//            $(this).removeAttr('id');
//            $(this).removeAttr('name');
//            switch (index) {
//                case 0: $(this).attr('id', 'txtCategoria' + r);
//                    $(this).attr('name', 'txtCategoria' + r);
//                    break;
//                default:
//            }
//        });
//        $(this).find('td div select').each(function (index) {
//            $(this).removeAttr('id');
//            $(this).removeAttr('name');
//            switch (index) {
//                case 0: $(this).attr('id', 'cmbFam' + r);
//                    $(this).attr('name', 'cmbFam' + r);
//                    break;
//                default:
//            }
//        });
//        r++;
//    });
//}