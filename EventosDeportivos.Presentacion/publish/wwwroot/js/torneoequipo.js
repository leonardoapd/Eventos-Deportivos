$(function () {
  $("body").on("click", ".editar", function () {
    var obj = {};
    obj.Id = $(this).attr("data-id");
    var id = $(this).closest("tr").find("#id-municipio").html();
    var nombre = $(this).closest("tr").find("#nombre-municipio").html();

    $.ajax({
      url: "/Municipio",
      data: JSON.stringify(obj),
      type: "GET",
      dataType: "html",
      contentType: "application/json; charset=utf-8",
      success: function (response) {
        /*var id = JSON.parse(response).municipio.Id;
                var nombre = JSON.parse(response).municipio.Nombre;*/
        $("#txtId").val(id);
        $("#txtNombre").val(nombre);
        $("#popup-editar").modal("show");
      },
    });
  });
});

$(function () {
  $("body").on("click", ".eliminar", function () {
    var obj = {};
    var idTorneo = $(this).closest("tr").find("#id-torneo").html();
    var idEquipo = $(this).closest("tr").find("#id-equipo").html();

    $.ajax({
      url: "/TorneoEquipo",
      data: JSON.stringify(obj),
      type: "GET",
      dataType: "html",
      contentType: "application/json; charset=utf-8",
      success: function (response) {
        $("#popup-eliminar").modal("show");
        $("#b-eliminar").attr(
          "href",
          "/TorneoEquipo?IdTorneo=" +
            idTorneo +
            "&IdEquipo=" +
            idEquipo +
            "&handler=Eliminar"
        );
      },
    });
  });
});

$(document).ready(function () {
  $("#popup-mensaje").modal("toggle");
});
