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
    public class ArbitroModel : PageModel
    {
        private static IRepositorioArbitro _repositorioArbitro; // = new RepositorioArbitro(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioTorneo _repositorioTorneo = new RepositorioTorneo(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioEscuelaArbitros _repositorioEscuelaArbitros = new RepositorioEscuelaArbitros(new EventosDeportivos.Persistencia.AppContext());
        public IEnumerable<Arbitro> arbitros { get; set; }
        public IEnumerable<Torneo> torneos { get; set; }
        public IEnumerable<EscuelaArbitro> escuelas { get; set; }


        [BindProperty]
        public Arbitro Arbitro { get; set; }

        [BindProperty]
        public Torneo Torneo { get; set; }

        [BindProperty]
        public EscuelaArbitro EscuelaArbitro { get; set; }

        public List<string> nombreTorneos = new List<string>();
        public List<string> nombreEscuelas = new List<string>();

        public ArbitroModel(IRepositorioArbitro repositorioArbitro)
        {
            //Constructor
            _repositorioArbitro = repositorioArbitro;
        }

        public void OnGet(int? ArbitroId)
        {
            if (ArbitroId.HasValue)
            {
                Arbitro = _repositorioArbitro.BuscarArbitro(ArbitroId.Value);
            }
            else
            {
                arbitros = _repositorioArbitro.ListarArbitros();
                foreach (var arbitro in arbitros)
                {
                    Torneo = _repositorioTorneo.BuscarTorneo(arbitro.TorneoId);
                    EscuelaArbitro = _repositorioEscuelaArbitros.BuscarEscuela(arbitro.EscuelaArbitroId);
                    nombreEscuelas.Add(EscuelaArbitro.Nombre);
                    nombreTorneos.Add(Torneo.Nombre);

                }

                escuelas = _repositorioEscuelaArbitros.ListarEscuelas();
                torneos = _repositorioTorneo.ListarTorneos();
            }
        }

        public ActionResult OnPost()
        {
            ViewData["Mensaje"] = "";
            if (Arbitro == null && !ModelState.IsValid)
            {
                //Para hacer validaciones en el Post
                return Page();
            }
            if (Arbitro.Id > 0)
            {
                _repositorioArbitro.ActualizarArbitro(Arbitro);
                ViewData["Mensaje"] = "El arbitro ha sido actualizado con exito.";
            }
            else
            {
                bool creado = _repositorioArbitro.CrearArbitro(Arbitro);
                if (creado)
                {
                    Console.WriteLine("El arbitro ha sido creado");
                    ViewData["Mensaje"] = "El arbitro ha sido creado con exito.";
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                    ViewData["Mensaje"] = "El arbitro no ha sido creado.";
                }
            }

            arbitros = _repositorioArbitro.ListarArbitros();
            foreach (var arbitro in arbitros)
            {
                Torneo = _repositorioTorneo.BuscarTorneo(arbitro.TorneoId);
                EscuelaArbitro = _repositorioEscuelaArbitros.BuscarEscuela(arbitro.EscuelaArbitroId);
                nombreEscuelas.Add(EscuelaArbitro.Nombre);
                nombreTorneos.Add(Torneo.Nombre);

            }

            escuelas = _repositorioEscuelaArbitros.ListarEscuelas();
            torneos = _repositorioTorneo.ListarTorneos();

            return Page();
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioArbitro.EliminarArbitro(Id);
            if (eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("Arbitro");
        }


    }
}