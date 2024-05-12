namespace Eris.Rabbit.Store.Domain.Entities;

public class Purchase
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

}