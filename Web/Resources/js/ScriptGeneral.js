
var idFila = 1;
var cFila = 1;
var tabla = document.getElementsByTagName('table');
var tbody = tabla[0].getElementsByTagName('tbody');
var totalCol = tbody[0].childNodes[1].children.length;
var arrayElem = [];

for (var i = 1 ; i <= totalCol; i++) {
    var campo = document.getElementById("campo" + i);
    arrayElem.push([campo.firstChild.tagName,campo.firstChild.id]);
}

$(document).ready(function () {
    $('#btnNuevo').on('click', function () {
        idFila++;
        cFila++;
        funcNuevaLinea(idFila, tabla[0].id);
        document.getElementById("Hc" + tabla[0].id).value = cFila;
    });

    $('#btn' + idFila).click(function () {
        eliminar(this.id);
    });
});

function eliminar(id) {
    var idTabla = tabla[0].id;
    if (id.length == 4) {
        var id = id.substring(3, 4);
        $('#' + id).remove();
        Reordenar(idTabla);
        cFila = cFila - 1;
    }
    else {
        var id = id.substring(3, 5);
        $('#' + id).remove();
        Reordenar(idTabla);
        cFila = cFila - 1;
    }
    ReordenarId(idTabla);
    document.getElementById("Hc" + tabla[0].id).value = cFila;
}

function Reordenar(idTabla) {
    var num = 1;
    $id = "#"+idTabla+" tbody tr";
    $($id).each(function () {
        $(this).find("td p").text(num);
        num++;
    });
}

function ReordenarId(idTabla) {
    var r=1;
    var aux = 0;
    var child;
    var idText;
    var pasoPri = 1;
    for (var i = 1 ; i <= cFila+1 ; i++) {
        if(pasoPri == 1){
            for (var j = 1; j <= ((totalCol-1)*2)+1; j+=2) {
                child = tbody[0].childNodes[i].childNodes[j].childNodes[0].firstChild;   
                idText = arrayElem[aux][1];
                idText = idText.substring(0,idText.length-1);
                console.log(idText + r);
                child.id= idText + r;
                child.name= idText + r;
                aux++;        
            }
            if(i == 1){
                i = i +1;
            }
            pasoPri = 2;
        }   
        else{
            aux = 0;
            for (var j = 0; j <= totalCol-2; j++) {
                child = tbody[0].childNodes[i].childNodes[j].childNodes[0].firstChild;   
                idText = arrayElem[aux][1];
                idText = idText.substring(0,idText.length-1);
                console.log(idText + r);
                child.id= idText + r;
                child.name= idText + r;
                aux++;        
            }
        }
        r++;
    }
}

function funcNuevaLinea(cont, idTabla) {
    var nuevaFila = "";
    $("#"+idTabla+">tbody")
        .append
        (
        $('<tr>').attr('id', idFila)
            .append
            (
                function(){
                    for (var i = 0; i < totalCol; i++) {
                        var tagName = arrayElem[i][0];
                        var idText = arrayElem[i][1];
                        idText = idText.substring(0,idText.length-1);
                        switch(tagName){   
                            case 'P':       nuevaFila = nuevaFila + "<td><div><p>"+idFila+"</p></div></td>";
                                            break;
                            case 'BUTTON':  nuevaFila = nuevaFila + "<td><div class='d-flex justify-content-center input-group input-group-sm'><button class='btn btn-sm btn-danger mr-sm-2 btn-sm' id='"+idText+idFila+"' onclick='eliminar(this.id)'>Eliminar</button></div></td>";
                                            break;
                            case 'INPUT':   nuevaFila = nuevaFila + "<td><div class='input-group input-group-sm'><input type='text' runat='server' id='"+idText+idFila+"' name='"+idText+idFila+"' class='form-control'/></div></td>"
                                            break; 
                            case 'SELECT':  nuevaFila = nuevaFila + "<td><div class='input-group input-group-sm'><select id='"+idText+idFila+"' name='"+idText+idFila+"' class='form-control'><option value='0'>Prueba</option></select></div></td>"
                                            break;                       
                        }    
                    }
                    return nuevaFila;
                }
            )
        );
    Reordenar(idTabla);
}



