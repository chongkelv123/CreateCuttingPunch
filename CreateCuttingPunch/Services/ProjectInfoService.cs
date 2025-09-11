using CreateCuttingPunch.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Services
{
    public static class ProjectInfoService
    {
        const string DIRECTORY = "D:/NXCUSTOM/temp";
        const string PROJ_INFO_FILENAME = "project_info.data";

        public static ProjectInfoModel ReadFromFile()
        {
            string fullPathFilename = Path.Combine(DIRECTORY, PROJ_INFO_FILENAME);
            if (!File.Exists(fullPathFilename))
            {
                throw new FileNotFoundException(fullPathFilename);
            }

            Dictionary<string, string> result = new Dictionary<string, string>();
            string[] keys = { "Model", "Part", "CodePrefix", "Designer" };

            try
            {
                using (StreamReader reader = new StreamReader(fullPathFilename))
                {
                    string value;
                    keys.ToList().ForEach(key =>
                    {
                        value = reader.ReadLine();
                        result.Add(key, value);
                    });
                }
            }
            catch (FileNotFoundException ex)
            {
                string message = $"File not found: {ex.Message}";
                string title = "Error file not found";
                NXDrawing.ShowMessageBox(title, message, NXOpen.NXMessageBox.DialogType.Error);
            }

            return new ProjectInfoModel
            {
                Model = result["Model"],
                Part = result["Part"],
                CodePrefix = result["CodePrefix"],
                Designer = result["Designer"]
            };
        }

        public static void WriteToFile(List<string> projectInfoToText)
        {
            try
            {
                if(!Directory.Exists(DIRECTORY))
                    Directory.CreateDirectory(DIRECTORY);

                string fullPathFileName = Path.Combine(DIRECTORY, PROJ_INFO_FILENAME);

                File.WriteAllLines(fullPathFileName, projectInfoToText);

                NXDrawing.ShowMessageBox(
                    "✅ Project info successfully saved.",
                    "Success",
                    NXOpen.NXMessageBox.DialogType.Information);
            }
            catch (IOException ex)
            {
                string message = $"Error writing to file: {ex.Message}";
                string title = "Error writing file";
                NXDrawing.ShowMessageBox(title, message, NXOpen.NXMessageBox.DialogType.Error);
            }
        }
    }
}
