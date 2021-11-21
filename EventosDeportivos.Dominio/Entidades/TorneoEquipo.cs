using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosDeportivos.Dominio
{
    public class TorneoEquipo
    {
        public TorneoEquipo()
        {
        }

        [Required(ErrorMessage = "El campo Equipo es obligatorio. ")]
        public int EquipoId { get; set; }

        [Required(ErrorMessage = "El campo Torneo es obligatorio. ")]
        public int TorneoId { get; set; }

        public Torneo Torneo { get; set; }

        public Equipo Equipo { get; set; }
    }
}
