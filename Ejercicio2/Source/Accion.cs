using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class Accion
    {
        private static int instancia;
        private string accion;
        private DateTime horarioAccion;
        private string usuario;

        /// <summary>
        /// Constructor de clase para inicializar campos de clase.
        /// </summary>
        static Accion()
        {
            Accion.instancia = 0; 
        }

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

        /// <summary>
        /// ToString() Override - Devuelve una cadena indicando los campos de la Acción.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();
            if(usuario != null && accion != null && horarioAccion != null)
            {
                aux.Append("USUARIO: " + this.usuario + " - " + "FECHA: " + this.horarioAccion.ToString() + " - " + "ACCION: " + this.accion);
            }else
            {
                throw new Exception("Error intentando imprimir la Acción."); 
            }
            return aux.ToString();
        }
    }
}
