$(document).ready(function () {
    console.log("ready!");
    $('#personas_').hide();
    GetTurno();
    GetGrados();
    GetGrupos();
});

function GetTurno() {
    $('#turno').empty();
    $('#turno').append('<option selected disabled value=""> Seleccione turno...</option>');
    $('#turno').append('<option  value="1">MAÑANA</option>');
    $('#turno').append('<option  value="2">TARDE</option>');
    $('#turno').append('<option  value="3">NOCHE</option>');
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