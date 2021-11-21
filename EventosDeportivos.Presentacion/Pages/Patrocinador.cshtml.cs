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
    public class PatrocinadorModel : PageModel
    {

         //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioPatrocinador _repositorioPatrocinador;
        // modelo u objeto para transportar hacia MIndex.cshtml
        public IEnumerable<Patrocinador> patrocinadores {get;set;}

        [BindProperty]
        public Patrocinador Patrocinador { get; set; }

        public PatrocinadorModel(IRepositorioPatrocinador repositorioPatrocinador)
        {
            //Constructor
            _repositorioPatrocinador = repositorioPatrocinador;
        }


        public void OnGet()
        {
            patrocinadores = _repositorioPatrocinador.ListarPatrocinadores();
        }

        public ActionResult OnPost()
        {
            ViewData["Mensaje"] = "";
            if (!ModelState.IsValid)
            {
                //Para hacer validaciones en el Post
                Console.WriteLine("Se metio aca");
                return Page();
            }
            else if (Patrocinador.Id > 0)
            {
                _repositorioPatrocinador.ActualizarPatrocinador(Patrocinador);
                ViewData["Mensaje"] = "El patrocinador ha sido actualizado con exito.";
            }
            else
            {
                bool creado = _repositorioPatrocinador.CrearPatrocinador(Patrocinador);
                if (creado)
                {
                    Console.WriteLine("El patrocinador ha sido creado");
                    ViewData["Mensaje"] = "El patrocinador ha sido creado con exito.";
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                    ViewData["Mensaje"] = "El patrocinador no ha sido creado.";
                }
            }

            patrocinadores = _repositorioPatrocinador.ListarPatrocinadores();

            return Page();
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioPatrocinador.EliminarPatrocinador(Id);
            if (eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("Patrocinador");
        }
    }
}
