using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioCanchasEspacios
    {
        IEnumerable<CanchasEspacio> ListarCanchas();
        bool CrearCancha(CanchasEspacio cancha);
        bool ActualizarCancha(CanchasEspacio cancha);
        bool EliminarCancha(int idCancha);
        CanchasEspacio BuscarCancha(int idCancha);
    }
}