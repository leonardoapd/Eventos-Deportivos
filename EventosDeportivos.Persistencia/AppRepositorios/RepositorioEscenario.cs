using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioEscenario : IRepositorioEscenario
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        public RepositorioEscenario(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        //Implementado los metodos de la interfaz IRepositorioEscenario
        bool IRepositorioEscenario.CrearEscenario(Escenario escenario)
        {
            bool creado = false;
            try
            {
                _dataBaseContext.Escenarios.Add(escenario);
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

        bool IRepositorioEscenario.ActualizarEscenario(Escenario escenario)
        {
            bool actualizado = false;
            //Se busca el escenario por su Id utilizando la propiedad de la entidad
            var escenario_a_actualizar = _dataBaseContext.Escenarios.Find(escenario.Id);

            if (escenario_a_actualizar != null)
            {
                try
                {
                    escenario_a_actualizar.Nombre = escenario.Nombre;
                    escenario_a_actualizar.Direccion = escenario.Direccion;
                    escenario_a_actualizar.Telefono = escenario.Telefono;
                    escenario_a_actualizar.Horario = escenario.Horario;
                    escenario_a_actualizar.TorneoId = escenario.TorneoId;
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

        bool IRepositorioEscenario.EliminarEscenario(int idEscenario)
        {
            bool eliminado = false;
            //Se busca el escenario que se va a eliminar
            var escenario = _dataBaseContext.Escenarios.Find(idEscenario);

            if (escenario != null)
            {
                try
                {
                    _dataBaseContext.Escenarios.Remove(escenario);
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

        Escenario IRepositorioEscenario.BuscarEscenario(int idEscenario)
        {
            //Se busca el escenario por su Id
            Escenario escenario = _dataBaseContext.Escenarios.Find(idEscenario);
            return escenario;
        }

        IEnumerable<Escenario> IRepositorioEscenario.ListarEscenarios()
        {
            //Se retorna un listado de escenarios utilizando el objeto _dataBaseContext
            return _dataBaseContext.Escenarios;
        }
    }
}