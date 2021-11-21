using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioCanchasEspacios : IRepositorioCanchasEspacios
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioCanchasEspacios(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        //Implementado los metodos de la interfaz IRepositorioCanchasEspacios
        bool IRepositorioCanchasEspacios.CrearCancha(CanchasEspacio cancha)
        {
            bool creado = false;
            try
            {
                _dataBaseContext.CanchasEspacios.Add(cancha);
                //Es necesario guardar los cambios cada vez que se modifica informacion en la base de datos
                _dataBaseContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }
            return creado;
        }

        bool IRepositorioCanchasEspacios.ActualizarCancha(CanchasEspacio cancha)
        {
            bool actualizado = false;
            //Se busca la cancha por su Id utilizando la propiedad de la entidad
            var cancha_a_actualizar = _dataBaseContext.CanchasEspacios.Find(cancha.Id);

            if (cancha_a_actualizar != null)
            {
                try
                {
                    cancha_a_actualizar.Deporte = cancha.Deporte;
                    cancha_a_actualizar.Estado = cancha.Estado;
                    cancha_a_actualizar.Medidas = cancha.Medidas;
                    cancha_a_actualizar.CapacidadEspectadores = cancha.CapacidadEspectadores;
                    cancha_a_actualizar.EscenarioId = cancha.EscenarioId;
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

        bool IRepositorioCanchasEspacios.EliminarCancha(int idCancha)
        {
            bool eliminado = false;
            //Se busca la cancha que se va a eliminar
            var cancha = _dataBaseContext.CanchasEspacios.Find(idCancha);

            if (cancha != null)
            {
                try
                {
                    _dataBaseContext.CanchasEspacios.Remove(cancha);
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

        CanchasEspacio IRepositorioCanchasEspacios.BuscarCancha(int idCancha)
        {
            //Se busca la cancha por su Id
            CanchasEspacio cancha = _dataBaseContext.CanchasEspacios.Find(idCancha);
            return cancha;
        }

        IEnumerable<CanchasEspacio> IRepositorioCanchasEspacios.ListarCanchas()
        {
            //Se retorna un listado de canchas utilizando el objeto _dataBaseContext
            return _dataBaseContext.CanchasEspacios;
        }
    }

}