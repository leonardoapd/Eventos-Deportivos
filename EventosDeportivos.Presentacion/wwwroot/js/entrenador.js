$(function () {
    $("body").on('click', '.editar', function () {
        var obj = {};
        obj.Id = $(this).attr('data-id');
        var id = $(this).closest('tr').find('#id-entrenador').html();
        var documento = $(this).closest('tr').find('#documento-entrenador').html();
        var nombre = $(this).closest('tr').find('#nombre-entrenador').html();
        var apellido = $(this).closest('tr').find('#apellido-entrenador').html();
        var direccion = $(this).closest('tr').find('#direccion-entrenador').html();
        var genero = $(this).closest('tr').find('#genero-entrenador').html();
        var deporte = $(this).closest('tr').find('#deporte-entrenador').html();
        var equipoId = $(this).closest('tr').find('#equipoId-entrenador').html();


        $.ajax({
            url: '/Entrenador',
            data: JSON.stringify(obj),
            type: 'GET',
            dataType: 'html',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                /*var id = JSON.parse(response).municipio.Id;
                var nombre = JSON.parse(response).municipio.Nombre;*/
                $('#txtId').val(id);
                $('#txtDocumento').val(documento);
                $('#txtNombre').val(nombre);
                $('#txtApellido').val(apellido);
                $('#txtDireccion').val(direccion);
                $('#txtGenero').val(genero);
                $('#txtEquipo').val(equipoId);
                $('#txtDeporte option[value='+ deporte +']').attr('selected',true);
                //$('#txtMunicipioId option[value='+ municipioId +']').attr('selected',true);
                $("#popup-editar").modal("show");
            }
        });
    });
});