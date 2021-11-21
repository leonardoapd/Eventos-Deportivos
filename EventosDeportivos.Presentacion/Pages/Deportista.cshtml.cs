using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EventosDeportivos.Dominio;
using EventosDeportivos.Persistencia;

namespace EventosDeportivos.Presentacion.Pages
{
    public class DeportistaModel : PageModel
    {
        private static IRepositorioDeportista _repositorioDeportista; // = new RepositorioDeportista(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioEquipo _repositorioEquipo = new RepositorioEquipo(new EventosDeportivos.Persistencia.AppContext());
        public IEnumerable<Deportista> deportistas;
        public IEnumerable<Equipo> equipos;

        [BindProperty]
        public Deportista Deportista { get; set; }

        [BindProperty]
        public Equipo Equipo { get; set; }

        public List<string> nombreEquipos = new List<string>();

        public DeportistaModel(IRepositorioDeportista repositorioDeportista)
        {
            //Constructor
            _repositorioDeportista = repositorioDeportista;
        }
        public void OnGet(int? DeportistaId)
        {
            if (DeportistaId.HasValue)
            {
                Deportista = _repositorioDeportista.BuscarDeportista(DeportistaId.Value);
            }
            else
            {
                deportistas = _repositorioDeportista.ListarDeportistas();
                foreach (var deportista in deportistas)
                {
                    Equipo = _repositorioEquipo.BuscarEquipo(deportista.EquipoId);
                    nombreEquipos.Add(Equipo.Nombre);
                }
                equipos = _repositorioEquipo.ListarEquipos();
            }
        }

        public ActionResult OnPost()
        {

            if (Deportista == null && !ModelState.IsValid)
            {
                //Para hacer validaciones en el Post
                Console.WriteLine("Se metio aca");
                return Page();
            }
            if (Deportista.Id > 0)
            {
                _repositorioDeportista.ActualizarDeportista(Deportista);
                ViewData["Mensaje"] = "El deportista ha sido actualizado con exito.";
            }
            else
            {
                bool creado = _repositorioDeportista.CrearDeportista(Deportista);
                if (creado)
                {
                    Console.WriteLine("El deportista ha sido creado");
                    ViewData["Mensaje"] = "El deportista ha sido creado con exito.";
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                    ViewData["Mensaje"] = "El deportista no ha sido creado.";
                }
            }

            deportistas = _repositorioDeportista.ListarDeportistas();
            foreach (var deportista in deportistas)
            {
                Equipo = _repositorioEquipo.BuscarEquipo(deportista.EquipoId);
                nombreEquipos.Add(Equipo.Nombre);
            }
            equipos = _repositorioEquipo.ListarEquipos();
            return Page();
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioDeportista.EliminarDeportista(Id);
            if (eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("Deportista");
        }

    }
}