using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventosDeportivos.Dominio
{
    public class Escenario
    {
        public Escenario()
        {
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Horario { get; set; }

        public int TorneoId { get; set; }

        public List<CanchasEspacio> Canchas { get; set; }
    }
}
