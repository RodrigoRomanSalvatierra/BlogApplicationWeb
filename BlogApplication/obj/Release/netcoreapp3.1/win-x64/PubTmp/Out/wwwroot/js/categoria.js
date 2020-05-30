var dataTable;

$(document).ready(function () {
    cargarDataTable();
});

function cargarDataTable() {
    dataTable = $("#tblCategoria").DataTable({
        //construccion del cuerpo del DataTable, ver documentacion del plugin
        "ajax": {
            // controlador con el que se va a comunicar
            "url": "/admin/categorias/GetAll",
            // tipo de peticion
            "type": "GET",
            // formato de respuesta
            "datatype": "json"
        },
        // asignamos los campos para las columnas
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "nombre", "width": "50%" },
            { "data": "orden", "width": "20%" },
            // columna para los botones
            {
                "data": "id",
                "render": function (data) {
                    return `
                     <div class='text-center'>
                       <a href='/Admin/Categorias/Edit/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                        <i class="fas fa-edit"></i> Editar
                       </a>
                        &nbsp;
                       <a onclick=Delete("/Admin/Categorias/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                        <i class="fas fa-trash-alt"></i> Eliminar
                       </a>
                    `;
                }, "width": "30%"
            },
        ],
        "language": {
            "emptyTable": "No hay registros"
        },
        "width" : "100%"
    });
}

// funcion para eliminar categoria
function Delete(url) {
    swal({
        title: "Esta seguro de Eliminar el registro?",
        text: "Este contenido no se podra recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6855",
        confirmButtonText: "Si, borrar.",
        closeOnconfirm: true,
    }, function () {
        $.ajax({
            type: "DELETE",
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}