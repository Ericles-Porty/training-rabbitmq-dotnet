namespace Domain.Entities;

public class Purchase
{
    public int Id { get; }
    public int Quantity { get; }
    public decimal Total { get; }
    public DateTime CreatedAt { get; }
    public int ProductId { get; }

    public Purchase(int productId, int quantity, decimal total)
    {
        ProductId = productId;
        Quantity = quantity;
        Total = total;
        CreatedAt = DateTime.UtcNow;
    }
}