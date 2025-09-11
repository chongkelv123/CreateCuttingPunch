using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreateCuttingPunch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCuttingPunch.Services.Tests
{
    [TestClass()]
    public class FileManageServiceTests
    {
        [TestMethod()]
        public void GetAssemblyFilesTest_SpecificExample_GetAllAssemblyFiles_ReturnsCorrectFilteredList()
        {
            // Arrange
            var path = "C:\\CreateFolder\\Testing-Tooling-Structure\\CSRS400_TEST";

            var expected = new List<string>
            {
                "40XC00-2401-0000_MainToolAssembly-V00.prt",                
                "40XC00-2401-0000_Stn1-Assembly-V02.prt",
                "40XC00-2401-0000_Stn10-Assembly-V00.prt",
                "40XC00-2401-0000_Stn11-Assembly-V00.prt",                
                "40XC00-2401-0000_Stn12-Assembly-V01.prt",
                "40XC00-2401-0000_Stn13-Asm-V05.prt",
                "40XC00-2401-0000_Stn2-Assembly-V00.prt",
                "40XC00-2401-0000_Stn3-Assembly-V00.prt",
                "40XC00-2401-0000_Stn4-Assembly-V00.prt",
                "40XC00-2401-0000_Stn5-Assembly-V00.prt",
                "40XC00-2401-0000_Stn6-Assembly-V00.prt",
                "40XC00-2401-0000_Stn7-Assembly-V00.prt",
                "40XC00-2401-0000_Stn8-Assembly-V00.prt",
                "40XC00-2401-0000_Stn9-Assembly-V00.prt",
            };

            // Act
            var result = FileManageService.GetAssemblyFiles(path);

            // Assert
            Assert.AreEqual(expected.Count, result.Count, "Filtered list should have correct count");            
        }
    }
}