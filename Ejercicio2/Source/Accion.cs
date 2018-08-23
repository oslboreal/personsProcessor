using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class Accion
    {
        // Fields
        private string accion;
        private DateTime horarioAccion;
        private string usuario;
        private static NS.Librerias.Diagnostico.Logger logAcciones = new NS.Librerias.Diagnostico.Logger("logAcciones");
        private static Streamer.Text accionesHistorico = new Streamer.Text("historico.txt");

        /// <summary>
        /// Constructor de instancia para inicializar campos de instancia.
        /// </summary>
        public Accion(string acc)
        {
            this.accion = acc;
            this.horarioAccion = DateTime.Now;
            // Obtengo el nombre del usuario del sistema.
            usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        public void grabarAccion()
        {
            //Registramos
            Accion.accionesHistorico.writeLine(this.ToString());
        }

        /// <summary>
        /// ToString() Override - Devuelve una cadena indicando los campos de la Acción.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();
            try
            {
                aux.Append("USUARIO: " + this.usuario + " - " + "FECHA: " + this.horarioAccion.ToString() + " - " + "ACCION: " + this.accion);
                return aux.ToString();
            }
            catch (Exception e)
            {
                Accion.logAcciones.Error(e,"Error a la hora de mostrar el usuario.");
                throw;
            }
        }
    }
}
