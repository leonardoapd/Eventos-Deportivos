$(function () {
    $("body").on('click', '.editar', function () {
        var obj = {};
        obj.Id = $(this).attr('data-id');
        var id = $(this).closest('tr').find('#id-deportista').html();
        var nombre = $(this).closest('tr').find('#nombre-deportista').html();
        var apellido = $(this).closest('tr').find('#apellido-deportista').html();
        var documento = $(this).closest('tr').find('#documento-deportista').html();
        var genero = $(this).closest('tr').find('#genero-deportista').html();
        var rh = $(this).closest('tr').find('#rh-deportista').html();
        var eps = $(this).closest('tr').find('#eps-deportista').html();
        var fechaNacimiento1 = $(this).closest('tr').find('#fechaNacimiento-deportista').html();
        var deporte = $(this).closest('tr').find('#deporte-deportista').html();
        var direccion = $(this).closest('tr').find('#direccion-deportista').html();
        var telefono = $(this).closest('tr').find('#telefono-deportista').html();
        var equipoId = $(this).closest('tr').find('#equipoId-deportista').html();
        var fechaNacimiento = moment(fechaNacimiento1, 'DD/MM/YYYY').format('YYYY-MM-DD');

        console.log(fechaNacimiento1)
        console.log(fechaNacimiento);

        

        $.ajax({
            url: '/Deportista',
            data: JSON.stringify(obj),
            type: 'GET',
            dataType: 'html',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                /*var id = JSON.parse(response).deportista.Id;
                var nombre = JSON.parse(response).deportista.Nombre;*/
                $('#txtId').val(id);
                $('#txtNombre').val(nombre);
                $('#txtApellido').val(apellido);
                $('#txtDocumento').val(documento);
                $('#txtDireccion').val(direccion);
                $('#txtTelefono').val(telefono);
                console.log(equipoId);
                console.log(deporte);
                console.log(genero);
                console.log(rh);
                console.log(eps);
                //$('#txtDeporte > option[value="'+ deporte +'"]').attr('selected', 'selected');
                //$('#txtGenero > option[value="'+ genero +'"]').attr('selected', 'selected');
                //$('#txtRh > option[value="'+ rh +'"]').attr('selected', 'selected');
                //$('#txtEPS > option[value="'+ eps +'"]').attr('selected', 'selected');
                //$('#txtEquipoId > option[value="'+ equipoId +'"]').attr('value', equipoId);
                $('#txtEquipoId').val(equipoId);
                $('#txtDeporte').val(deporte);
                $('#txtGenero').val(genero);
                $('#txtRh').val(rh);
                $('#txtEPS').val(eps);
                //$("#txtEquipoId").attr("value", equipoId); 
                $('#txtFechaNacimiento').val(fechaNacimiento);
                $("#popup-editar").modal("show");
            }
        });
    });
});