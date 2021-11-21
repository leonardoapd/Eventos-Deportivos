using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioEscenario
    {
        IEnumerable<Escenario> ListarEscenarios();
        bool CrearEscenario(Escenario escenario);
        bool ActualizarEscenario(Escenario escenario);
        bool EliminarEscenario(int idEscenario);
        Escenario BuscarEscenario(int idEscenario);
    }
}