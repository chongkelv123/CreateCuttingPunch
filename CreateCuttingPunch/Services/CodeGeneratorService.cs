using CreateCuttingPunch.Constants;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Services
{
    public class CodeGeneratorService
    {
        private ToolingStructureType type;
        private int stationNumber;
        private string dirPath;
        private string codePrefix;

        public CodeGeneratorService() { }
        public CodeGeneratorService(ToolingStructureType type, int stationNumber, string dirPath, string codePrefix)
        {
            this.type = type;
            this.stationNumber = stationNumber;
            this.dirPath = dirPath;
            this.codePrefix = codePrefix;
        }

        public static string GenerateDrawingCode(ToolingStructureType type, string dirPath, string codePrefix, int stnNumber = 0)
        {
            return $"{codePrefix}{AskNextRunningNumber(type, dirPath, codePrefix, stnNumber)}";
        }

        public string AskDrawingCode()
        {
            return stationNumber > 0
                ? GenerateDrawingCode(type, dirPath, codePrefix, stationNumber)
                : GenerateDrawingCode(type, dirPath, codePrefix);
        }

        public static string GetDrawingCode(string input)
        {
            string[] segments = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length < 3)
                throw new ArgumentException("Input string is not in a valid drawing code format.");

            string drawingCodeCandidate = segments[2];
            int delimiterIndex = drawingCodeCandidate.IndexOfAny(new[] { '_', '-' });

            string drawingCode = delimiterIndex > 0
                ? drawingCodeCandidate.Substring(0, delimiterIndex)
                : drawingCodeCandidate;

            if (IsValidDrawingCode(drawingCode))
                return drawingCode;

            throw new ArgumentException("Extracted drawing code is invalid. Expected a 4-digit number.");
        }

        private static bool IsValidDrawingCode(string code)
        {
            return code.Length == 4 && code.All(char.IsDigit);
        }

        public static string AskNextRunningNumber(ToolingStructureType type, string dirPath, string codePrefix, int stnNumber = 0)
        {
            string searchPattern = "*.prt";
            var files = Directory.GetFiles(dirPath, searchPattern);
            List<int> runningNumbers = new List<int>();

            string stationPart = stnNumber.ToString("D2");
            int defaultTypeCode = int.Parse(GetDrawingCodeFromType(type, stnNumber).Substring(2));

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);

                // 1) Must start with prefix + station  
                if (!fileName.StartsWith(codePrefix + stationPart))
                    continue;

                // 2) Extract the 4-digit drawing code  
                string codePart = GetDrawingCode(fileName);
                if (codePart.Length != 4 || !codePart.StartsWith(stationPart))
                    continue;

                // 3) Parse last two digits as runningNo  
                if (!int.TryParse(codePart.Substring(2), out int runningNo))
                    continue;

                // 4) Apply only the ACCESSORIES filter  
                if (type == ToolingStructureType.ACCESSORIES || type == ToolingStructureType.INSERT)
                {
                    if (runningNo < defaultTypeCode)
                        continue;
                }

                if (
                    type == ToolingStructureType.ASSEMBLY ||
                    type == ToolingStructureType.UPPER_PAD_SPACER ||
                    type == ToolingStructureType.UPPER_PAD ||
                    type == ToolingStructureType.PUNCH_HOLDER ||
                    type == ToolingStructureType.BOTTOMING_PLATE ||
                    type == ToolingStructureType.STRIPPER_PLATE ||
                    type == ToolingStructureType.DIE_PLATE ||
                    type == ToolingStructureType.LOWER_PAD ||
                    type == ToolingStructureType.LOWER_PAD_SPACER
                    )
                {
                    continue;
                }

                // Include everything else
                runningNumbers.Add(runningNo);

            }

            if (runningNumbers.Count > 0)
            {
                int nextRunningNo = runningNumbers.Max() + 1;
                return stationPart + nextRunningNo.ToString("D2");
            }

            return GetDrawingCodeFromType(type, stnNumber);
        }

        public static string GetDrawingCodeFromType(ToolingStructureType type, int stnNumber = 0)
        {
            // Mapping of ToolingStructureType to its fixed type code
            var typeCodeMap = new Dictionary<ToolingStructureType, int>
            {
                { ToolingStructureType.SHOE, 1},
                { ToolingStructureType.ACCESSORIES, 30},
                { ToolingStructureType.UPPER_PAD_SPACER, 1},
                { ToolingStructureType.UPPER_PAD, 2},
                { ToolingStructureType.PUNCH_HOLDER, 3},
                { ToolingStructureType.BOTTOMING_PLATE, 4},
                { ToolingStructureType.STRIPPER_PLATE, 5},
                { ToolingStructureType.DIE_PLATE, 6},
                { ToolingStructureType.LOWER_PAD, 7},
                { ToolingStructureType.LOWER_PAD_SPACER, 8},
                { ToolingStructureType.INSERT, 11},
                { ToolingStructureType.ASSEMBLY, 0}
            };
            if (!typeCodeMap.TryGetValue(type, out int typeCode))
            {
                throw new ArgumentException($"Unsupported ToolingStructureType: {type}");
            }
            string stationPart = stnNumber.ToString("D2");
            string typePart = typeCode.ToString("D2");
            return stationPart + typePart;
        }

        public static string GenerateFileName(ToolingStructureType type, string dirPath, string codePrefix, string itemName, int stnNumber = 0)
        {
            string folderCode = GenerateFolderCode(type, dirPath, codePrefix, itemName, stnNumber);
            string baseName = $"{folderCode}-V00";
            string version = AskVersion(baseName, dirPath);
            return $"{folderCode}{version}";
        }

        public static string GenerateFolderCode(ToolingStructureType type, string dirPath, string codePrefix, string itemName, int stnNumber = 0)
        {
            string drawingCode = GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);
            itemName = ToUpperCase(ReplaceSpacesWithUnderscore(itemName));
            return $"{drawingCode}_{itemName}";
        }

        public static string ReplaceSpacesWithUnderscore(string input)
        {
            return input.Trim().Replace(" ", "_");
        }

        public static string ToUpperCase(string input)
        {
            return input.ToUpper();
        }

        public static string AskVersion(string baseName, string dirPath)
        {
            string searchPattern = "*.prt";
            string[] files = System.IO.Directory.GetFiles(dirPath, searchPattern);
            List<int> existingVersions = new List<int>();

            foreach (string file in files)
            {
                string fileNameWidthExtension = Path.GetFileNameWithoutExtension(file);
                if (fileNameWidthExtension.StartsWith(baseName + "-V"))
                {
                    string versionPart = fileNameWidthExtension.Substring(baseName.Length + 2); // Skip baseName and "-V"
                    if (int.TryParse(versionPart, out int version))
                    {
                        existingVersions.Add(version);
                    }
                }
            }
            int nextVersion = 0;
            if (existingVersions.Count > 0)
            {
                nextVersion = existingVersions.Max() + 1;
            }
            return $"-V{nextVersion.ToString("D2")}";
        }

        public static int StationNumberFromFileName(string asmFileName)
        {            
            Regex regex = new Regex(@"Stn(\d+)");
            Match match = regex.Match(asmFileName);
            string digit;
            if (!match.Success)
            {
                return -1;
            }
            digit = match.Groups[1].Value;

            int.TryParse(digit, out int result);
            return result;
        }
    }
}
