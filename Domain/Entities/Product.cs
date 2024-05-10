namespace Domain.Entities;

public class Product
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public string? Description { get; }
    public int Stock { get; }
    public bool IsFeatured { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }


    public Product(string name, decimal price, string? description, int stock, bool isFeatured)
    {
        Name = name;
        Price = price;
        Description = description ?? string.Empty;
        Stock = stock;
        IsFeatured = isFeatured;
        CreatedAt = DateTime.UtcNow;
    }
}