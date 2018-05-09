var idFila = 1;
var cFila = 1;
var estado = 0;//0:estado inicial para registro; 1:boton buscar
//0: estado para preguntar si desea buscar y perder su información //1:ya esta buscando
$(document).ready(function () {
    //var buscarAct5;
    $('#btnNuevo').click(function () {
        // document.getElementById("HBuscar").value = 0;
        //var valor = document.getElementById("txtCategoria" + idFila).value;
        //if (valor == "") {
        //    alert('Intenta crear una nueva fila y la anterior está vacía');
        //    document.getElementById("txtCategoria" + idFila).focus();
        //} else {
        //buscarAct = 0
        controlEstado();
        //ocultaTbody("divControl");
        eselec = document.getElementById("cmbCatT");
        eselec2 = document.getElementById("cmbUmedT");
        muestraTbody("tbodyCol");
        //ocultaTbody("gvCategoria");
        //document.getElementById("gvCategoria").style.visibility = "hidden";
        $("#gvProducto").text("");
        //}
    });
    $('#btn' + idFila).click(function () {
        eliminar(this.id);
    });
    $('#btnBusProd').click(function () {
        llenaCmbTemp();
    });
});
function llenaCmbTemp() {
    //if (buscarAct === 0) {
    //    var opcion = confirm("Tiene registros por guardar, si realiza búsqueda perdera esta información..¿Está seguro de continuar?");
    //    if (opcion == true) {
    //      buscarAct = 1;
    idFila = 1;
    cFila = 1;
    estado = 1;
    //document.getElementById("HBuscar").value = 1;
    //$('#cmbCat1').clone().attr('id', 'cmbCat1').attr('name', 'cmbCat1').attr('class', 'form-control').attr('runat', 'server').insertAfter('#cmbCatT');
    //$('#cmbUmed1').clone().attr('id', 'cmbUmed1').attr('name', 'cmbUmed1').attr('class', 'form-control').attr('runat', 'server').insertAfter('#cmbUmedT');V 
    eliminarElemento("tbodyCol");
        //} 
        //} 
}
function controlEstado() {
    if (estado == 0) {
        idFila++;
        cFila++;
        document.getElementById("Hc").value = cFila;
        funcNuevaCat(idFila);
    } else {
        nuevaCatIni();
        idFila = 1;
        cFila = 1;
        estado = 0;
    }
}
function nuevaCatIni() {
    $("#tblProducto")
        .append
        (
        $('<tbody>').attr('id', 'tbodyCol')
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
                        $('#cmbCat1').clone().attr('id', 'cmbCat1').attr('name', 'cmbCat1').attr('class', 'form-control').attr('runat', 'server').insertAfter('#cmbCat1')
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
                        "<input type='text' required='required' runat='server' id='txtProducto1' name='txtProducto1' class='form-control'/>"
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
                        "<input type='text' required='required' runat='server' id='txtCantidad1' name='txtCantidad1' class='form-control'/>"
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
                        $('#cmbUmed1').clone().attr('id', 'cmbUmed1').attr('name', 'cmbUmed1').attr('class', 'form-control').attr('runat', 'server').insertAfter('#cmbUmed1')
                        )
                    )
                )
                .append
                (
                $('<td>')
                    .append
                    (
                    "<button class='btn btn-sm btn-danger'>Eliminar</button>"
                    )
                )
            ));
}
function ocultaTbody(id) {
    document.getElementById(id).style.display = "none";
}
function muestraTbody(id) {
    document.getElementById(id).style.display = "inline";
}
function prueba() {
    alert("XD");
}
function eliminarElemento(id) {
    eBody = document.getElementById(id);
    if (!eBody) {
        //alert("El elemento selecionado no existe");
    } else {
        padre = eBody.parentNode;
        padre.removeChild(eBody);
        padre2 = eselec.parentNode;
        padre2.removeChild(eselec);
        padre3 = eselec2.parentNode;
        padre3.removeChild(eselec2);
    }
}
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
    $("#tblProducto")
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
                    $('#cmbCat1').clone().attr('id', 'cmbCat' + cont).attr('name', 'cmbCat' + cont).attr('class', 'form-control').attr('runat', 'server').insertAfter('#cmbCat1')
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
                    "<input type='text' required='required' runat='server' id='" + 'txtProducto' + cont + "' name='" + 'txtProducto' + cont + "' class='form-control'/>"
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
                    "<input type='text' required='required' runat='server' id='" + 'txtCantidad' + cont + "' name='" + 'txtCantidad' + cont + "' class='form-control'/>"
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
                    $('#cmbUmed1').clone().attr('id', 'cmbUmed' + cont).attr('name', 'cmbUmed' + cont).attr('class', 'form-control').attr('runat', 'server').insertAfter('#cmbUmed1')
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
    $('#tblProducto tr td p').each(function () {
        $(this).text(num);
        num++;
    });
    ReordenarId();
}

function ReordenarId() {
    var r = 1;
    $('#tblProducto tbody tr').each(function () {
        $(this).find('td div input').each(function (index) {
            $(this).removeAttr('id');
            $(this).removeAttr('name');
            switch (index) {
                case 0: $(this).attr('id', 'txtProducto' + r);
                    $(this).attr('name', 'txtProducto' + r);
                    break;
                case 1: $(this).attr('id', 'txtCantidad' + r);
                    $(this).attr('name', 'txtCantidad' + r);
                    break;
                default:
            }
        });
        $(this).find('td div select').each(function (index) {
            $(this).removeAttr('id');
            $(this).removeAttr('name');
            switch (index) {
                case 0: $(this).attr('id', 'cmbCat' + r);
                    $(this).attr('name', 'cmbCat' + r);
                    break;
                case 1: $(this).attr('id', 'cmbUmed' + r);
                    $(this).attr('name', 'cmbUmed' + r);
                    break;
                default:
            }
        });
        r++;
    });
}