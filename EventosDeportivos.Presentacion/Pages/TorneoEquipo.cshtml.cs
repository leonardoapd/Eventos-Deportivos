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
    public class TorneoEquipoModel : PageModel
    {
        private static IRepositorioTorneoEquipo _repositorioTorneoEquipo;
        private static IRepositorioTorneo _repositorioTorneo = new RepositorioTorneo(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioEquipo _repositorioEquipo = new RepositorioEquipo(new EventosDeportivos.Persistencia.AppContext());


        public IEnumerable<TorneoEquipo> torneoEquipos { get; set; }
        public IEnumerable<Torneo> torneos { get; set; }
        public IEnumerable<Equipo> equipos { get; set; }

        [BindProperty]
        public TorneoEquipo TorneoEquipo { get; set; }

        [BindProperty]
        public Torneo Torneo { get; set; }

        [BindProperty]
        public Equipo Equipo { get; set; }

        public List<string> nombreEquipos = new List<string>();
        public List<string> nombreTorneos = new List<string>();

        public TorneoEquipoModel(IRepositorioTorneoEquipo repositorioTorneoEquipo)
        {
            //Constructor
            _repositorioTorneoEquipo = repositorioTorneoEquipo;
        }

        public void OnGet()
        {
            torneoEquipos = _repositorioTorneoEquipo.ListarInscritos();
            foreach (var torneoequipo in torneoEquipos)
            {
                Equipo = _repositorioEquipo.BuscarEquipo(torneoequipo.EquipoId);
                Torneo = _repositorioTorneo.BuscarTorneo(torneoequipo.TorneoId);
                nombreEquipos.Add(Equipo.Nombre);
                nombreTorneos.Add(Torneo.Nombre);
            }
            equipos = _repositorioEquipo.ListarEquipos();
            torneos = _repositorioTorneo.ListarTorneos();
        }

        public ActionResult OnPost()
        {

            if (TorneoEquipo == null && !ModelState.IsValid)
            {
                //Para hacer validaciones en el Post
                Console.WriteLine("Se metio aca");
                return Page();
            }
            // else if (Deportista.Id > 0)
            // {
            //      _repositorioDeportista.ActualizarDeportista(Deportista);
            // }
            else
            {

                bool creado = _repositorioTorneoEquipo.InscribirEquipoATorneo(TorneoEquipo.EquipoId, TorneoEquipo.TorneoId);
                if (creado)
                {
                    Console.WriteLine("El equipo ha sido inscrito");
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la inscripcion");
                }
            }

            torneoEquipos = _repositorioTorneoEquipo.ListarInscritos();
            foreach (var torneoequipo in torneoEquipos)
            {
                Equipo = _repositorioEquipo.BuscarEquipo(torneoequipo.EquipoId);
                Torneo = _repositorioTorneo.BuscarTorneo(torneoequipo.TorneoId);
                nombreEquipos.Add(Equipo.Nombre);
                nombreTorneos.Add(Torneo.Nombre);
            }
            equipos = _repositorioEquipo.ListarEquipos();
            torneos = _repositorioTorneo.ListarTorneos();

            return Page();
        }

        public IActionResult OnGetEliminar(int IdTorneo, int IdEquipo)
        {
            Console.WriteLine("El id de equipo es: " + IdEquipo + " y el id del torneo es: " + IdTorneo);
            bool eliminado = _repositorioTorneoEquipo.EliminarInscripcion(IdEquipo, IdTorneo);
            if (eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("TorneoEquipo");
        }
    }
}

