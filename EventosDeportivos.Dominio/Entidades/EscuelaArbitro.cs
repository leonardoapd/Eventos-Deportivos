using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventosDeportivos.Dominio
{
    public class EscuelaArbitro
    {
        public EscuelaArbitro()
        {
        }

        public int Id { get; set; }

        public string NIT { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string Resolucion { get; set; }

        public List<Arbitro> Arbitros { get; set; }
    }
}
