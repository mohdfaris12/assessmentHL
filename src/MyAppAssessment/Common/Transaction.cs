using MyAppAssessment.Model;

namespace MyAppAssessment.Common;

public static class Transaction
{
    public static (bool IsValid, string? ErrorMessage) ValidatePurchase(Product product, int requestedQuantity)
    {
        if (product == null)
            return (false, "Product not found");

        if (requestedQuantity <= 0)
            return (false, "Quantity must be greater than 0");

        if (product.Quantity < requestedQuantity)
            return (false, "Insufficient stock");

        return (true, null);
    }
    public static decimal CalculateTotalPrice(Product product, int quantity)
    {
        return product.Price * quantity;
    }
    public static void DeductStock(Product product, int quantity)
    {
        product.Quantity -= quantity;
        product.UpdatedAt = DateTime.UtcNow;
    }
    public static string GenerateTransactionRef()
    {
        return Guid.NewGuid().ToString("N");
    }
    public static string BuildAuditMessage(Customer customer, Product product, int quantity)
    {
        return $"{customer.Name} purchased {quantity} x {product.Name}";
    }
}