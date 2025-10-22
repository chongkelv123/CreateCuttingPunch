using CreateCuttingPunch.Model;
using NXOpen;
using NXOpen.Features.AECDesign;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Services
{
    public class FileManagerService
    {
        /// <summary>
        /// Gets all .prt files from the specified path and filters to keep only latest versions
        /// </summary>
        /// <param name="path">Directory path to search</param>
        /// <param name="filterVersions">Whether to filter out old versions (default: true)</param>
        /// <returns>List of file paths</returns>
        public static List<string> Get(string path, bool filterVersion = true)
        {
            if(!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}");
            }

            var searchPattern = "*.prt";
            var files = Directory.GetFiles(path, searchPattern).ToList();

            if(filterVersion)
            {
                files = VersionFilterService.FilterLatestVersions(files);
            }

            return files;
        }

        /// <summary>
        /// Gets all .prt files from the specified path without version filtering
        /// </summary>
        /// <param name="path">Directory path to search</param>
        /// <returns>List of all file paths</returns>
        public static List<string> GetAllVersions(string path)
        {
            return Get(path, filterVersion: false);
        }

        /// <summary>
        /// Gets only assembly files (.prt) and filters to latest versions
        /// </summary>
        /// <param name="path">Directory path to search</param>
        /// <returns>List of assembly file paths</returns>
        public static List<string> GetAssemblyFiles(string path)
        {
            var allFiles = Get(path, filterVersion: true);            
            return allFiles.Where(f =>
                f.ToLowerInvariant().Contains("assembly") ||
                f.ToLowerInvariant().Contains("asm"))
                .ToList();

        }

        public static string GetCurrentDirectory(Part workPart)
        {
            var fullPath = workPart.FullPath;
            var directory = Path.GetDirectoryName(fullPath);

            return directory;
        }
    }
}
