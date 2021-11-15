$(document).ready(function () {
    console.log("ready!");
    GetEmpresas();
    $('#logout_').hide();
    $('#usuario_').hide();
    $('#dashboard_').hide();
    $('#uploadFile_').hide();

});

function Login() {

    var empresa = $('#empresa').val();
    var nombreEmpresa = $("#empresa option:selected").text();
    var userMail = $('#userMail').val();
    var password = $('#password').val();
    var confirmar = document.getElementById('confirmar').checked;

    if (empresa === null || userMail === '' || password === '' || !confirmar) {
        toastr.warning("Todos los campos son requeridos");
        return false;
    }

    $.ajax({
        type: "GET",
        url: urlLogin,
        data: { idEmpresa: empresa, userMail: userMail, password: password, nombreEmpresa: nombreEmpresa },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                    window.location.href = urlRedirect;
            }
            else
                toastr.warning("Usuario NO autorizado o datos incorrectos");
        }
    });
    return false;
}

function GetEmpresas() {

    $.ajax({
        type: "POST",
        url: urlGetEmpresas,
        data: {activo: true},
        datatype: "json",
        success: function (data) {
            $('#empresa').empty();
            $('#empresa').append('<option value="-1" disabled selected>Seleccione Empresa...</option>');
            $.each(data, function (index, item) {
                $('#empresa').append("<option value=\"" + item.id + "\">" + item.nombreEmpresa + "</option>");
            });
        }
    });
    return false;
}

function Reset() {
    $('#empresa').val('-1');
    $('#userMail').val('');
    $('#password').val('');
    $("#confirmar").prop("checked", false);
}

 function EmailValido(mail){
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
}


