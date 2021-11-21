$(function () {
    $("body").on('click', '.editar', function () {
        var obj = {};
        obj.Id = $(this).attr('data-id');
        var id = $(this).closest('tr').find('#id-patrocinador').html();
        var documento = $(this).closest('tr').find('#identificacion-patrocinador').html();
        var nombre = $(this).closest('tr').find('#nombre-patrocinador').html();
        var tipoPersona = $(this).closest('tr').find('#tipoPersona-patrocinador').html();
        var direccion = $(this).closest('tr').find('#direccion-patrocinador').html();
        
        $.ajax({
            url: '/Patrocinador',
            data: JSON.stringify(obj),
            type: 'GET',
            dataType: 'html',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                /*var id = JSON.parse(response).arbitro.Id;
                var nombre = JSON.parse(response).arbitro.Nombre;*/
                $('#txtId').val(id);
                $('#txtNombre').val(nombre);
                $('#txtIdentificacion').val(documento);
                $('#txtTipoPersona').val(tipoPersona);
                $('#txtDireccion').val(direccion);
                $("#popup-editar").modal("show");
            }
        });
    });
});