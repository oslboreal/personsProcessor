using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using NS.Librerias.Datos.Validacion;

namespace Ejercicio2
{

    public class Persona
    {
        // Fields.
        private string cuit;
        private string sexo;
        private string edad;
        public Persona(string cuit, string sex, string edad)
        {
            this.cuit = cuit;
            this.sexo = sex;
            this.edad = edad;
        }
        

        /// <summary>
        /// Construye.
        /// </summary>
        /// <param name="linea"></param>
        public Persona(string linea)
        {
            string[] words = linea.Split(';');
            try
            {
                if (Documentos.CuitEsValido(words[0]))
                {
                    this.cuit = words[0];
                }else
                {
                    throw new Exception("Error a la hora de instanciar persona, el cuit es invalido.");
                }
                    
                // Validate.
                this.sexo = words[1];
                this.edad = words[2];
            }
            catch (Exception)
            {

                throw;
            }

        }

        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();
            aux.AppendLine(this.cuit);
            aux.AppendLine(this.sexo);
            aux.AppendLine(this.edad);
            return aux.ToString();
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

        public string Sexo
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

        public string Edad
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
