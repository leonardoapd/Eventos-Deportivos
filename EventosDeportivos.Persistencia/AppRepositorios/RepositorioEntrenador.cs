using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioEntrenador : IRepositorioEntrenador
    {
        //Atributos
        private readonly AppContext _dataBaseContext;
        //Metodos
        //Constructor
        public RepositorioEntrenador(AppContext appContext)
        {
            _dataBaseContext = appContext;
        }
        //Implementación de los métodos de la interfaz IRepositorioMunicipio

        bool IRepositorioEntrenador.CrearEntrenador(Entrenador entrenador)
        {
            bool creado = false;
            try
            {
                _dataBaseContext.Entrenadores.Add(entrenador);
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
        bool IRepositorioEntrenador.ActualizarEntrenador(Entrenador entrenador)
        {
            bool actualizado = false;
            var entrenador_a_actualizar = _dataBaseContext.Entrenadores.Find(entrenador.Id);

            if (entrenador_a_actualizar != null)
            {
                try
                {
                    entrenador_a_actualizar.Documento = entrenador.Documento;
                    entrenador_a_actualizar.Nombre = entrenador.Nombre;
                    entrenador_a_actualizar.Apellido = entrenador.Apellido;
                    entrenador_a_actualizar.Direccion = entrenador.Direccion;
                    entrenador_a_actualizar.Genero = entrenador.Genero;
                    entrenador_a_actualizar.Deporte = entrenador.Deporte;
                    entrenador_a_actualizar.EquipoId = entrenador.EquipoId;
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
        bool IRepositorioEntrenador.EliminarEntrenador(int idEntrenador)
        {
            {
                bool eliminado = false;
                //Se busca el municipio que se va a eliminar
                var entrenador = _dataBaseContext.Entrenadores.Find(idEntrenador);

                if (entrenador != null)
                {
                    try
                    {
                        _dataBaseContext.Entrenadores.Remove(entrenador);
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
        }
        Entrenador IRepositorioEntrenador.BuscarEntrenador(int idEntrenador)
        {
            Entrenador entrenador = _dataBaseContext.Entrenadores.Find(idEntrenador);
            return entrenador;
        }
        IEnumerable<Entrenador> IRepositorioEntrenador.ListarEntrenadores()
        {
            return _dataBaseContext.Entrenadores;
        }
    }
}