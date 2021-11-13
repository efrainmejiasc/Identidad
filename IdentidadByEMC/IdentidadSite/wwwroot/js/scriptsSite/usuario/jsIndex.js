$(document).ready(function () {
    console.log("ready!");
    LimpiarForm();
    $('#usuario_').hide();
    GetRolesUsuario();
});

function GetRolesUsuario() {

    $('#rol').empty();
    $('#rol').append('<option value="-1" disabled selected>Select user rol...</option>');
    $('#rol').append("<option value=\"" + 1 + "\">" + 'Directivo' + "</option>");
    $('#rol').append("<option value=\"" + 2 + "\">" + 'Administrador' + "</option>");
    $('#rol').append("<option value=\"" + 3 + "\">" + 'Profesor' + "</option>");
    $('#rol').append("<option value=\"" + 4 + "\">" + 'Representante' + "</option>");

    return false;

}


function CrearUsuario()
{
    var nombre = $('#nombre').val();
    var apellido = $('#apellido').val();
    var idRol = $('#rol').val();
    var username = $('#username').val();
    var email = $('#email').val();
    var password = $('#password').val();
    var cpassword = $('#cpassword').val();

    console.log(password + ' ' + cpassword);

    if ( nombre === '' || apellido === '' || idRol === '' || username === '' || email === '' || password === '' || cpassword === '') {
        toastr.warning("Todos los campos son requeridos.");
        return false;
    }
    else if (!EmailValido(email)) {
        toastr.warning("El email no es valido.");
        return false;
    }
    else if (password != cpassword ) {
        toastr.warning("Las contraseñas deben ser identicas");
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlAddUsuario,
        data: {Nombre: nombre, Apellido: apellido, IdRol: idRol, UserName: username, Email: email, Password: password },
        datatype: "json",
        success: function (data) {
            if (data.estatus)
            {
                toastr.success("Transaccion exitosa.");
                setTimeout(LimpiarForm, 4000);
            }
            else
            {
                toastr.warning("Transaccion fallida.");
            }
        }
    });

    return false;
}

function EmailValido(mail) {
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
}

function LimpiarForm() {
    $('#rol').val('');
    $('#username').val('');
    $('#email').val('');
    $('#password').val('');
    $('#cpassword').val('');
    $('#nombre').val('');
    $('#apellido').val('');
}

function GotoUsers() {
    window.location.href = urlAllUsers ;
}
