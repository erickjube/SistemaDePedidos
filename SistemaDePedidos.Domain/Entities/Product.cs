namespace SistemaDePedidos.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public int CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;

    public int SellerId { get; private set; }
    public SellerProfile Seller { get; private set; } = null!;

    public Product() { }

    public Product(string name, decimal price, int categoryId, int sellerId)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nome do produto não pode ser nulo ou vazio.", nameof(name));
        if (price <= 0) throw new ArgumentException("Preço do produto deve ser maior que zero.", nameof(price));
        if (categoryId <= 0) throw new ArgumentException("Categoria do produto é obrigatória.", nameof(categoryId));
        if (sellerId <= 0) throw new ArgumentException("Vendedor do produto é obrigatório.", nameof(sellerId));
        Name = name;
        Price = price;
        CategoryId = categoryId;
        SellerId = sellerId;
    }

    public void Update(string name, decimal price, int categoryId)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nome do produto não pode ser nulo ou vazio.", nameof(name));
        if (price <= 0) throw new ArgumentException("Preço do produto deve ser maior que zero.", nameof(price));
        if (categoryId <= 0) throw new ArgumentException("Categoria do produto é obrigatória.", nameof(categoryId));
        Name = name;
        Price = price;
        CategoryId = categoryId;
    }
}
