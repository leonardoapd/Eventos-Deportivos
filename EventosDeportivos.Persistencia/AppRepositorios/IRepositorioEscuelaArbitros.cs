using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioEscuelaArbitros
    {
        IEnumerable<EscuelaArbitro> ListarEscuelas();
        bool CrearEscuela(EscuelaArbitro escuelaArbitro);
        bool ActualizarEscuela(EscuelaArbitro escuelaArbitro);
        bool EliminarEscuela(int idEscuelaArbitro);
        EscuelaArbitro BuscarEscuela(int idEscuelaArbitro);
    }
}
