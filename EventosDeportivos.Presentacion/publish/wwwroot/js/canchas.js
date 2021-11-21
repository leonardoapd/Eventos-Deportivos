$(function () {
    $("body").on('click', '.editar', function () {
        var obj = {};
        obj.Id = $(this).attr('data-id');
        var id = $(this).closest('tr').find('#id-canchasEspacio').html();
        var deporte = $(this).closest('tr').find('#deporte-canchasEspacio').html();
        var estado = $(this).closest('tr').find('#estado-canchasEspacio').html();
        var medidas = $(this).closest('tr').find('#medidas-canchasEspacio').html();
        var capacidad = $(this).closest('tr').find('#capacidad-canchasEspacio').html();
        var escenarioId = $(this).closest('tr').find('#escenarioId-canchasEspacio').html();

        $.ajax({
            url: '/CanchasEspacio',
            data: JSON.stringify(obj),
            type: 'GET',
            dataType: 'html',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                /*var id = JSON.parse(response).canchasEspacio.Id;
                var nombre = JSON.parse(response).canchasEspacio.Nombre;*/
                $('#txtId').val(id);
                $('#txtDeporte').val(deporte);
                $('#txtMedidas').val(medidas);
                $('#txtCapacidad').val(capacidad);
                $('#txtEstado').val(estado);
                $('#txtEscenarioId').val(escenarioId);
                $("#popup-editar").modal("show");
            }
        });
    });
});