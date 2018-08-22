using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Streamer
{
    static public class Text
    {
        /// <summary>
        /// Path of File to Read/Write
        /// </summary>
        public static string path { get; set; }
        /// <summary>
        /// Getter Property - Content of the File if the File is Empty the property return value is null.
        /// </summary>
        public static string content
        {
            get
            {
                if (!isOk)
                {
                    return null;
                }
                else
                {
                    return File.ReadAllText(Text.path);
                }
            }
        }

        /// <summary>
        /// Getter Property - Returns file state.
        /// </summary>
        public static bool isOk
        {
            get
            {
                if (File.Exists(Text.path))
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
        /// Write all text of a file.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool writeText(string text)
        {
            bool bret = false;
            if (!File.Exists(Text.path))
            {
                FileStream aux = File.Create(path);
                aux.Close();
            }
            if (Text.isOk)
            {
                File.WriteAllText(Text.path, text);
                if (text.Equals(File.ReadAllText(Text.path)))
                {
                    bret = true;
                }
            }
            return bret;
        }
    }
}
