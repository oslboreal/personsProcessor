using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class Persona
    {
        // Fields.
        private string cuit;
        private char sexo;
        private int edad;

        /// <summary>
        /// Corrobora que la cadena de caracteres sea un CUIT/CUIL.
        /// </summary>
        /// <param name="cuit"></param>
        /// <returns>Boolean</returns>
        public bool checkCuit(string cuit)
        {
            bool bret = false;
            // Longitud.
            if(cuit.Length == 11)
            {
                //20, 23, 24 y 27 para Personas Físicas
                if (cuit.StartsWith("20") || cuit.StartsWith("23") || cuit.StartsWith("24") || cuit.StartsWith("27"))
                {
                    bret = true;
                }
            }
            
            return bret;
        }

        #region Properties.
        public string Cuit
        {
            get
            {
                return cuit;
            }

            set
            {
                cuit = value;
            }
        }

        public char Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public int Edad
        {
            get
            {
                return edad;
            }

            set
            {
                edad = value;
            }
        }
#endregion
    }
}
