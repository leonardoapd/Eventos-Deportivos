$(function () {
    $("body").on('click', '.editar', function () {
        var obj = {};
        obj.Id = $(this).attr('data-id');
        var id = $(this).closest('tr').find('#id-arbitro').html();
        var documento = $(this).closest('tr').find('#documento-arbitro').html();
        var nombre = $(this).closest('tr').find('#nombre-arbitro').html();
        var apellido = $(this).closest('tr').find('#apellido-arbitro').html();
        var torneoId = $(this).closest('tr').find('#torneoId-arbitro').html();
        var escuelaId = $(this).closest('tr').find('#escuelaId-arbitro').html();
        var genero = $(this).closest('tr').find('#genero-arbitro').html();
        var telefono = $(this).closest('tr').find('#telefono-arbitro').html();
        var correo = $(this).closest('tr').find('#correo-arbitro').html();
        var deporte = $(this).closest('tr').find('#deporte-arbitro').html();

        $.ajax({
            url: '/Arbitro',
            data: JSON.stringify(obj),
            type: 'GET',
            dataType: 'html',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                /*var id = JSON.parse(response).arbitro.Id;
                var nombre = JSON.parse(response).arbitro.Nombre;*/
                $('#txtId').val(id);
                $('#txtDocumento').val(documento);
                $('#txtNombre').val(nombre);
                $('#txtApellido').val(apellido);
                $('#txtTorneoId').val(torneoId);
                $('#txtEscuelaId').val(escuelaId);
                $('#txtGenero').val(genero);
                $('#txtTelefono').val(telefono);
                $('#txtCorreo').val(correo);
                $('#txtDeporte').val(deporte);
                $("#popup-editar").modal("show");
            }
        });
    });
});