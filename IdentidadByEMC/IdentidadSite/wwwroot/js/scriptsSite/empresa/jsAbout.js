$(document).ready(function () {
    console.log("ready!");

});


function CrearEmpresa() {
    var nombre = $('#nombre').val();
    var rfc = $('#rfc').val();
    var direccion = $('#direccion').val();
    var telefono = $('#telefono').val();
    var email = $('#email').val();

    if (nombre === '' || rfc === '' || direccion === '' || telefono === '' || email === '' ) {
        toastr.warning("Todos los campos son requeridos.");
        return false;
    }
    else if (!EmailValido(email)) {
        toastr.warning("El email no es valido.");
        return false;
    }
 

    $.ajax({
        type: "POST",
        url: urlAddEmpresa,
        data: { NombreEmpresa: nombre, Rfc: rfc, Direccion: direccion, Telefono: telefono, Email:email},
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                toastr.success("Transaccion exitosa.");
                setTimeout(LimpiarForm, 4000);
            }
            else {
                toastr.warning("Transaccion fallida.");
            }
        }
    });

    return false;
}


function LimpiarForm() {
    $('#nombre').val('');
    $('#rfc').val('');
    $('#direccion').val('');
    $('#telefono').val('');
    $('#email').val('');
}

function EmailValido(mail) {
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
}
