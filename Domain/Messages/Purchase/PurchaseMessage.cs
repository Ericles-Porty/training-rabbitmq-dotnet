namespace Eris.Rabbit.Store.Domain.Messages.Purchase;

public class PurchaseMessage
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
}