using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosDeportivos.Dominio
{
    public class Arbitro
    {
        public Arbitro()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage="El campo Documento es obligatorio.")]
        [RegularExpression(@"[0-9]{7,10}" , ErrorMessage = "El campo {0} debe contener entre 7 y 10 numeros.")] 
        public string Documento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio. ")]
        [MaxLength(30, ErrorMessage = "No se pueden superar los {1} caracteres. ")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio. ")]
        [MaxLength(30, ErrorMessage = "No se pueden superar los {1} caracteres. ")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        public string Apellido { get; set; }

        public string Genero { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [MinLength(10, ErrorMessage = "El campo {0} debe tener {1} caracteres.")]
        [MaxLength(10, ErrorMessage = "No se pueden superar los {1} caracteres. ")]  
        [RegularExpression(@"[0-9]{10}" , ErrorMessage = "El campo {0} solo debe contener (10) numeros.")]
        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string Deporte { get; set; }

        [Required(ErrorMessage="El campo Torneo es obligatorio.")]
        public int TorneoId { get; set; }

        [Required(ErrorMessage="El campo Escuela es obligatorio.")]
        public int EscuelaArbitroId { get; set; }
    }
}
