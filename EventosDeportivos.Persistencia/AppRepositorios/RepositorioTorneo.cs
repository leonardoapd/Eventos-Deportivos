using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioTorneo : IRepositorioTorneo
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioTorneo(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        //Se implementan los metodos de la interfaz IRepositorioTorneo
        bool IRepositorioTorneo.CrearTorneo(Torneo torneo)
        {
            bool creado = false;
            try
            {
                _dataBaseContext.Torneos.Add(torneo);
                _dataBaseContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }
            return creado;
        }

        bool IRepositorioTorneo.ActualizarTorneo(Torneo torneo)
        {
            bool actualizado = false;
            var torneo_a_actualizar = _dataBaseContext.Torneos.Find(torneo.Id);

            if (torneo_a_actualizar != null)
            {
                try
                {
                    torneo_a_actualizar.Nombre = torneo.Nombre;
                    torneo_a_actualizar.Categoria = torneo.Categoria;
                    torneo_a_actualizar.FechaInicio = torneo.FechaInicio;
                    torneo_a_actualizar.FechaFin = torneo.FechaFin;
                    torneo_a_actualizar.Tipo = torneo.Tipo;
                    torneo_a_actualizar.MunicipioId = torneo.MunicipioId;
                    _dataBaseContext.SaveChanges();
                    actualizado = true;
                }
                catch (System.Exception)
                {
                    actualizado = false;
                }
            }
            return actualizado;
        }

        bool IRepositorioTorneo.EliminarTorneo(int idTorneo)
        {
            bool eliminado = false;
            //Se busca el torneo que se va a eliminar
            var torneo = _dataBaseContext.Torneos.Find(idTorneo);

            if (torneo != null)
            {
                try
                {
                    _dataBaseContext.Torneos.Remove(torneo);
                    _dataBaseContext.SaveChanges();
                    eliminado = true;
                }
                catch (System.Exception)
                { 
                    eliminado = false;
                }
            }

            return eliminado;
        }

        Torneo IRepositorioTorneo.BuscarTorneo(int idTorneo)
        {
            //Se busca el torneo por su Id
            Torneo torneo = _dataBaseContext.Torneos.Find(idTorneo);
            return torneo;
        }

        IEnumerable<Torneo> IRepositorioTorneo.ListarTorneos()
        {
            //Se retorna un listado de torneos utilizando el objeto _dataBaseContext
            return _dataBaseContext.Torneos;
        }
    }
}