using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosDeportivos.Dominio
{
    public class Entrenador
    {
        public Entrenador()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        [RegularExpression(@"[0-9]{7,10}" , ErrorMessage = "El campo {0} debe contener entre 7 y 10 numeros.")] 
        public string Documento { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        public string Apellido { get; set; }

        public string Direccion { get; set; }

        public string Genero { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        public string Deporte { get; set; }

        [Required(ErrorMessage="El campo Equipo es obligatorio.")]
        public int EquipoId { get; set; }
    }
}
