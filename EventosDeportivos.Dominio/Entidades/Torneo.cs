using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosDeportivos.Dominio
{
    public class Torneo
    {
        public Torneo()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio. ")]
        [MaxLength(30, ErrorMessage = "No se pueden superar los {1} caracteres. ")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        public string Nombre { get; set; }

        public string Categoria { get; set; }

        [Required(ErrorMessage="El campo Fecha Inicial es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime? FechaInicio { get; set; }

        [Required(ErrorMessage="El campo Fecha Final es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime? FechaFin { get; set; }

        [Required(ErrorMessage="El campo {0} es obligtorio")]
        public string Tipo { get; set; }

        [Required(ErrorMessage="El campo {0} es obligtorio")]
        public int MunicipioId { get; set; }

        public List<TorneoEquipo> TorneoEquipo { get; set; }

        public List<Escenario> Escenarios { get; set; }

        public List<Arbitro> Arbitros { get; set; }
    }
}
