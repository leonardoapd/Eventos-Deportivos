using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventosDeportivos.Dominio;
using EventosDeportivos.Persistencia;

namespace EventosDeportivos.Presentacion.Pages
{
    public class EquipoModel : PageModel
    {
        private static IRepositorioEquipo _repositorioEquipo; // = new RepositorioEquipo(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioPatrocinador _repositorioPatrocinador = new RepositorioPatrocinador(new EventosDeportivos.Persistencia.AppContext());

        public IEnumerable<Equipo> equipos { get; set; }

        public IEnumerable<Patrocinador> patrocinadores;

        [BindProperty]
        public Equipo Equipo { get; set; }

        [BindProperty]
        public Patrocinador Patrocinador { get; set; }

        public List<string> nombrePatrocinadores = new List<string>();

        public EquipoModel(IRepositorioEquipo repositorioEquipo)
        {
            //Constructor
            _repositorioEquipo = repositorioEquipo;
        }
        public void OnGet(int? EquipoId)
        {
            if (EquipoId.HasValue)
            {
                Equipo = _repositorioEquipo.BuscarEquipo(EquipoId.Value);
            }
            else
            {
                equipos = _repositorioEquipo.ListarEquipos();
                foreach (var equipo in equipos)
                {
                    Patrocinador = _repositorioPatrocinador.BuscarPatrocinador(equipo.PatrocinadorId);
                    nombrePatrocinadores.Add(Patrocinador.Nombre);
                }
                patrocinadores = _repositorioPatrocinador.ListarPatrocinadores();

            }
        }

        public ActionResult OnPost()
        {
            ViewData["Mensaje"] = "";
            if (Equipo == null && !ModelState.IsValid)
            {
                //Para hacer validaciones en el Post
                Console.WriteLine("Se metio aca");
                return Page();
            }
            else if (Equipo.Id > 0)
            {
                _repositorioEquipo.ActualizarEquipo(Equipo);
                ViewData["Mensaje"] = "El equipo ha sido actualizado con exito.";
            }
            else
            {
                bool creado = _repositorioEquipo.CrearEquipo(Equipo);
                if (creado)
                {
                    Console.WriteLine("El equipo ha sido creado");
                    ViewData["Mensaje"] = "El equipo ha sido creado con exito.";
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                    ViewData["Mensaje"] = "El equipo no ha sido creado.";
                }
            }

            equipos = _repositorioEquipo.ListarEquipos();
            foreach (var equipo in equipos)
            {
                Patrocinador = _repositorioPatrocinador.BuscarPatrocinador(equipo.PatrocinadorId);
                nombrePatrocinadores.Add(Patrocinador.Nombre);
            }
            patrocinadores = _repositorioPatrocinador.ListarPatrocinadores();

            return Page();
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioEquipo.EliminarEquipo(Id);
            if (eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("Equipo");
        }

    }
}