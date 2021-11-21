using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioMunicipio
    {
        IEnumerable<Municipio> ListarMunicipios();
        bool CrearMunicipio(Municipio municipio);
        bool ActualizarMunicipio(Municipio municipio);
        bool EliminarMunicipio(int idMunicipio);
        Municipio BuscarMunicipio(int idMunicipio);
    }
}