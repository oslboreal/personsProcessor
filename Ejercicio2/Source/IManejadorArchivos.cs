using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public interface IManejadorArchivos
    {
        bool writeFile(string filePath, string fileContent);
        string[] readFile(string filePath);
        bool checkFileExists(string filePath);
    }
}
