using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosDeportivos.Dominio
{
    public class Deportista
    {
        public Deportista()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Description = "Documento de Identidad")]
        [MaxLength(10, ErrorMessage = "No se pueden superar los {1} caracteres. ")]
        [MinLength(7, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        [RegularExpression(@"[0-9]{7,10}" , ErrorMessage = "El campo {0} debe contener entre 7 y 10 numeros.")]        
        public string Documento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "No se pueden superar los {1} caracteres. ")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "No se pueden superar los {1} caracteres. ")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        public string Apellido { get; set; }

        public string Genero { get; set; }

        public string Rh { get; set; }

        public string EPS { get; set; }

        [Required(ErrorMessage="El campo Nacimiento es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public string Deporte { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage="El campo Telefono es obligatorio.")]
        [MinLength(10, ErrorMessage = "El campo {0} debe tener {1} caracteres.")]
        [MaxLength(10, ErrorMessage = "No se pueden superar los {1} caracteres. ")]  
        [RegularExpression(@"[0-9]{10}" , ErrorMessage = "El campo Telefono solo debe contener (10) numeros.")]
        public string NumeroEmergencia { get; set; }

        public int EquipoId { get; set; }
    }
}
