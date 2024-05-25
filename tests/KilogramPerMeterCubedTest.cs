using NUnit.Framework;

[TestFixture]
public class KilogramPerMeterCubedTests
{
    [Test]
    public void TestToSI()
    {
        // Arrange
        KilogramPerMeterCubed unit = new KilogramPerMeterCubed(2, 3, 4, 5);

        // Act
        KilogramPerMeterCubed siUnit = unit.ToSI();

        // Assert
        Assert.AreEqual(120, siUnit.Value);
    }

    [Test]
    public void TestParse()
    {
        // Arrange
        string input = "2 kg/m3";

        // Act
        KilogramPerMeterCubed unit = KilogramPerMeterCubed.Parse(input, null);

        // Assert
        Assert.AreEqual(2, unit.Value);
    }

    [Test]
    public void TestTryParse_ValidInput()
    {
        // Arrange
        string input = "3 kg/m3";
        KilogramPerMeterCubed result;

        // Act
        bool success = KilogramPerMeterCubed.TryParse(input, null, out result);

        // Assert
        Assert.IsTrue(success);
        Assert.AreEqual(3, result.Value);
    }

    [Test]
    public void TestTryParse_InvalidInput()
    {
        // Arrange
        string input = "invalid";
        KilogramPerMeterCubed result;

        // Act
        bool success = KilogramPerMeterCubed.TryParse(input, null, out result);

        // Assert
        Assert.IsFalse(success);
        Assert.AreEqual(0, result.Value);
    }

    [Test]
    public void TestAddition()
    {
        // Arrange
        KilogramPerMeterCubed unit1 = new KilogramPerMeterCubed(2, 3, 4, 5);
        KilogramPerMeterCubed unit2 = new KilogramPerMeterCubed(1, 2, 3, 4);

        // Act
        KilogramPerMeterCubed result = unit1 + unit2;

        // Assert
        Assert.AreEqual(120, result.Value);
    }

    [Test]
    public void TestSubtraction()
    {
        // Arrange
        KilogramPerMeterCubed unit1 = new KilogramPerMeterCubed(2, 3, 4, 5);
        KilogramPerMeterCubed unit2 = new KilogramPerMeterCubed(1, 2, 3, 4);

        // Act
        KilogramPerMeterCubed result = unit1 - unit2;

        // Assert
        Assert.AreEqual(0, result.Value);
    }

    [Test]
    public void TestDivision()
    {
        // Arrange
        KilogramPerMeterCubed unit = new KilogramPerMeterCubed(2, 3, 4, 5);
        double divisor = 2;

        // Act
        KilogramPerMeterCubed result = unit / divisor;

        // Assert
        Assert.AreEqual(30, result.Value);
    }

    [Test]
    public void TestMultiplication()
    {
        // Arrange
        KilogramPerMeterCubed unit = new KilogramPerMeterCubed(2, 3, 4, 5);
        double factor = 2;

        // Act
        KilogramPerMeterCubed result = unit * factor;

        // Assert
        Assert.AreEqual(240, result.Value);
    }
}