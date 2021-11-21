$(function () {
    $("body").on('click', '.editar', function () {
        var obj = {};
        obj.Id = $(this).attr('data-id');
        var id = $(this).closest('tr').find('#id-torneo').html();
        var nombre = $(this).closest('tr').find('#nombre-torneo').html();
        var categoria = $(this).closest('tr').find('#categoria-torneo').html();
        var tipo = $(this).closest('tr').find('#tipo-torneo').html();
        var fechaInicio1 = $(this).closest('tr').find('#fechaInicio-torneo').html();
        var fechaFin1 = $(this).closest('tr').find('#fechaFin-torneo').html();
        var municipioId = $(this).closest('tr').find('#municipioId-torneo').html();
        var fechaInicio = moment(fechaInicio1, 'DD/MM/YYYY').format('YYYY-MM-DD');
        var fechaFin = moment(fechaFin1, 'DD/MM/YYYY').format('YYYY-MM-DD');

        console.log(id)
        console.log(municipioId);

        $.ajax({
            url: '/Torneo',
            data: JSON.stringify(obj),
            type: 'GET',
            dataType: 'html',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                /*var id = JSON.parse(response).municipio.Id;
                var nombre = JSON.parse(response).municipio.Nombre;*/
                $('#txtId').val(id);
                $('#txtNombre').val(nombre);
                $('#txtCategoria').val(categoria);
                $('#txtTipo').val(tipo);
                $('#txtFechaInicio').val(fechaInicio);
                $('#txtFechaFin').val(fechaFin);
                $('#txtMunicipioId').val(municipioId);
                //$('#txtMunicipioId option[value='+ municipioId +']').attr('selected',true);
                $("#popup-editar").modal("show");
            }
        });
    });
});