
var idFila = 1;
var cFila = 1;
var arrayElem = [];
var arrayElemV = [];
var array = [];
var totalCol;
var tabla;
var tbody;

$(document).ready(function () {
    tabla = document.getElementsByTagName('table');
    tbody = tabla[0].getElementsByTagName('tbody');
    totalCol = tbody[0].childNodes[1].children.length;

    for (var i = 1; i <= totalCol; i++) {
        var campo = document.getElementById("campo" + i);
        arrayElem.push([campo.firstChild.tagName, campo.firstChild.id]);
        if (campo.firstChild.id.substring(0, 1) == "V") {
            var idTextV = campo.firstChild.id;
            idTextV = idTextV.substring(0, idTextV.length - 1);
            arrayElemV.push(idTextV);
        }
    }

    $('#btnNuevo').on('click', function () {
        idFila++;
        funcNuevaLinea(idFila, tabla[0].id);
        document.getElementById("Hc" + tabla[0].id).value = cFila;
    });
});

function eliminar(id) {
    var idTabla = tabla[0].id;
    if (id.length == 4) {
        var id = id.substring(3, 4);
        $('#' + id).remove();
        Reordenar(idTabla);
        cFila = cFila - 1;
        document.getElementById("Hc" + tabla[0].id).value = cFila;
    }
    else {
        var id = id.substring(3, 5);
        $('#' + id).remove();
        Reordenar(idTabla);
        cFila = cFila - 1;
        document.getElementById("Hc" + tabla[0].id).value = cFila;
    }
    ReordenarId(idTabla);
}

function Reordenar(idTabla) {
    var num = 1;
    $id = "#" + idTabla + " tbody tr";
    $($id).each(function () {
        $(this).find("td p").text(num);
        num++;
    });
}

function ReordenarId(idTabla) {
    var r = 1;
    var aux = 0;
    var child;
    var idText;
    var pasoPri = 1;
    var tbody = tabla[0].getElementsByTagName('tbody');
    for (var i = 1; i <= cFila + 1; i++) {
        if (pasoPri == 1) {
            for (var j = 1; j <= ((totalCol - 1) * 2) + 1; j += 2) {
                child = tbody[0].childNodes[i].childNodes[j].childNodes[0].firstChild;
                idText = arrayElem[aux][1];
                idText = idText.substring(0, idText.length - 1);
                child.id = idText + r;
                child.name = idText + r;
                aux++;
            }
            if (i == 1) {
                i = i + 1;
            }
            pasoPri = 2;
        }
        else {
            aux = 0;
            for (var j = 0; j <= totalCol - 2; j++) {
                child = tbody[0].childNodes[i].childNodes[j].childNodes[0].firstChild;
                idText = arrayElem[aux][1];
                idText = idText.substring(0, idText.length - 1);
                child.id = idText + r;
                child.name = idText + r;
                aux++;
            }
        }
        r++;
    }
}

function funcNuevaLinea(cont, idTabla) {
    var nuevaFila = "";
    var contSelect = 0;
    var idDiv = "";
    cFila++;
    $("#" + idTabla + ">tbody")
        .append
        (
        $('<tr>').attr('id', idFila)
            .append
            (
            function () {
                for (var i = 0; i < totalCol; i++) {
                    var tagName = arrayElem[i][0];
                    var idText = arrayElem[i][1];
                    if (tagName == 'SELECT') {
                        contSelect++;
                        idDiv = "div" + contSelect + "_"
                    }
                    idText = idText.substring(0, idText.length - 1);
                    switch (tagName) {
                        case 'P': nuevaFila = nuevaFila + "<td><div><p class='text-center'>" + idFila + "</p></div></td>";
                            break;
                        case 'BUTTON': nuevaFila = nuevaFila + "<td><div class='d-flex justify-content-center input-group input-group-sm'><button class='btn btn-sm btn-danger mr-sm-2 btn-sm' id='" + idText + idFila + "' onclick='eliminar(this.id)'><i class='icon icon-cross'></i></button></div></td>";
                            break;
                        case 'INPUT': nuevaFila = nuevaFila + "<td><div class='input-group input-group-sm'><input type='text' required='' runat='server' id='" + idText + idFila + "' name='" + idText + idFila + "' class='form-control'/></div></td>"
                            break;
                        case 'SELECT': nuevaFila = nuevaFila + "<td><div id='" + idDiv + idFila + "' class='input-group input-group-sm'><script type='text/javascript'>$('#" + idDiv + idFila + "').prepend($('#" + idText + "1').clone().insertAfter('#" + idDiv + idFila + "').attr('id','" + idText + idFila + "').attr('name','" + idText + idFila + "').attr('runat','server'))</script></div></td>"
                            break;
                    }
                }
                return nuevaFila;
            }
            )
        );
    Reordenar(idTabla);
    ReordenarId(idTabla);
}

function ValidarCampos() {
    var obj;
    var val;
    var id;
    document.getElementById("InputIsValid").value = "true";
    array = ObtenerValores();
    for (var a = 0; a < array.length; a++) {
        for (var i = 1; i <= cFila; i++) {
            obj = $("#" + arrayElemV[a] + i);
            obj.removeClass("is-invalid");
            val = obj.val().trim();
            id = obj.attr('id');
            for (var j = 1; j <= cFila; j++) {
                if (array[a][j - 1][1] != id) {
                    if (array[a][j - 1][0] == val) {
                        document.getElementById("InputIsValid").value = "false";
                        obj.addClass("is-invalid");
                        obj.focus();
                        return false;
                    }
                }
            }
        }
    }
    if (document.getElementById("InputIsValid").value = "true") {
        return true;
    }
}

function ObtenerValores() {
    var arrayConjunto = [];
    var Valor;
    var Id;
    for (var j = 0; j < arrayElemV.length; j++) {
        var arrayValId = [];
        for (var i = 1; i <= cFila; i++) {
            obj = $("#" + arrayElemV[j] + i);
            Valor = obj.val().trim();
            Id = obj.attr('id');
            arrayValId.push([Valor, Id]);
        }
        arrayConjunto.push(arrayValId);
    }
    return arrayConjunto;
}



