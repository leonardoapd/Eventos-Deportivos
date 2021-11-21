using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventosDeportivos.Dominio
{
    public class CanchasEspacio
    {
        public CanchasEspacio()
        {
        }

        public int Id { get; set; }

        public string Deporte { get; set; }

        public string Estado { get; set; }

        public string Medidas { get; set; }

        public int CapacidadEspectadores { get; set; }

        public int EscenarioId { get; set; }
    }
}
