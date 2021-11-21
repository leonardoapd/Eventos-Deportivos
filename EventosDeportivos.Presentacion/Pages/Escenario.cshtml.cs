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
    public class EscenarioModel : PageModel
    {
        private static IRepositorioEscenario _repositorioEscenario; // = new RepositorioEscenario(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioTorneo _repositorioTorneo = new RepositorioTorneo(new EventosDeportivos.Persistencia.AppContext());
        public IEnumerable<Escenario> escenarios { get; set; }
        public IEnumerable<Torneo> torneos { get; set; }
        [BindProperty]
        public Escenario Escenario { get; set; }
        
        [BindProperty]
        public Torneo Torneo { get; set; }

        public List<string> nombreTorneos = new List<string>();

        public EscenarioModel(IRepositorioEscenario repositorioEscenario)
        {
            //Constructor
            _repositorioEscenario = repositorioEscenario;
        }
        public void OnGet(int? EscenarioId)
        {
            if (EscenarioId.HasValue)
            {
                Escenario = _repositorioEscenario.BuscarEscenario(EscenarioId.Value);
            }
            else
            {
                escenarios = _repositorioEscenario.ListarEscenarios();
                foreach (var escenario in escenarios)
                {
                    Torneo = _repositorioTorneo.BuscarTorneo(escenario.TorneoId);
                    nombreTorneos.Add(Torneo.Nombre);
                }
                torneos = _repositorioTorneo.ListarTorneos();
            }
        }

        public ActionResult OnPost()
        {

            if (Escenario.Id > 0)
            {
                _repositorioEscenario.ActualizarEscenario(Escenario);
                ViewData["Mensaje"] = "El escenario ha sido actualizado con exito.";
            }
            else
            {
                bool creado = _repositorioEscenario.CrearEscenario(Escenario);
                if (creado)
                {
                    Console.WriteLine("El escenario ha sido creado");
                    ViewData["Mensaje"] = "El escenario ha sido creado con exito.";
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                    ViewData["Mensaje"] = "El escenario no ha sido creado.";
                }
            }
            return RedirectToPage("Escenario");
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioEscenario.EliminarEscenario(Id);
            if(eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("Escenario");
        }

    
    }
}
