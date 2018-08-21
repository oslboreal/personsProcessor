using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio2
{
    class Log : IManejadorArchivos
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

        /// <summary>
        /// Método encargado de corroborar que no se repita ningún cuit en la lista, en caso de repetirse, elimina el elemento de la lista
        /// </summary>
        /// <returns>int : Contador indicando la cantidad de elementos repetidos.</returns>
        public int eraseRepeatedCuits()
        {
            int iret = 0;

            return iret;
        }

        /// <summary>
        /// Corrobora que el Archivo en cuestión exista.
        /// </summary>
        /// <returns></returns>
        public bool checkFileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Obtiene el contenido de un fichero y lo retorna en una cadena.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Cadena de caracteres con el contenido del fichero.</returns>
        public string readFile(string filePath)
        {
            string sret;
            if(checkFileExists(filePath))
            {
                sret = File.ReadAllText(filePath);
                return sret;
            }else
            {
                throw new Exception("Error a la hora de leer el fichero indicado en: " + filePath);
            }
        }

        /// <summary>
        /// Reescribe el contenido de un fichero.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileContent"></param>
        /// <returns>Booleano indicando si se realizó el cambio o no.</returns>
        public bool writeFile(string filePath, string fileContent)
        {
            bool bret = false;
            if(checkFileExists(filePath))
            {
                File.WriteAllText(filePath, fileContent);
                if(this.readFile(filePath) == fileContent)
                {
                    bret = true;
                }
                return bret;
            }else
            {
                throw new Exception("Error a la hora de escribir el fichero indicado en: " + filePath);
            }
            
        }
    }
}
