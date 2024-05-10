namespace Eris.Rabbit.Store.Domain.Entities;

public class Product
{
    public int Id { get; }
    public string? Name { get; }
    public decimal Price { get; }
    public string? Description { get; }
    public int Stock { get; }
    public bool IsFeatured { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; } 
    public ICollection<Purchase> Purchases { get; } = new List<Purchase>();

}