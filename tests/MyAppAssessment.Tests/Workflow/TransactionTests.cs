using MyAppAssessment.Common;
using MyAppAssessment.Model;

namespace MyAppAssessment.Tests.Workflow;

public class TransactionTests
{
    [Fact]
    public void ValidatePurchase_InsufficientStock_IsInvalid()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 1000,
            Quantity = 5
        };

        int requestedQuantity = 10;

        // Act
        var (isValid, error) = Transaction.ValidatePurchase(product, requestedQuantity);

        // Assert
        Assert.False(isValid);
        Assert.Equal("Insufficient stock", error);
    }

    [Fact]
    public void ValidatePurchase_SufficientStock_IsValid()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 1000,
            Quantity = 10
        };

        int requestedQuantity = 5;

        var (isValid, error) = Transaction.ValidatePurchase(product, requestedQuantity);

        Assert.True(isValid);
        Assert.Null(error);
    }

    [Fact]
    public void ValidatePurchase_ExactStock_IsValid()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 1000,
            Quantity = 5
        };

        int requestedQuantity = 5;

        var (isValid, error) = Transaction.ValidatePurchase(product, requestedQuantity);

        Assert.True(isValid);
        Assert.Null(error);
    }

    [Fact]
    public void ValidatePurchase_ZeroQuantity_IsInvalid()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 1000,
            Quantity = 10
        };

        var (isValid, error) = Transaction.ValidatePurchase(product, 0);

        Assert.False(isValid);
        Assert.Equal("Quantity must be greater than 0", error);
    }
}