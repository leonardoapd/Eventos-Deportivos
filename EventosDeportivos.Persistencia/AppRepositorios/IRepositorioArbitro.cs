using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioArbitro
    {
        IEnumerable<Arbitro> ListarArbitros();
        bool CrearArbitro(Arbitro arbitro);
        bool ActualizarArbitro(Arbitro arbitro);
        bool EliminarArbitro(int idArbitro);
        Arbitro BuscarArbitro(int idArbitro);
    }
}