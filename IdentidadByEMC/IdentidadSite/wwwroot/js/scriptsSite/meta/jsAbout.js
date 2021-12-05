$(document).ready(function () {
    console.log("ready!");
    GetTurno();
    GetGrados();
    GetGrupos();
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

function BuscarPersonas() {
    var grado = $('#grado option:selected').text();
    var grupo = $('#grupo option:selected').text();
    var turno = $('#turno').val();


    $.ajax({
        type: "GET",
        url: urlBuscarPersonas,
        data: { grado: grado, grupo: grupo, turno: turno },
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
                       <td><input type="button" class="btn btn-sm btn-primary" onclick="MostrarResumen( ${item.id}, '${item.nombre}', '${item.apellido}', '${item.matricula}', '${item.email}')" value="Resumen" ></td>
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


function MostrarResumen(id, nombre, apellido, matricula, email) {
    $('#resumen').show();
    GetResumenAsistenciaDNI(matricula);
}

function OcultarResumen() {
    $('#resumen').hide();
}

function GetResumenAsistenciaDNI(dni) {

    var total = 0;

    $.ajax({
        type: "GET",
        url: urlGetResumenAsistenciaDNI,
        datatype: "json",
        data: { dni: dni },
        success: function (data) {
            if (data != null) {
                $('#tableResumen tbody tr').remove();
                $.each(data, function (index, item) {
                    total = total + item.NumeroInasistencia;
                    let tr = `<tr> 
                      <td style="text-align: center;"> ${index + 1} </td>
                      <td style="text-align: justify;"> ${item.fecha} </td>
                      <td style="text-align: justify;"> ${item.materia} </td>
                      <td style="text-align: center;"> ${item.observacion} </td>
                      </tr>`;
                    $('#tableResumen tbody').append(tr);
                    $('#total').html(total + ' &nbsp;&nbsp;');
                });
            }
            else {
                $('#tableResumen  tbody tr').remove();
            }
        },
        complete: function () {
            console.log('GetResumen');
        }
    });

    return false;
}

