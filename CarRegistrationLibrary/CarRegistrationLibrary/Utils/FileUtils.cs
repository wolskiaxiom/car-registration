using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistrationLibrary.Utils
{
    internal static class FileUtils
    {

        private static string FileName(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", fileName);
        }

        public static List<string> LoadFile(String fileName)
        {
            var path = FileName(fileName);
            if(!File.Exists(path))
            {
                File.Create(path);
            }
            var str = File.ReadAllText(path);

            if(str.Trim() == "")
            {
                return new List<string>();
            } else
            {
                return str.Split(
                    new string[] { Environment.NewLine },
                    StringSplitOptions.None
                ).Select(s => s.Trim()).ToList();
            }
 
        }

        public static void SaveToFile(string fileName, IEnumerable<string> lines)
        {
            var str = String.Join(Environment.NewLine, lines);
            File.WriteAllText(FileName(fileName), str);
        }
    }
}
