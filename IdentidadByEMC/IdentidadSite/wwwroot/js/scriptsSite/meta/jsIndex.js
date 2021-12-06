$(document).ready(function () {
    console.log("ready!");
    GetTurno();
    GetGrados();
    GetGrupos();
    GetTipoAsistencia();
    GetMateria();
    var date = FechaActual();
    $('#fecha').val(date);
});

function GetTurno() {
    $('#turno').empty();
    $('#turno').append('<option selected disabled value="-1"> Seleccione turno...</option>');
    $('#turno').append('<option  value="1">Mañana</option>');
    $('#turno').append('<option  value="2">Tarde</option>');
    $('#turno').append('<option  value="3">Noche</option>');
}

function GetGrados() {
    $.ajax({
        type: "GET",
        url: urlGetGrados,
        datatype: "json",
        success: function (data) {
            $('#grado').empty();
            $('#grado').append('<option selected disabled value=""> Seleccione grado...</option>');

            $.each(data, function (index, item) {
                $('#grado').append("<option value=\"" + item + "\">" + item + "</option>");
            });
        }
    });
    return false;
}

function GetGrupos() {
    $.ajax({
        type: "GET",
        url: urlGetGrupos,
        datatype: "json",
        success: function (data) {
            $('#grupo').empty();
            $('#grupo').append('<option selected disabled value=""> Seleccione grupo...</option>');

            $.each(data, function (index, item) {
                $('#grupo').append("<option value=\"" + item + "\">" + item + "</option>");
            });
        }
    });
    return false;
}

function GetTipoAsistencia() {
    $('#tipoAsistencia').empty();
    $('#tipoAsistencia').append('<option selected disabled value="-1"> Seleccione asistencia...</option>');
    $('#tipoAsistencia').append('<option  value="1">Asistente</option>');
    $('#tipoAsistencia').append('<option  value="0">Inasistente</option>');
}

function GetMateria() {
    $('#materia').empty();
    $('#materia').append('<option selected disabled value="-1"> Seleccione materia...</option>');
    $('#materia').append('<option  value="1">Matematica</option>');
    $('#materia').append('<option  value="2">Castellano</option>');
    $('#materia').append('<option  value="3">Quimica</option>');
    $('#materia').append('<option  value="4">Fisica</option>');

    $('#catedra').empty();
    $('#catedra').append('<option selected disabled value="-1"> Seleccione materia...</option>');
    $('#catedra').append('<option  value="1">Matematica</option>');
    $('#catedra').append('<option  value="2">Castellano</option>');
    $('#catedra').append('<option  value="3">Quimica</option>');
    $('#catedra').append('<option  value="4">Fisica</option>');
}


function MostrarModalAsistencia(id, nombre, apellido, matricula,email) {
    $('#nombre').val(nombre + ' ' + apellido);
    $('#matricula').val(matricula);
    $('#e_mail').val(email);
    $('#asistencia_').show();
}



function OcultarModalAsistencia() {
    $('#tipoAsistencia').val(-1);
    $('#materia').val(-1);
    $('#nombre').val('');
    $('#matricula').val('');
    $('#observacion').val('');
    var date = FechaActual();
    $('#fecha').val(date);

    $('#asistencia_').hide();
}

function FechaActual() {

    var today = new Date();
    var year = today.getFullYear();
    var moth = (today.getMonth() + 1) <= 9 ? "0" + (today.getMonth() + 1) : (today.getMonth() + 1);
    var day = today.getDate() <= 9 ? "0" + today.getDate() : today.getDate();
    var date = year + '-' + moth + '-' + day;

    return date;
}

