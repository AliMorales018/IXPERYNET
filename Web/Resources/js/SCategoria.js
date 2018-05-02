var idFila = 1;
var cFila = 1;
$(document).ready(function () {
    $('#btnNuevo').click(function () {
        idFila++;
        cFila++;
        funcNuevaCat(idFila);
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
function funcNuevaCat(cont) {
    $("#tblCategoria")
        .append
        (
        $('<tr>').attr('id', idFila)
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
                    "<input type='text' id='" + 'txtNomFam' + cont + "'  name='" + 'txtNomFam' + cont + "' runat='server' class='form-control' />"
                    )
                )
            )
            .append
            (
            $('<td>')
                .append
                (
                "<button class='btn btn-sm btn-danger' id='" + 'btn' + idFila + "' onclick='eliminar(this.id)'>Eliminar</button>"
                )
            )
        );
    Reordenar();
}

function Reordenar() {
    var num = 1;
    $('#tblCategoria tr td p').each(function () {
        $(this).text(num);
        num++;
    });
    ReordenarId();
}

function ReordenarId() {
    var r = 0;
    $('#tblCategoria tbody tr').each(function () {
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