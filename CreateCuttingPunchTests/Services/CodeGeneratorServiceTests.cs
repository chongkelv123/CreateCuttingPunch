using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreateCuttingPunch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateCuttingPunch.Services;
using CreateCuttingPunch.Constants;

namespace CreateCuttingPunch.Services.Tests
{
    [TestClass()]
    public class CodeGeneratorServiceTests
    {
        [TestMethod()]
        public void AskNextRunningNumberTest()
        {
            // Arrange
            var type = ToolingStructureType.INSERT;
            var stationNumber = 1;
            var dirPath = @"C:\CreateFolder\Testing-Tooling-Structure\CSRS400_TEST";
            var codePrefix = "40XC00-2401-";
            var expected = "0115";

            // Act
            CodeGeneratorService codeGeneratorService = new CodeGeneratorService();

            var actual = CodeGeneratorService.AskNextRunningNumber(type, dirPath, codePrefix, stationNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GenerateDrawingCodeTest()
        {
            // Arrange
            var type = ToolingStructureType.INSERT;
            var stationNumber = 1;
            var dirPath = @"C:\CreateFolder\Testing-Tooling-Structure\CSRS400_TEST";
            var codePrefix = "40XC00-2401-";
            var expected = "40XC00-2401-0115";

            // Act
            CodeGeneratorService codeGeneratorService = new CodeGeneratorService();

            var actual = CodeGeneratorService.GenerateDrawingCode(type, dirPath, codePrefix, stationNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GenerateFolderCodeTest()
        {
            // Arrange
            var type = ToolingStructureType.INSERT;
            var stationNumber = 1;
            var dirPath = @"C:\CreateFolder\Testing-Tooling-Structure\CSRS400_TEST";
            var codePrefix = "40XC00-2401-";
            var expected = "40XC00-2401-0115_CUTTING_PUNCH";
            var itemName = "Cutting Punch";

            // Act
            CodeGeneratorService codeGeneratorService = new CodeGeneratorService();

            var actual = CodeGeneratorService.GenerateFolderCode(type, dirPath, codePrefix, itemName, stationNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GenerateFileNameTest()
        {
            // Arrange
            var type = ToolingStructureType.INSERT;
            var stationNumber = 1;
            var dirPath = @"C:\CreateFolder\Testing-Tooling-Structure\CSRS400_TEST";
            var codePrefix = "40XC00-2401-";
            var expected = "40XC00-2401-0115_CUTTING_PUNCH-V00";
            var itemName = "Cutting Punch";

            // Act
            CodeGeneratorService codeGeneratorService = new CodeGeneratorService();

            var actual = CodeGeneratorService.GenerateFileName(type, dirPath, codePrefix, itemName, stationNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}