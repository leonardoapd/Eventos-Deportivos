using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosDeportivos.Dominio
{
    public class Equipo
    {
        public Equipo()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "No se pueden superar los {1} caracteres. ")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Cantidad de Deportistas es obligatorio.")]
        [Display(Description = "Cantidad de deportistas")]
        [RegularExpression(@"[0-9]{1,3}" , ErrorMessage = "El campo debe contener solo numeros.")]
        public int CantidadDeportistas { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        public string Deporte { get; set; }

        public int PatrocinadorId { get; set; }

        public List<TorneoEquipo> TorneoEquipo { get; set; }

        public List<Deportista> Deportistas { get; set; }

        public Entrenador Entrenador { get; set; }
    }
}
