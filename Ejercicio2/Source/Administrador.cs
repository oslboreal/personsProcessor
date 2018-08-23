using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Ejercicio2.Source
{
    /// <summary>
    /// Clase encargada del procesamiento de los datos.
    /// </summary>
    public static class Administrador
    {
        // Collections
        private static List<Persona> Personas = new List<Persona>();
        private static List<Accion> Acciones = new List<Accion>();
        // Parámetros.
        private static Streamer.Text fileMasculinos = new Streamer.Text("masculinos.txt");
        private static Streamer.Text fileFemeninos = new Streamer.Text("femeninos.txt");
        private static Streamer.Text informacion = new Streamer.Text("historico.txt");
        // Fields
        private static Stopwatch tiempo;
        private static string ruta;
        private static int cantidadMasculinos;
        private static int cantidadFemeninos;
        private static int totalPersonas;
        private static int cantidadRepetidos;
        private static NS.Librerias.Diagnostico.Logger logAdministrador = new NS.Librerias.Diagnostico.Logger("logAdministrador");

        /// <summary>
        /// Inicializa los campos de clase utilizados.
        /// </summary>
        static Administrador()
        {
            Administrador.tiempo = new Stopwatch();
            Administrador.cantidadMasculinos = 0;
            Administrador.totalPersonas = 0;
            Administrador.cantidadFemeninos = 0;
            Administrador.cantidadRepetidos = 0;
        }

        /// <summary>
        /// Agrega una nueva acción a la colección para luego generar el reporte Histórico.
        /// </summary>
        /// <param name="nueva"></param>
        private static void registrarAccion(string detalle)
        {
            var accion = new Accion(detalle);
            Administrador.Acciones.Add(accion);
        }

        /// <summary>
        /// Levanta un archivo y lo parsea generando una colección de personas
        /// </summary>
        /// <param name="textPath">Ruta del archivo de Texto.</param>
        /// <param name="salida">Coleccion de Salida.</param>
        /// <returns>Retorna un booleano indicando si pudo o no realizarse la acción.</returns>
        public static void indicarFichero(string textPath)
        {
            try
            {
                Administrador.Personas.Clear();
                Streamer.Text streamer = new Streamer.Text(textPath);
                var contenido = streamer.readLines();
                foreach (var linea in contenido)
                {
                    Persona nueva = new Persona(linea);
                    Administrador.Personas.Add(nueva);
                }
                Administrador.registrarAccion(string.Format("Abriendo archivo con coleccion de personas: {0}", textPath));
                Administrador.ruta = textPath;
            }
            catch (Exception e)
            {
                // Log error.
                Administrador.logAdministrador.Error(e, string.Format("Error al abrir archivo con coleccion de personas: {0}", textPath));
            }
        }

        /// <summary>
        /// Recorre una lista de registros y en caos de estar repetidos los elimina y lo registra.
        /// </summary>
        private static void procesarDuplicados()
        {
            try
            {
                var distinct = Administrador.Personas.GroupBy(x => x.Cuit).Select(g => g.First()).ToList();
                int diferencia = Administrador.Personas.Count - distinct.Count;
                if(diferencia > 0)
                {
                    Administrador.Personas = distinct;
                    Administrador.cantidadRepetidos = diferencia;
                }
                registrarAccion(string.Format("Registros duplicados limpiados - Cantidad de duplicados: {0}", Administrador.cantidadRepetidos));
            }
            catch (Exception e)
            {
                logAdministrador.Error(e, "Error a la hora de evaluar los registros repetidos");
            }
        }

        /// <summary>
        /// Recorre la coleccion de personas, genera las cadenas de caracteres según el criterio establecido y las escribe en el fichero.
        /// </summary>
        private static void procesarPersonas()
        {
            try
            {
                Administrador.cantidadFemeninos = 0;
                Administrador.cantidadMasculinos = 0;
                StringBuilder stringFem = new StringBuilder();
                StringBuilder stringMasc = new StringBuilder();
                foreach (var person in Administrador.Personas)
                {
                    switch (person.Sexo)
                    {
                        case "M":
                            stringFem.AppendLine(person.ToString());
                            Administrador.cantidadMasculinos++;
                            break;
                        case "F":
                            stringMasc.AppendLine(person.ToString());
                            Administrador.cantidadFemeninos++;
                            break;
                        default:
                            break;
                    }
                }
                //Write
                fileMasculinos.writeText(stringFem.ToString());
                fileFemeninos.writeText(stringMasc.ToString());
                
                Administrador.totalPersonas = Administrador.cantidadFemeninos + Administrador.CantidadMasculinos;
                registrarAccion("Archivos de personas generados");
            }
            catch (Exception e)
            {
                logAdministrador.Error(e, "Error a la hora de procesar las personas.");
            }
        }

        /// <summary>
        /// Recorre la colección de Acciones generando el Archivo con el Histórico.
        /// </summary>
        private static void procesarAcciones()
        {
            try
            {
                Administrador.registrarAccion("Acciones procesadas.");
                Administrador.registrarAccion("Información procesada");
                foreach (var accion in Administrador.Acciones)
                {
                    accion.grabarAccion();
                }
                Administrador.Acciones.Clear();

            }
            catch (Exception e)
            {
                logAdministrador.Error(e, "Error a la hora de procesar las acciones");
            }
        }

        /// <summary>
        /// Analiza las personas y genera los ficheros.
        /// </summary>
        public static void procesar()
        {
            try
            {
                Administrador.tiempo.Start();
                procesarDuplicados();
                procesarPersonas();
                Administrador.tiempo.Stop();
                Administrador.registrarAccion(string.Format("Tiempo transcurrido: {0} milisegundos.", tiempo.ElapsedMilliseconds));
                procesarAcciones();
            }
            catch (Exception e)
            {
                Administrador.logAdministrador.Error(e, "Error a la hora de procesar.");
                throw;
            }
        }
        /// <summary>
        /// Retorna una cadena con todo el Historico.
        /// </summary>
        /// <returns>String</returns>
        public static string traerHistorico()
        {
            StringBuilder aux = new StringBuilder();
            foreach (var item in Administrador.informacion.readLines())
            {
                aux.AppendLine(item);
            }
            return aux.ToString();
        }

        #region Propiedades
        /// <summary>
        /// Only read - Returns the quantity of Mans.
        /// </summary>
        public static int CantidadMasculinos
        {
            get
            {
                return cantidadMasculinos;
            }
        }

        /// <summary>
        /// Only read - Returns the quantity of All persons.
        /// </summary>
        public static int TotalPersonas
        {
            get
            {
                return totalPersonas;
            }
        }

        /// <summary>
        /// Only read - Returns quantity of Womans.
        /// </summary>
        public static int CantidadFemeninos
        {
            get
            {
                return cantidadFemeninos;
            }
        }
        #endregion

    }
}
