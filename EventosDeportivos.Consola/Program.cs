using System;
using EventosDeportivos.Dominio;
using EventosDeportivos.Persistencia;
using System.Collections.Generic;

namespace EventosDeportivos.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repositorioMunicipio = new RepositorioMunicipio(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioTorneo _repositorioTorneo = new RepositorioTorneo(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioEscenario _repositorioEscenario = new RepositorioEscenario(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioPatrocinador _repositorioPatrocinador = new RepositorioPatrocinador(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioEquipo _repositorioEquipo = new RepositorioEquipo(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioTorneoEquipo _repositorioTorneoEquipo = new RepositorioTorneoEquipo(new EventosDeportivos.Persistencia.AppContext());
        static void Main(string[] args)
        {
            /*
            bool creado = crearMunicipio();

            if (creado)
            {
                Console.WriteLine("Se ha creado satisfactoriamente el municipio");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en la creacion del municipio");
            }
            

            bool actualizado = actualizarMunicipio();

            if (actualizado)
            {
                Console.WriteLine("Se ha actualizado satisfactoriamente el municipio");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en la actualizacion del municipio");
            }
            
            //bool eliminado = eliminarMunicipio();
            
            buscarMunicipio();
            

            bool creado = crearTorneo();

            if (creado)
            {
                Console.WriteLine("Se ha creado satisfactoriamente el torneo");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en la creacion del torneo");
            }
            
            listarTorneos();

            

            
            bool actualizado = actualizarTorneo();

            if (actualizado)
            {
                Console.WriteLine("Se ha actualizado satisfactoriamente el torneo");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en la actualizacion del torneo");
            }

            listarTorneos();
            


            bool creado = crearEscenario();

            if (creado)
            {
                Console.WriteLine("Se ha creado satisfactoriamente el escenario");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en la creacion del escenario");
            }
            
            
            listarEscenarios();

            

            bool creado = crearPatrocinador();

            if (creado)
            {
                Console.WriteLine("El patrocinador fue creado");
            }
            else
            {
                Console.WriteLine("El patrocinador no fue creado");
            }

            

            crearEquipo();
            */
            //inscribirEquipo();
            
            // listarTorneos();
            // Console.WriteLine("----------------------------------------------------------------");
            // listarEquipos();
            // Console.WriteLine("----------------------------------------------------------------");
            // listarMunicipios();
            // Console.WriteLine("----------------------------------------------------------------");
            // listarPatrocinadores();
            // Console.WriteLine("----------------------------------------------------------------");
            // listarEscenarios();
            // Console.WriteLine("----------------------------------------------------------------");


            listarTorneos();

            

            
            bool actualizado = actualizarTorneo();

            if (actualizado)
            {
                Console.WriteLine("Se ha actualizado satisfactoriamente el torneo");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en la actualizacion del torneo");
            }
        }

        private static bool crearMunicipio()
        {
            Console.WriteLine("Ingrese el municipio");
            var municipio = new Municipio
            {
                Nombre = Console.ReadLine()
            };
            bool creado = _repositorioMunicipio.CrearMunicipio(municipio);

            return creado;

        }

        private static void listarMunicipios()
        {
            IEnumerable<Municipio> municipios = _repositorioMunicipio.ListarMunicipios();
            Console.WriteLine(String.Format("{0,-5} | {1,-16} |", "ID", "Nombre"));
            Console.WriteLine(String.Format("{0,-5} | {1,-16} |", "-----", "----------------"));
            foreach (var municipio in municipios)
            {
                Console.WriteLine(String.Format("{0,-5} | {1,-16} |", municipio.Id, municipio.Nombre));
                Console.WriteLine(String.Format("{0,-5} | {1,-16} |", "-----", "----------------"));
            }
        }

        private static bool eliminarMunicipio()
        {
            Console.Write("Ingrese el Id del municipio a eliminar: ");
            int idMunicipio = int.Parse(Console.ReadLine());


            bool eliminado = _repositorioMunicipio.EliminarMunicipio(idMunicipio);

            return eliminado;
        }

        private static bool actualizarMunicipio()
        {
            Console.WriteLine("Ingrese el Id del municipio a actualizar");
            int idMunicipio = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del municipio");
            string nombreMunicipio = Console.ReadLine();

            var municipio = new Municipio
            {
                Id = idMunicipio,
                Nombre = nombreMunicipio
            };

            bool actualizado = _repositorioMunicipio.ActualizarMunicipio(municipio);

            return actualizado;
        }

        private static void buscarMunicipio()
        {
            Console.WriteLine("Ingrese el Id del municipio a buscar:");
            int idMunicipio = int.Parse(Console.ReadLine());

            Municipio municipio = _repositorioMunicipio.BuscarMunicipio(idMunicipio);
            if (municipio != null)
            {
                Console.WriteLine(municipio.Id + " " + municipio.Nombre);
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error al buscar el municipio");
            }
        }

        private static bool crearTorneo()
        {
            Console.WriteLine("Ingrese el nombre del torneo: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su categoria: ");
            string categoria = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de inicio del torneo");
            var fechaInicial = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de terminacion del torneo");
            var fechaFinal = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese el tipo del torneo");
            string tipo = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del municipio en que se va a realizar el torneo del torneo");
            listarMunicipios();
            int municipioId = int.Parse(Console.ReadLine());


            bool creado = _repositorioTorneo.CrearTorneo(new Torneo
            {
                Nombre = nombre,
                Categoria = categoria,
                FechaInicio = fechaInicial,
                FechaFin = fechaFinal,
                Tipo = tipo,
                MunicipioId = municipioId
            });

            return creado;

        }

        private static void listarTorneos()
        {
            IEnumerable<Torneo> torneos = _repositorioTorneo.ListarTorneos();
            Console.WriteLine(String.Format("{0,-5} | {1,-22} | {2,-16} | {3,-16} |", "Id", "Nombre", "Categoria", "Tipo"));
            Console.WriteLine(String.Format("{0,-5} | {1,-22} | {2,-16} | {3,-16} |", "-----", "---------------------", "----------------", "---------"));
            foreach (var torneo in torneos)
            {
                Console.WriteLine(String.Format("{0,-5} | {1,-22} | {2,-16} | {3,-16} |", torneo.Id, torneo.Nombre, torneo.Categoria, torneo.Tipo));
                Console.WriteLine(String.Format("{0,-5} | {1,-22} | {2,-16} | {3,-16} |", "-----", "---------------------", "----------------", "---------"));
            }


        }

        private static bool actualizarTorneo()
        {
            listarTorneos();

            Console.WriteLine("Ingrese el numero del torneo que va a actualizar:");
            int idTorneo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del torneo: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su categoria: ");
            string categoria = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de inicio del torneo");
            var fechaInicial = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de terminacion del torneo");
            var fechaFinal = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese el tipo del torneo");
            string tipo = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del municipio en que se va a realizar el torneo del torneo");
            listarMunicipios();
            int municipioId = int.Parse(Console.ReadLine());



            bool actualizado = _repositorioTorneo.ActualizarTorneo(new Torneo
            {
                Id = idTorneo,
                Nombre = nombre,
                Categoria = categoria,
                FechaInicio = fechaInicial,
                FechaFin = fechaFinal,
                Tipo = tipo,
                MunicipioId = municipioId
            });

            return actualizado;

        }

        private static Torneo buscarTorneo(int idTorneo)
        {
            Torneo torneo = _repositorioTorneo.BuscarTorneo(idTorneo);

            return torneo;
        }
        private static bool crearEscenario()
        {
            Console.WriteLine("Ingrese el nombre del escenario: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion: ");
            string direccion = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono: ");
            var telefono = Console.ReadLine();
            Console.WriteLine("Ingrese la franja horaria de operacion: ");
            var horario = Console.ReadLine();
            listarTorneos();
            Console.WriteLine("Escoja el torneo al que pertenece: ");
            int torneoId = int.Parse(Console.ReadLine());


            var escenario = new Escenario
            {
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                Horario = horario,
                TorneoId = torneoId
            };
            bool creado = _repositorioEscenario.CrearEscenario(escenario);

            return creado;

        }

        private static void listarEscenarios()
        {
            IEnumerable<Escenario> escenarios = _repositorioEscenario.ListarEscenarios();
            Console.WriteLine(String.Format("{0,-5} | {1,-38} | {2,-20} | {3,-10} |", "Id", "Nombre", "Direccion", "Telefono"));
            Console.WriteLine(String.Format("{0,-5} | {1,-38} | {2,-20} | {3,-10} |", "-----", "---------------------", "----------------", "---------"));
            foreach (var escenario in escenarios)
            {
                Console.WriteLine(String.Format("{0,-5} | {1,-38} | {2,-20} | {3,-10} |", escenario.Id, escenario.Nombre, escenario.Direccion, escenario.Telefono));
                Console.WriteLine(String.Format("{0,-5} | {1,-38} | {2,-20} | {3,-10} |", "-----", "---------------------", "----------------", "---------"));
            }


        }

        private static bool crearPatrocinador()
        {
            Console.WriteLine("Ingrese el numero de identificacion: ");
            string identificacion = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del patrocinador: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el tipo de persona del patrocinador: ");
            string tipodepersona = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion del patrocinador: ");
            string direccion = Console.ReadLine();

            var patrocinador = new Patrocinador
            {
                Identificacion = identificacion,
                Nombre = nombre,
                TipoPersona = tipodepersona,
                Direccion = direccion
            };

            bool creado = _repositorioPatrocinador.CrearPatrocinador(patrocinador);

            return creado;
        }

        private static void listarPatrocinadores()
        {
            IEnumerable<Patrocinador> patrocinadores = _repositorioPatrocinador.ListarPatrocinadores();
            Console.WriteLine(String.Format("{0,-5} | {1,-18} | {2,-20} | {3,-24} | {4,-16}|", "Id", "Identificacion", "Nombre", "Direccion", "Tipo de Persona"));
            Console.WriteLine(String.Format("{0,-5} | {1,-18} | {2,-20} | {3,-24} | {4,-16}|", "-----", "-----------------", "----------------", "-------------------", "--------"));
            foreach (var patrocinador in patrocinadores)
            {
                Console.WriteLine(String.Format("{0,-5} | {1,-18} | {2,-20} | {3,-24} | {4,-16}|", patrocinador.Id, patrocinador.Identificacion, patrocinador.Nombre, patrocinador.Direccion, patrocinador.TipoPersona));
                Console.WriteLine(String.Format("{0,-5} | {1,-18} | {2,-20} | {3,-24} | {4,-16}|", "-----", "-----------------", "----------------", "-------------------", "--------"));
            }
        }

        private static bool crearEquipo()
        {
            Console.WriteLine("Ingrese el nombre del equipo: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad de deportistas que posee el equipo: ");
            int cantidad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el deporte que practica el equipo: ");
            string deporte = Console.ReadLine();
            Console.WriteLine("Especifique el patrocinador del equipo: ");
            listarPatrocinadores();
            int patrocinadorId = int.Parse(Console.ReadLine());


            bool creado = _repositorioEquipo.CrearEquipo(new Equipo
            {
                Nombre = nombre,
                CantidadDeportistas = cantidad,
                Deporte = deporte,
                PatrocinadorId = patrocinadorId
            });

            return creado;
        }

        private static Equipo buscarEquipo(int idEquipo)
        {
            Equipo equipo = _repositorioEquipo.BuscarEquipo(idEquipo);

            return equipo;
        }

        private static void listarEquipos()
        {
            IEnumerable<Equipo> equipos = _repositorioEquipo.ListarEquipos();
            Console.WriteLine(String.Format("{0,-5} | {1,-18} | {2,-20} | {3,-28} | {4,-20}|", "Id", "Nombre", "Cantidad De Deportistas", "Deporte", "Id del Patrocinador"));
            Console.WriteLine(String.Format("{0,-5} | {1,-18} | {2,-20} | {3,-28} | {4,-20}|", "-----", "-----------------", "------------------", "-------------------", "--------"));
            foreach (var equipo in equipos)
            {
                Console.WriteLine(String.Format("{0,-5} | {1,-18} | {2,-20} | {3,-28} | {4,-20}|", equipo.Id, equipo.Nombre, equipo.CantidadDeportistas, equipo.Deporte, equipo.PatrocinadorId));
                Console.WriteLine(String.Format("{0,-5} | {1,-18} | {2,-20} | {3,-28} | {4,-20}|", "-----", "-----------------", "------------------", "-------------------", "--------"));
            }
        }

        private static void inscribirEquipo()
        {
            Console.WriteLine("Elija el equipo: ");
            listarEquipos();
            int idEquipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Elija el torneo al cual desea inscribir al equipo: ");
            listarTorneos();
            int idTorneo = int.Parse(Console.ReadLine());

            bool inscrito = _repositorioTorneoEquipo.InscribirEquipoATorneo(idEquipo, idTorneo);

            if (inscrito)
            {
                Equipo equipo = buscarEquipo(idEquipo);
                Torneo torneo = buscarTorneo(idTorneo);

                Console.WriteLine("{0} ha sido inscrito al torneo {1}", equipo.Nombre, torneo.Nombre);
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error durante la inscripcion");
            }

        }

        /*
        private static void listarInscritos()
        {
            IEnumerable<TorneoEquipo> inscritos = _repositorioTorneoEquipo.ListarInscritos();
            Console.WriteLine(String.Format(" {0,-18} | {1,-20} | ", "Equipo", "Torneo"));
            Console.WriteLine(String.Format(" {0,-18} | {1,-20} | ", "-----------------", "------------------"));
            foreach (var inscrito in inscritos)
            {

                Console.WriteLine(String.Format(" {0,-18} | {1,-20} | ", );
                Console.WriteLine(String.Format(" {0,-18} | {1,-20} | ", "-----------------", "------------------"));
            }
        }
        */
    }
}
