using Xunit;
using calcu.Core;

namespace calcu.Tests;

public class CalculateTests
{
    [Fact]
    public void Addition_Returns67()
    {
        var result = Calculate.DoCalculation(60, 7, "+");

        Assert.Equal(67, result);
    }

    [Fact]
    public void Subtraction_Returns21()
    {
        var result = Calculate.DoCalculation(25, 4, "-");

        Assert.Equal(21, result);
    }

    [Fact]
    public void Multiplication_Returns45()
    {
        var result = Calculate.DoCalculation(9, 5, "*");

        Assert.Equal(45, result);
    }

    [Fact]
    public void Division_Returns4()
    {
        var result = Calculate.DoCalculation(20, 5, "/");

        Assert.Equal(4, result);
    }
}