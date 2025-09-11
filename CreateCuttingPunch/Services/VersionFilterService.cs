using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Services
{
    public static class VersionFilterService
    {
        /// <summary>
        /// Filters a list of filenames to keep only the latest version of each unique file pattern.
        /// Files are expected to have version pattern like "-V00", "-V01", "-V02", etc.
        /// </summary>
        /// <param name="filePaths">List of file paths or filenames</param>
        /// <returns>Filtered list containing only the latest versions</returns>
        public static List<string> FilterLatestVersions(List<string> filePaths)
        {
            if (filePaths == null || !filePaths.Any())
                return new List<string>();

            var fileGroups = new Dictionary<string, List<FileVersionInfo>>();

            // Group files by their base pattern (without version)
            foreach (var filePath in filePaths)
            {
                var versionInfo = ExtractVersionInfo(filePath);
                if (versionInfo != null)
                {
                    if(!fileGroups.ContainsKey(versionInfo.BasePattern))
                    {
                        fileGroups[versionInfo.BasePattern] = new List<FileVersionInfo>();
                    }
                    fileGroups[versionInfo.BasePattern].Add(versionInfo);
                }
            }

            // Select the latest version from each group
            var latestVersion = new List<string>();
            foreach (var group in fileGroups.Values)
            {
                var latestFile = group.OrderByDescending(f => f.VersionNumber).First();
                latestVersion.Add(latestFile.FullPath);
            }

            return latestVersion.OrderBy(f => f).ToList();
        }

        /// <summary>
        /// Extracts version information from a filename
        /// </summary>
        /// <param name="filePath">Full file path or filename</param>
        /// <returns>FileVersionInfo object or null if no version pattern found</returns>
        private static FileVersionInfo ExtractVersionInfo(string filePath)
        {
            var fileName = Path.GetFileName(filePath);

            // Pattern to match version: -V followed by digits, before file extension
            // Example: "40XC00-2401-0000_Stn1-Assembly-V02.prt" -> captures "V02"
            var versionPattern = @"^(.+)-V(\d+)(\.[^.]+)$";
            var match = Regex.Match(fileName, versionPattern);

            if (match.Success)
            {
                var basePattern = match.Groups[1].Value; // Everything before -V
                var versionString = match.Groups[2].Value; // Version number
                var extension = match.Groups[3].Value; // File extension

                if (int.TryParse(versionString, out int versionNumber))
                {
                    return new FileVersionInfo
                    {
                        FullPath = filePath,
                        BasePattern = basePattern,
                        VersionNumber = versionNumber,
                        Extension = extension
                    };
                }
            }

            return null;
        }

        /// <summary>
        /// Internal class to hold file version information
        /// </summary>
        private class FileVersionInfo
        {
            public string FullPath { get; set; }
            public string BasePattern { get; set; }
            public int VersionNumber { get; set; }
            public string Extension { get; set; }
        }
    }
}
