$(function () {
  $("body").on("click", ".editar", function () {
    var obj = {};
    obj.Id = $(this).attr("data-id");
    var id = $(this).closest("tr").find("#id-escenario").html();
    var nombre = $(this).closest("tr").find("#nombre-escenario").html();
    var telefono = $(this).closest("tr").find("#telefono-escenario").html();
    var horario = $(this).closest("tr").find("#horario-escenario").html();
    var direccion = $(this).closest("tr").find("#direccion-escenario").html();
    var torneoId = $(this).closest("tr").find("#torneoId-escenario").html();

    $.ajax({
      url: "/Escenario",
      data: JSON.stringify(obj),
      type: "GET",
      dataType: "html",
      contentType: "application/json; charset=utf-8",
      success: function (response) {
        /*var id = JSON.parse(response).escenario.Id;
                var nombre = JSON.parse(response).escenario.Nombre;*/
        $("#txtId").val(id);
        $("#txtNombre").val(nombre);
        $("#txtTelefono").val(telefono);
        $("#txtDireccion").val(direccion);
        $("#txtHorario").val(horario);
        $("#txtTorneoId").val(torneoId);
        $("#popup-editar").modal("show");
      },
    });
  });
});
