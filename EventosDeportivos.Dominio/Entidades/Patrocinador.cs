using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosDeportivos.Dominio
{
    public class Patrocinador
    {
        public Patrocinador()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage="El campo Documento es obligatorio.")]
        [RegularExpression(@"[0-9]{7,10}" , ErrorMessage = "El campo {0} debe contener entre 7 y 10 numeros.")]             
        public string Identificacion { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage="El campo Tipo de Persona es obligatorio.")]
        public string TipoPersona { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio.")]
        public string Direccion { get; set; }

        public List<Equipo> Equipos { get; set; }
    }
}
