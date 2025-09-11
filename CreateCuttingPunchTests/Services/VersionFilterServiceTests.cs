using CreateCuttingPunch.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static CreateCuttingPunch.Constants.Const;

namespace CreateCuttingPunch.Services.Tests
{
    [TestClass()]
    public class VersionFilterServiceTests
    {
        [TestMethod]
        public void FilterLatestVersions_BasicVersionFiltering_ReturnsLatestVersions()
        {
            // Arrange
            var input = new List<string>
            {
                "TestFile-V00.prt",
                "TestFile-V01.prt",
                "TestFile-V02.prt",
                "AnotherFile-V00.prt"
            };

            var expected = new List<string>
            {
                "AnotherFile-V00.prt",
                "TestFile-V02.prt"
            };

            // Act
            var result = VersionFilterService.FilterLatestVersions(input);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }        

        [TestMethod]
        public void FilterLatestVersions_SpecificExample_ReturnsCorrectFilteredList()
        {
            // Arrange
            var input = new List<string>
            {
                "40XC00-2401-0000_MainToolAssembly-V00.prt",
                "40XC00-2401-0000_Stn1-Assembly-V00.prt",
                "40XC00-2401-0000_Stn1-Assembly-V02.prt",
                "40XC00-2401-0000_Stn10-Assembly-V00.prt",
                "40XC00-2401-0000_Stn11-Assembly-V00.prt",
                "40XC00-2401-0000_Stn12-Assembly-V00.prt",
                "40XC00-2401-0000_Stn12-Assembly-V01.prt",
                "40XC00-2401-0000_Stn2-Assembly-V00.prt",
                "40XC00-2401-0000_Stn3-Assembly-V00.prt",
                "40XC00-2401-0000_Stn4-Assembly-V00.prt",
                "40XC00-2401-0000_Stn5-Asm-V00.prt",
                "40XC00-2401-0000_Stn5-Asm-V05.prt",
                "40XC00-2401-0000_Stn6-Assembly-V00.prt",
                "40XC00-2401-0000_Stn7-Assembly-V00.prt",
                "40XC00-2401-0000_Stn8-Assembly-V00.prt",
                "40XC00-2401-0000_Stn9-Assembly-V00.prt"
            };

            var expected = new List<string>
            {
                "40XC00-2401-0000_MainToolAssembly-V00.prt",
                "40XC00-2401-0000_Stn1-Assembly-V02.prt",
                "40XC00-2401-0000_Stn10-Assembly-V00.prt",
                "40XC00-2401-0000_Stn11-Assembly-V00.prt",
                "40XC00-2401-0000_Stn12-Assembly-V01.prt",
                "40XC00-2401-0000_Stn2-Assembly-V00.prt",
                "40XC00-2401-0000_Stn3-Assembly-V00.prt",
                "40XC00-2401-0000_Stn4-Assembly-V00.prt",
                "40XC00-2401-0000_Stn5-Asm-V05.prt",
                "40XC00-2401-0000_Stn6-Assembly-V00.prt",
                "40XC00-2401-0000_Stn7-Assembly-V00.prt",
                "40XC00-2401-0000_Stn8-Assembly-V00.prt",
                "40XC00-2401-0000_Stn9-Assembly-V00.prt"
            };

            // Act
            var result = VersionFilterService.FilterLatestVersions(input);

            // Assert
            Assert.AreEqual(expected.Count, result.Count, "Filtered list should have correct count");
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void FilterLatestVersions_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var input = new List<string>();

            // Act
            var result = VersionFilterService.FilterLatestVersions(input);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FilterLatestVersions_NullInput_ReturnsEmptyList()
        {
            // Arrange
            List<string> input = null;

            // Act
            var result = VersionFilterService.FilterLatestVersions(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FilterLatestVersions_FilesWithoutVersionPattern_ReturnsEmptyList()
        {
            // Arrange
            var input = new List<string>
            {
                "NoVersionFile.prt",
                "AnotherFile.prt",
                "SomeFile.dwg"
            };

            // Act
            var result = VersionFilterService.FilterLatestVersions(input);

            // Assert
            Assert.AreEqual(0, result.Count, "Files without version pattern should be filtered out");
        }

        [TestMethod]
        public void FilterLatestVersions_HighVersionNumbers_HandlesCorrectly()
        {
            // Arrange
            var input = new List<string>
            {
                "TestFile-V05.prt",
                "TestFile-V10.prt",
                "TestFile-V02.prt",
                "TestFile-V100.prt"
            };

            var expected = new List<string>
            {
                "TestFile-V100.prt"
            };

            // Act
            var result = VersionFilterService.FilterLatestVersions(input);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void FilterLatestVersions_ComplexFileNames_WorksCorrectly()
        {
            // Arrange
            var input = new List<string>
            {
                "ABC-123_Complex-File-Name_With-Dashes-V00.prt",
                "ABC-123_Complex-File-Name_With-Dashes-V03.prt",
                "ABC-123_Complex-File-Name_With-Dashes-V01.prt"
            };

            var expected = new List<string>
            {
                "ABC-123_Complex-File-Name_With-Dashes-V03.prt"
            };

            // Act
            var result = VersionFilterService.FilterLatestVersions(input);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}