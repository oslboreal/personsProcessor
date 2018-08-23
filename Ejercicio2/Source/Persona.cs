using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using NS.Librerias.Datos.Validacion;
using Nosis.Framework.Datos;

namespace Ejercicio2
{
    public class Persona
    {
        // Fields.
        public static NS.Librerias.Diagnostico.Logger logRegistro;
        private string cuit;
        private string sexo;
        private int edad;

        /// <summary>
        /// Constructor estático.
        /// </summary>
        static Persona()
        {
            Persona.logRegistro = new NS.Librerias.Diagnostico.Logger("RegistroPersonas");
        }
        /// <summary>
        /// Constructor público
        /// </summary>
        /// <param name="cuit">Cuit de la persona</param>
        /// <param name="sex">Sexo de la persona</param>
        /// <param name="edad">Edad de la persona</param>
        public Persona(string cuit, string sex, int edad)
        {
            this.cuit = cuit;
            this.sexo = sex;
            this.edad = edad;
        }

        /// <summary>
        /// Recibe una linea respetando la nomenclatura establecida, la parsea y la valida instanciando una nueva persona.
        /// </summary>
        /// <param name="linea">String Cuit;Sexo;Edad</param>
        public Persona(string linea)
        {
            // Split
            string[] words = linea.Split(';');
            try
            {
                // Cuit.
                if (Documentos.CuitEsValido(words[0]))
                {
                    this.cuit = words[0];
                }
                else
                {
                    throw new Exception("El cuit es inválido.");
                }
                //Edad.
                if (!int.TryParse(words[2], out this.edad))
                {
                    throw new Exception("La edad es inválida.");
                }
                // Sexo.
                if (words[1].Equals("M") || words[1].Equals("F"))
                {
                    this.sexo = words[1];
                }
                else
                {
                    throw new Exception(string.Format("El sexo {0} es inválido para instanciar una persona", words[1]));
                }                
            }
            catch (Exception e)
            {
                logRegistro.Error(e, "Error a la hora de instanciar persona.");
            }
        }

        /// <summary>
        ///  Returns a person as text line.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.cuit + ";" + this.sexo + ";" + this.edad;
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
