using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioArbitro : IRepositorioArbitro
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioArbitro(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        //Implementado los metodos de la interfaz IRepositorioArbitro
        bool IRepositorioArbitro.CrearArbitro(Arbitro arbitro)
        {
            bool creado = false;
            try
            {
                _dataBaseContext.Arbitros.Add(arbitro);
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

        bool IRepositorioArbitro.ActualizarArbitro(Arbitro arbitro)
        {
            bool actualizado = false;
            //Se busca el arbitro por su Id utilizando la propiedad de la entidad
            var arbitro_a_actualizar = _dataBaseContext.Arbitros.Find(arbitro.Id);

            if (arbitro_a_actualizar != null)
            {
                try
                {
                    arbitro_a_actualizar.Documento = arbitro.Documento;
                    arbitro_a_actualizar.Nombre = arbitro.Nombre;
                    arbitro_a_actualizar.Apellido = arbitro.Apellido;
                    arbitro_a_actualizar.Genero = arbitro.Genero;
                    arbitro_a_actualizar.Telefono = arbitro.Telefono;
                    arbitro_a_actualizar.Correo = arbitro.Correo;
                    arbitro_a_actualizar.Deporte = arbitro.Deporte;
                    arbitro_a_actualizar.TorneoId = arbitro.TorneoId;
                    arbitro_a_actualizar.EscuelaArbitroId = arbitro.EscuelaArbitroId;
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

        bool IRepositorioArbitro.EliminarArbitro(int idArbitro)
        {
            bool eliminado = false;
            //Se busca el arbitro que se va a eliminar
            var arbitro = _dataBaseContext.Arbitros.Find(idArbitro);

            if (arbitro != null)
            {
                try
                {
                    _dataBaseContext.Arbitros.Remove(arbitro);
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

        Arbitro IRepositorioArbitro.BuscarArbitro(int idArbitro)
        {
            //Se busca el arbitro por su Id
            Arbitro arbitro = _dataBaseContext.Arbitros.Find(idArbitro);
            return arbitro;
        }

        IEnumerable<Arbitro> IRepositorioArbitro.ListarArbitros()
        {
            //Se retorna un listado de arbitros utilizando el objeto _dataBaseContext
            return _dataBaseContext.Arbitros;
        }
    }
}