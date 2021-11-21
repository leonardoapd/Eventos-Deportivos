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
    public class EntrenadorModel : PageModel
    {
        private static IRepositorioEntrenador _repositorioEntrenador;
        private static IRepositorioEquipo _repositorioEquipo = new RepositorioEquipo(new EventosDeportivos.Persistencia.AppContext());

        public IEnumerable<Entrenador> entrenadores { get; set; }

        public IEnumerable<Equipo> equipos { get; set; }

        [BindProperty]
        public Entrenador Entrenador { get; set; }

        [BindProperty]
        public Equipo Equipo { get; set; }

        public List<string> nombreEquipos = new List<string>();

        //Constructor
        public EntrenadorModel(IRepositorioEntrenador repositorioEntrenador)
        {
            _repositorioEntrenador = repositorioEntrenador;
        }

        public void OnGet()
        {
            entrenadores = _repositorioEntrenador.ListarEntrenadores();
            foreach (var entrenador in entrenadores)
            {
                Equipo = _repositorioEquipo.BuscarEquipo(entrenador.EquipoId);
                nombreEquipos.Add(Equipo.Nombre);
            }
            equipos = _repositorioEquipo.ListarEquipos();
        }

        public ActionResult OnPost()
        {
            ViewData["Mensaje"] = "";
            if(Entrenador == null && !ModelState.IsValid)
            {
                //Para hacer validaciones en el Post
                return Page();
            }
            else if (Entrenador.Id > 0)
            {
                _repositorioEntrenador.ActualizarEntrenador(Entrenador);
                ViewData["Mensaje"] = "El entrenador ha sido actualizado con exito.";
            }
            else
            {
                bool creado = _repositorioEntrenador.CrearEntrenador(Entrenador);
                if (creado)
                {
                    Console.WriteLine("El entrenador ha sido creado");
                    ViewData["Mensaje"] = "El entrenador ha sido creado con exito.";
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                    ViewData["Mensaje"] = "El entrenador no ha sido creado.";
                }
            }

            entrenadores = _repositorioEntrenador.ListarEntrenadores();
            foreach (var entrenador in entrenadores)
            {
                Equipo = _repositorioEquipo.BuscarEquipo(entrenador.EquipoId);
                nombreEquipos.Add(Equipo.Nombre);
            }
            equipos = _repositorioEquipo.ListarEquipos();
            return Page();
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioEntrenador.EliminarEntrenador(Id);
            if (eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("Entrenador");
        }
    }
}
