using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioTorneoEquipo : IRepositorioTorneoEquipo
    {
        //Atributos
        private readonly AppContext _dataBaseContext;
        //Metodos
        //Constructor
        public RepositorioTorneoEquipo(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        bool IRepositorioTorneoEquipo.InscribirEquipoATorneo(int idEquipo, int idTorneo)
        {
            bool inscrito = false;

            //Busqueda personalizada para saber si un registro ya esta creado
            var e_inscrito = _dataBaseContext.TorneosEquipos.FirstOrDefault(t => t.TorneoId == idTorneo && t.EquipoId == idEquipo);

            if (e_inscrito == null)
            {
                try
                {
                    _dataBaseContext.TorneosEquipos.Add(new TorneoEquipo()
                    {
                        EquipoId = idEquipo,
                        TorneoId = idTorneo
                    });
                    _dataBaseContext.SaveChanges();
                    inscrito = true;
                }
                catch (System.Exception)
                {

                    inscrito = false;
                }
            }


            return inscrito;
        }

        bool IRepositorioTorneoEquipo.EliminarInscripcion(int idEquipo, int idTorneo)
        {
            bool eliminado = false;
            
            //Se realiza la busqueda personalizada para encontrar el primer registro que coincida.
            var inscripcion_a_eliminar = _dataBaseContext.TorneosEquipos.FirstOrDefault(t => t.TorneoId == idTorneo && t.EquipoId == idEquipo);

            if(inscripcion_a_eliminar != null)
            {
                try
                {
                     _dataBaseContext.TorneosEquipos.Remove(inscripcion_a_eliminar);
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

        IEnumerable<TorneoEquipo> IRepositorioTorneoEquipo.ListarInscritos()
        {
            return _dataBaseContext.TorneosEquipos;
        }
    }
}