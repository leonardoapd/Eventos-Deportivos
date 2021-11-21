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

/* $( document ).ready(function() {
      $('#popup-mensaje').modal('toggle');
  }); */
