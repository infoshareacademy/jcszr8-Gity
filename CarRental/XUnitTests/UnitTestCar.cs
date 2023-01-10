using CarRental.ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTests;
public class ReadCarYearTests
{
    [Fact]
    public void ReadCarYear_ValidYear_ReturnsYear()
    {
        // Arrange
        int expectedYear = 2010;
        string input = expectedYear.ToString();
        StringReader reader = new(input);
        Console.SetIn(reader);

        // Act
        int actualYear = ConsoleCarParamsReader.ReadCarYear();

        // Assert
        Assert.Equal(expectedYear, actualYear);
    }

    [Fact]
    public void ReadCarYear_InvalidYear_PromptsForInputAgain()
    {
        // Arrange
        int expectedYear = 2010;
        string input = "invalid\n" + expectedYear;
        StringReader reader = new(input);
        Console.SetIn(reader);

        // Act
        int actualYear = ConsoleCarParamsReader.ReadCarYear();

        // Assert
        Assert.Equal(expectedYear, actualYear);
    }

    [Fact]
    public void ReadCarYear_YearBefore2000_PromptsForInputAgain()
    {
        // Arrange
        int expectedYear = 2010;
        string input = "1999\n" + expectedYear;
        StringReader reader = new(input);
        Console.SetIn(reader);

        // Act
        int actualYear = ConsoleCarParamsReader.ReadCarYear();

        // Assert
        Assert.Equal(expectedYear, actualYear);
    }

    [Fact]
    public void ReadCarYear_YearAfterCurrentYear_PromptsForInputAgain()
    {
        // Arrange
        int expectedYear = 2010;
        string input = (DateTime.Now.Year + 1).ToString() + "\n" + expectedYear;
        StringReader reader = new(input);
        Console.SetIn(reader);

        // Act
        int actualYear = ConsoleCarParamsReader.ReadCarYear();

        // Assert
        Assert.Equal(expectedYear, actualYear);
    }
}
