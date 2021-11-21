using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioEscuelaArbitros : IRepositorioEscuelaArbitros
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioEscuelaArbitros(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        //Implementado los metodos de la interfaz IRepositorioEscuelaArbitros
        bool IRepositorioEscuelaArbitros.CrearEscuela(EscuelaArbitro escuelaArbitro)
        {
            bool creado = false;
            try
            {
                _dataBaseContext.Escuelas.Add(escuelaArbitro);
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

        bool IRepositorioEscuelaArbitros.ActualizarEscuela(EscuelaArbitro escuelaArbitro)
        {
            bool actualizado = false;
            //Se busca la escuela por su Id utilizando la propiedad de la entidad
            var escuela_a_actualizar = _dataBaseContext.Escuelas.Find(escuelaArbitro.Id);

            if (escuela_a_actualizar != null)
            {
                try
                {
                    escuela_a_actualizar.NIT = escuelaArbitro.NIT;
                    escuela_a_actualizar.Nombre = escuelaArbitro.Nombre;
                    escuela_a_actualizar.Direccion = escuelaArbitro.Direccion;
                    escuela_a_actualizar.Telefono = escuelaArbitro.Telefono;
                    escuela_a_actualizar.Correo = escuelaArbitro.Correo;
                    escuela_a_actualizar.Resolucion = escuelaArbitro.Resolucion;

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

        bool IRepositorioEscuelaArbitros.EliminarEscuela(int idEscuelaArbitro)
        {
            bool eliminado = false;
            //Se busca la escuela que se va a eliminar
            var escuelaArbitro = _dataBaseContext.Escuelas.Find(idEscuelaArbitro);

            if (escuelaArbitro != null)
            {
                try
                {
                    _dataBaseContext.Escuelas.Remove(escuelaArbitro);
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

        EscuelaArbitro IRepositorioEscuelaArbitros.BuscarEscuela(int idEscuelaArbitro)
        {
            //Se busca la escuela por su Id
            EscuelaArbitro escuelaArbitro = _dataBaseContext.Escuelas.Find(idEscuelaArbitro);
            return escuelaArbitro;
        }

        IEnumerable<EscuelaArbitro> IRepositorioEscuelaArbitros.ListarEscuelas()
        {
            //Se retorna un listado de escuelas utilizando el objeto _dataBaseContext
            return _dataBaseContext.Escuelas;
        }
    }
}
