using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio2
{
    class Log 
    {

        // Ruta de los ficheros.
        public static string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
        public static string rutaMasculinos = Path.Combine(Log.path, "masculinos.txt");
        public static string rutaFemeninos = Path.Combine(Log.path, "femeninos.txt");
        public static string rutaHistorico = Path.Combine(Log.path, "historico.txt");

        // Personas.
        private List<Persona> masculinos;
        private List<Persona> femeninos;
        private List<Accion> acciones;

        /// <summary>
        /// Constructor de Instancia
        /// </summary>
        public Log()
        {
            // Inicializamos las colecciones.
            this.masculinos = new List<Persona>();
            this.femeninos = new List<Persona>();
            this.acciones = new List<Accion>();
        }

    }
}
