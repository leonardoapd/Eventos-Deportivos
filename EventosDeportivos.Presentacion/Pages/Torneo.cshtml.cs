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
    public class TorneoModel : PageModel
    {
        private static IRepositorioTorneo _repositorioTorneo;
        private static IRepositorioMunicipio _repositorioMunicipio = new RepositorioMunicipio(new EventosDeportivos.Persistencia.AppContext());
        public IEnumerable<Torneo> torneos;
        public IEnumerable<Municipio> municipios;

        [BindProperty]
        public Torneo Torneo { get; set; }

        [BindProperty]
        public Municipio Municipio { get; set; }

        public List<string> nombreMunicipios = new List<string>();

        public TorneoModel(IRepositorioTorneo repositorioTorneo)
        {
            _repositorioTorneo = repositorioTorneo;
        }
        public void OnGet()
        {
            torneos = _repositorioTorneo.ListarTorneos();
            foreach (var torneo in torneos)
            {
                Municipio = _repositorioMunicipio.BuscarMunicipio(torneo.MunicipioId);
                nombreMunicipios.Add(Municipio.Nombre);
            }
            municipios = _repositorioMunicipio.ListarMunicipios();
        }

        public ActionResult OnPost()
        {

            ViewData["Mensaje"] = "";
            if (Torneo == null && !ModelState.IsValid)
            {
                Console.WriteLine("Se metio aca");
                return Page();
            }
            else if (Torneo.Id > 0)
            {
                _repositorioTorneo.ActualizarTorneo(Torneo);
                Console.WriteLine("Torneo actualizado con exito.");
                ViewData["Mensaje"] = "El torneo ha sido actualizado con exito.";
            }
            else
            {
                bool creado = _repositorioTorneo.CrearTorneo(Torneo);
                if (creado)
                {
                    Console.WriteLine("El torneo ha sido creado");
                    ViewData["Mensaje"] = "El torneo ha sido creado con exito.";
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                    ViewData["Mensaje"] = "El torneo no ha sido creado.";
                }
            }

            torneos = _repositorioTorneo.ListarTorneos();
            foreach (var torneo in torneos)
            {
                Municipio = _repositorioMunicipio.BuscarMunicipio(torneo.MunicipioId);
                nombreMunicipios.Add(Municipio.Nombre);
            }
            municipios = _repositorioMunicipio.ListarMunicipios();

            return Page();
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioTorneo.EliminarTorneo(Id);
            if (eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("Torneo");
        }

    }
}
