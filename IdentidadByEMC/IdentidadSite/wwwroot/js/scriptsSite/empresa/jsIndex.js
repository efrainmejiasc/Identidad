$(document).ready(function(){
    console.log("ready!");
    GetEmpresas();
});

function GetEmpresas() {
    $.ajax({
        type: "POST",
        url: urlGetEmpresas,
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaEmpresas tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = '';
                    var est = item.activo ? 'Activo' : 'Inactivo';
                    console.log(item.activo)
                    if (!item.activo)
                        tr = `<tr>
                      <td style=color:red;> ${est} </td>
                      <td> ${item.identificador.substring(0,8)} </td>
                      <td> ${item.nombreEmpresa} </td>
                      <td> ${item.rfc} </td>
                      <td> ${item.email} </td>
                      <td> ${item.telefono} </td>
                      <td> ${item.direccion} </td>
                      <td><input type="button" class="btn btn-sm btn-success" onclick="EditEstatus(${item.id},${true})" value="Activar" style="width:100px;"></td>
                      <td><input type="button" class="btn btn-sm btn-danger" onclick="DeleteEmpresa(${item.id})" value="Eliminar" style="width:100px;"></td>
                      </tr>`;
                    else
                        tr = `<tr>
                     <td style=color:green;> ${est} </td>
                      <td> ${item.identificador.substring(0, 8)} </td>
                      <td> ${item.nombreEmpresa} </td>
                      <td> ${item.rfc} </td>
                      <td> ${item.email} </td>
                      <td> ${item.telefono} </td>
                      <td> ${item.direccion} </td>
                      <td><input type="button" class="btn btn-sm btn-warning" onclick="EditEstatus(${item.id},${false})" value="Desactivar" style="width:100px;" ></td>
                      <td><input type="button" class="btn btn-sm btn-danger" onclick="DeleteEmpresa(${item.id})" value="Eliminar" style="width:100px;"></td>
                      </tr>`;

                    $('#tablaEmpresas tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 1000);
            }
            else {
                $('#tablaEmpresas tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaEmpresas tbody tr').remove();
        }
    });

    $("#tablaEmpresas").addClass("display compact dt-center");
    return false;
}

function EditEstatus(id,estatus) {
    $.ajax({
        type: "POST",
        url: urlEditEstatus,
        data: { id: id, estatus: estatus },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                GetEmpresas();
                toastr.success("Actualizacion de estatus exitosa.");
            }
            else {
                toastr.warning("Actualizacion de estatus fallida.");
            }
        }
    });
}

function DeleteEmpresa(id) {
    $.ajax({
        type: "POST",
        url: urlDeleteEmpresa,
        data: {id: id},
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                GetEmpresas();
                toastr.success("Usuario eliminado");
            }
            else {
                toastr.warning("Eliminacion de usuario fallo");
            }
        }
    });
}

function InicializarDataTable() {
    var init = $('#initDataTable').val();

    try {
        if (init === 'no') {
            $('#tablaEmpresas').DataTable({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                "searching": false,
                pagingType: "simple"
            });
            $('#initDataTable').val('si');
        } else {
            $('#tablaEmpresas').DataTable().fnDestroy({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                "searching": false,
                pagingType: "simple"
            });
        }
    } catch { console.log(''); }

    $("#tablaEmpresas").addClass("display compact dt-center");
}
