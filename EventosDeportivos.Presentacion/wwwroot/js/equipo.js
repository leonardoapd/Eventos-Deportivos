$(function () {
    $("body").on('click', '.editar', function () {
      var obj = {};
      obj.Id = $(this).attr('data-id');
      var id = $(this).closest('tr').find('#id-equipo').html();
      var nombre = $(this).closest('tr').find('#nombre-equipo').html();
      var cantidadDeportistas = $(this).closest('tr').find('#cantidadDeportistas-equipo').html();
      var deporte = $(this).closest('tr').find('#deporte-equipo').html();
      var patrocinadorId = $(this).closest('tr').find('#patrocinadorId-equipo').html();


      $.ajax({
        url: '/Equipo',
        data: JSON.stringify(obj),
        type: 'GET',
        dataType: 'html',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
          /*var id = JSON.parse(response).equipo.Id;
          var nombre = JSON.parse(response).equipo.Nombre;*/
          $('#txtId').val(id);
          $('#txtNombre').val(nombre);
          $('#txtCantidad').val(cantidadDeportistas);
          $('#txtDeporte').val(deporte);
          $('#txtPatrocinadorId ').val(patrocinadorId);
          //$('#txtPatrocinadorId option[value='+ patrocinadorId +']').attr('selected',true);
          $("#popup-editar").modal("show");
        }
      });
    });
  });