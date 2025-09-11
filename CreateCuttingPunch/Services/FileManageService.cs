using CreateCuttingPunch.Model;
using NXOpen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Services
{
    public class FileManageService
    {
        public static List<string> Get(string path)
        {
            if(!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}");
            }

            var searchPattern = "*.prt";
            var files = Directory.GetFiles(path, searchPattern);

            string output = string.Empty;
            files.ToList().ForEach(f =>
            {
                if (f.Contains("Assembly") || f.Contains("Asm"))
                {
                    output += f + "\n";
                }
            });            

            return files.ToList();
        }

        public static string GetCurrentDirectory(Part workPart)
        {
            var fullPath = workPart.FullPath;
            var directory = Path.GetDirectoryName(fullPath);

            return directory;
        }
    }
}