function BuscarPersonas() {
   var grado =  $('#grado option:selected').text();
   var grupo = $('#grupo option:selected').text();
   var turno = $('#turno').val();


    $.ajax({
        type: "GET",
        url: urlBuscarPersonas,
        data: {grado: grado, grupo: grupo, turno: turno},
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaUsuarios tbody tr').remove();
                $.each(data, function (index, item) {
                    var n = index + 1;
                    let tr = `<tr>
                      <td id="${n}">&nbsp;&nbsp;&nbsp;<input type="checkbox" id="chk_${n}" class="form-check-input" /> </td>
                      <td> ${item.nombre} </td>
                      <td> ${item.apellido} </td>
                      <td> ${item.email} </td>
                      <td> ${item.matricula} </td>
                       <td><input type="button" class="btn btn-sm btn-primary" onclick="MostrarModalAsistencia( ${item.id}, '${item.nombre}', '${item.apellido}', '${item.matricula}', '${item.email}')" value="Observacion" style="width:100px;" ></td>
                      </tr>`;
                    $('#tablaUsuarios tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 1000);
            }
            else {
                $('#tablaUsuarios tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaUsuarios tbody tr').remove();
        }
    });

    $("#tablaUsuarios").addClass("display compact dt-center");
    return false;

}


function InicializarDataTable() {
    var init = $('#initDataTable').val();

    try {
        if (init === 'no') {
            $('#tablaUsuarios').DataTable({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple",
                "pageLength": 60
            });
            $('#initDataTable').val('si');
        } else {
            $('#tablaUsuarios').DataTable().fnDestroy({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple"
            });
        }
    } catch { console.log(''); }

    $("#tablaUsuarios").addClass("display compact dt-center");
}


function GetIdPersonas() {

    var catedra = $('#catedra').val();
    if (catedra === '' || catedra <= 0) {
        toastr.warning("Debe seleccionar una materia");
        return false;
    }


    var asistenciaDTO = new Array()
    var nfilas = $("#tablaUsuarios").find("tr");

    for (var i = 1; i < nfilas.length; i++) {

        var celdas = $(nfilas[i]).find("td");

        var seleccion = document.getElementById('chk_' + i.toString()).checked;
        console.log(seleccion);

        if (seleccion)
        {

            var x = {};
            x.Nombre = $(celdas[1]).text();
            x.Apellido = $(celdas[2]).text();
            x.EmailSend = $(celdas[3]).text();
            x.Matricula= $(celdas[4]).text();
            x.Dni = $(celdas[4]).text();
            x.Activo = true;
            x.Turno = $('#turno').val();
            x.Grado = $('#grado option:selected').text();
            x.Grupo = $('#grupo option:selected').text();
            x.Materia = $('#catedra option:selected').text();
            x.Asistencia = false;

            asistenciaDTO.push(x);
        }

    
    }

    $.ajax({
        type: "POST",
        url: urlGuardarAsistencia,
        data: { asistenciaDTO: JSON.stringify(asistenciaDTO) },
        datatype: "json",
        success: function (data) {
            if (data.estatus)
                toastr.success("Asistencia guardada satisfactoriamente");
            else
                toastr.error("Ocurrio un error");
        }
    });

    return false;
}

function GuardarAsistenciaEspecifica() {
    var names = $('#nombre').val();
    var pNames = names.split('-');

    var materia = $('#materia').val();

    var asistencia = $('#tipoAsistencia option:selected').text();
    var x_asistencia = true;
    if (asistencia.trim() === 'Inasistente')
        x_asistencia = false;



    if (materia ===  null || asistencia === '') {
        toastr.warning("todos los campos son requeridos");
        return false;
    }

    console.log(asistencia);

    var asistenciaDTO = new Array()
    var x = {};
    x.Nombre = pNames[0];
    x.Apellido = pNames[1];
    x.EmailSend = $('#e_mail').val();;
    x.Matricula = $('#matricula').val();
    x.Dni = $('#matricula').val();
    x.Activo = true;
    x.Turno = $('#turno').val();
    x.Grado = $('#grado option:selected').text();
    x.Grupo = $('#grupo option:selected').text();
    x.Fecha = $('#fecha').val();
    x.Materia = $('#materia option:selected').text();;
    x.Observacion = $('#observacion').val();
    x.Asistencia = x_asistencia;

    asistenciaDTO.push(x);

    $.ajax({
        type: "POST",
        url: urlGuardarAsistencia,
        data: { asistenciaDTO: JSON.stringify(asistenciaDTO) },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                toastr.success("Asistencia guardada satisfactoriamente");
                setTimeout(OcultarModalAsistencia, 3000);
            }
            else
                toastr.error("Ocurrio un error");
        }
    });

    return false;
}