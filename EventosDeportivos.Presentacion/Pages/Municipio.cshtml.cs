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
    public class MunicipioModel : PageModel
    {
        private static IRepositorioMunicipio _repositorioMunicipio; // = new RepositorioMunicipio(new EventosDeportivos.Persistencia.AppContext());

        public IEnumerable<Municipio> municipios { get; set; }
        [BindProperty]
        public Municipio Municipio { get; set; }

        public MunicipioModel(IRepositorioMunicipio repositorioMunicipio)
        {
            //Constructor
            _repositorioMunicipio = repositorioMunicipio;
        }
        public void OnGet(int? MunicipioId)
        {
            if (MunicipioId.HasValue)
            {
                Municipio = _repositorioMunicipio.BuscarMunicipio(MunicipioId.Value);
            }
            else
            {
                municipios = _repositorioMunicipio.ListarMunicipios();
                
            }
        }

        public ActionResult OnPost()
        {
            ViewData["Mensaje"] = "";
            if(!ModelState.IsValid){
                //Para hacer validaciones en el Post
                Console.WriteLine("Se metio aca");
                return Page();
            }
            else if (Municipio.Id > 0)
            {
                _repositorioMunicipio.ActualizarMunicipio(Municipio);
                Console.WriteLine("El municipio ha sido actualizado");
                municipios = _repositorioMunicipio.ListarMunicipios();
                ViewData["Mensaje"] = "El municipio actualizado con exito.";
                
            }
            else
            {
                bool creado = _repositorioMunicipio.CrearMunicipio(new Municipio{
                    Nombre = Municipio.Nombre
                });
                if (creado)
                {
                    Console.WriteLine("El municipio ha sido creado");
                    municipios = _repositorioMunicipio.ListarMunicipios();
                    ViewData["Mensaje"] = "El municipio creado con exito.";
                    
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                    municipios = _repositorioMunicipio.ListarMunicipios();
                    ViewData["Mensaje"] = "Municipio no ha sido creado.";
                    
                }
            }
            municipios = _repositorioMunicipio.ListarMunicipios();
            return Page();
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioMunicipio.EliminarMunicipio(Id);
            if(eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("Municipio");
        }

       
    }
}
