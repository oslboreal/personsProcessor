using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Streamer
{
    public class Text
    {
        // Fields
        

        /// <summary>
        /// Instancia un objeto Text
        /// </summary>
        /// <param name="ruta">Ruta del fichero de texto a trabajar</param>
        public Text(string ruta)
        {
            if(File.Exists(ruta))
            {
                this.path = ruta;
            }else
            {
                File.Create(ruta);
            }
        }

        /// <summary>
        /// Path of File to Read/Write
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// Getter Property - Content of the File if the File is Empty the property return value is null.
        /// </summary>
        public string content
        {
            get
            {
                if (!isOk)
                {
                    return null;
                }
                else
                {
                    return File.ReadAllText(this.path);
                }
            }
        }

        /// <summary>
        /// Getter Property - Returns file state.
        /// </summary>
        public bool isOk
        {
            get
            {
                if (File.Exists(this.path))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Return an Array of strings with the content of the file.
        /// </summary>
        /// <returns></returns>
        public string[] readLines()
        {
            string[] lines = null;
            if(isOk)
            {
                lines = File.ReadAllLines(this.path);
            }
            return lines;
        }

        /// <summary>
        /// Write all text of a file.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool writeText(string text)
        {
            bool bret = false;
            if (!File.Exists(this.path))
            {
                FileStream aux = File.Create(path);
                aux.Close();
            }
            if (this.isOk)
            {
                File.WriteAllText(this.path, text);
                if (text.Equals(File.ReadAllText(this.path)))
                {
                    bret = true;
                }
            }
            return bret;
        }

        /// <summary>
        /// Write new line in text of a file.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool writeLine(string text)
        {
            bool bret = false;
            if (!File.Exists(this.path))
            {
                FileStream aux = File.Create(path);
                aux.Close();
            }
            if (this.isOk)
            {
                using (StreamWriter file = new StreamWriter(this.path, true))
                {
                    file.WriteLine(";" + text + ";");
                    file.Close();
                }
            } 
            return bret;
        }

        public override string ToString()
        {
            return content;
        }

        /// <summary>
        /// Retorna un booleano indicando si el fichero existe.
        /// </summary>
        /// <param name="path">Ruta</param>
        /// <returns>Boolean indicando si el fichero existe o no</returns>
        static public bool ExistsAndIsTxt(string path)
        {
            bool bret = false;
            if (File.Exists(path) && !Path.GetExtension(path).Equals("txt"))
            {
                bret = true;
            }
            return bret;
        }

    }
}
