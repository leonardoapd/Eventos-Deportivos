using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosDeportivos.Dominio
{
    public class Municipio
    {
        public Municipio()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio. ")]
        [MaxLength(30, ErrorMessage = "No se pueden superar los {1} caracteres. ")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        public string Nombre { get; set; }

        public List<Torneo> Torneos { get; set; }
    }
}
