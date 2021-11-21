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
    public class CanchasEspacioModel : PageModel
    {
        private static IRepositorioCanchasEspacios _repositorioCanchasEspacio; // = new RepositorioCanchasEspacios(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioEscenario _repositorioEscenario = new RepositorioEscenario(new EventosDeportivos.Persistencia.AppContext());
        public IEnumerable<CanchasEspacio> canchasEspacios { get; set; }
        public IEnumerable<Escenario> escenarios { get; set; }

        [BindProperty]
        public CanchasEspacio CanchasEspacio { get; set; }

        [BindProperty]
        public Escenario Escenario { get; set; }

        public List<string> nombreEscenarios = new List<string>();

        public CanchasEspacioModel(IRepositorioCanchasEspacios repositorioCanchasEspacios)
        {
            //Constructor
            _repositorioCanchasEspacio = repositorioCanchasEspacios;
        }
        public void OnGet(int? CanchasEspacioId)
        {
            if (CanchasEspacioId.HasValue)
            {
                CanchasEspacio = _repositorioCanchasEspacio.BuscarCancha(CanchasEspacioId.Value);
            }
            else
            {
                canchasEspacios = _repositorioCanchasEspacio.ListarCanchas();
                foreach (var cancha in canchasEspacios)
                {
                    Escenario = _repositorioEscenario.BuscarEscenario(cancha.EscenarioId);
                    nombreEscenarios.Add(Escenario.Nombre);
                }

                escenarios = _repositorioEscenario.ListarEscenarios();
            }
        }

        public ActionResult OnPost()
        {

            if (CanchasEspacio.Id > 0)
            {
                _repositorioCanchasEspacio.ActualizarCancha(CanchasEspacio);
                ViewData["Mensaje"] = "La cancha ha sido actualizada con exito.";
            }
            else
            {
                bool creado = _repositorioCanchasEspacio.CrearCancha(CanchasEspacio);
                if (creado)
                {
                    Console.WriteLine("La cancha ha sido creada");
                    ViewData["Mensaje"] = "La cancha ha sido creada con exito.";
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                    ViewData["Mensaje"] = "La cancha no ha sido creada.";
                }
            }
            return RedirectToPage("CanchasEspacio");
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioCanchasEspacio.EliminarCancha(Id);
            if(eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("CanchasEspacio");
        }

    }
}
