using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioMunicipio(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        //Implementado los metodos de la interfaz IRepositorioMunicipio
        bool IRepositorioMunicipio.CrearMunicipio(Municipio municipio)
        {
            bool creado = false;
            var municipio_a_crear = _dataBaseContext.Municipios.FirstOrDefault(municipioC => municipioC.Nombre == municipio.Nombre);
            //Si el municipio a crear ya se encuentra en la base de datos, el registro no se crea
            if (municipio_a_crear == null)
            {
                try
                {
                    _dataBaseContext.Municipios.Add(municipio);
                    //Es necesario guardar los cambios cada vez que se modifica informacion en la base de datos
                    _dataBaseContext.SaveChanges();
                    creado = true;
                }
                catch (System.Exception)
                {
                    creado = false;
                }
            }
            return creado;
        }



        bool IRepositorioMunicipio.ActualizarMunicipio(Municipio municipio)
        {
            bool actualizado = false;
            //Se busca el municipio por su Id utilizando la propiedad de la entidad
            var municipio_a_actualizar = _dataBaseContext.Municipios.Find(municipio.Id);

            if (municipio_a_actualizar != null)
            {
                try
                {
                    municipio_a_actualizar.Nombre = municipio.Nombre;
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

        bool IRepositorioMunicipio.EliminarMunicipio(int idMunicipio)
        {
            bool eliminado = false;
            //Se busca el municipio que se va a eliminar
            var municipio = _dataBaseContext.Municipios.Find(idMunicipio);

            if (municipio != null)
            {
                try
                {
                    _dataBaseContext.Municipios.Remove(municipio);
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

        Municipio IRepositorioMunicipio.BuscarMunicipio(int idMunicipio)
        {
            //Se busca el municipio por su Id
            var municipio = _dataBaseContext.Municipios.Find(idMunicipio);
            return municipio;
        }

        IEnumerable<Municipio> IRepositorioMunicipio.ListarMunicipios()
        {
            //Se retorna un listado de municipios utilizando el objeto _dataBaseContext
            return _dataBaseContext.Municipios;
        }
    }
}