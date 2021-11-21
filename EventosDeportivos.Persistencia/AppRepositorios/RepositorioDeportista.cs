//la clase que implementa las firmas
using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioDeportista : IRepositorioDeportista
    {
        //Atributos
        private readonly AppContext _dataBaseContext;
        //Metodos
        //Constructor
        public RepositorioDeportista(AppContext appContext)
        {
            _dataBaseContext = appContext;
        }
        //Implementación de los métodos de la interfaz IRepositorioMunicipio

        bool IRepositorioDeportista.CrearDeportista(Deportista deportista)
        {
            {
                bool creado = false;
                try
                {
                    _dataBaseContext.Deportistas.Add(deportista);
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
        }
        bool IRepositorioDeportista.ActualizarDeportista(Deportista deportista)
        {
            bool actualizado = false;
            //Se busca la cancha por su Id utilizando la propiedad de la entidad
            var deportista_a_actualizar = _dataBaseContext.Deportistas.Find(deportista.Id);

            if (deportista_a_actualizar != null)
            {
                try
                {
                    deportista_a_actualizar.Documento = deportista.Documento;
                    deportista_a_actualizar.Nombre = deportista.Nombre;
                    deportista_a_actualizar.Apellido = deportista.Apellido;
                    deportista_a_actualizar.Genero = deportista.Genero;
                    deportista_a_actualizar.Rh = deportista.Rh;
                    deportista_a_actualizar.EPS = deportista.EPS;
                    deportista_a_actualizar.FechaNacimiento = deportista.FechaNacimiento;
                    deportista_a_actualizar.Deporte = deportista.Deporte;
                    deportista_a_actualizar.Direccion = deportista.Direccion;
                    deportista_a_actualizar.NumeroEmergencia = deportista.NumeroEmergencia;
                    deportista_a_actualizar.EquipoId = deportista.EquipoId;
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
        bool IRepositorioDeportista.EliminarDeportista(int idDeportista)
        {
            {
                bool eliminado = false;
                //Se busca el deportista que se va a eliminar
                var deportista = _dataBaseContext.Deportistas.Find(idDeportista);

                if (deportista != null)
                {
                    try
                    {
                        _dataBaseContext.Deportistas.Remove(deportista);
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
        Deportista IRepositorioDeportista.BuscarDeportista(int idDeportista)
        {
            //Se busca la cancha por su Id
            Deportista deportista = _dataBaseContext.Deportistas.Find(idDeportista);
            return deportista;
        }
        IEnumerable<Deportista> IRepositorioDeportista.ListarDeportistas()
        {
            return _dataBaseContext.Deportistas;
        }
    }
}