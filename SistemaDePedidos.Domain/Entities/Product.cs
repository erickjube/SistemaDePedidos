namespace SistemaDePedidos.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public int CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;

    public int SellerProfileId { get; private set; }
    public SellerProfile SellerProfile { get; private set; } = null!;

    public Product() { }

    public Product(string name, string description, decimal price, int categoryId, int sellerProfileId)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nome do produto não pode ser nulo ou vazio.", nameof(name));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Descrição do produto não pode ser nula ou vazia.", nameof(description));
        if (price <= 0) throw new ArgumentException("Preço do produto deve ser maior que zero.", nameof(price));
        if (categoryId <= 0) throw new ArgumentException("Categoria do produto é obrigatória.", nameof(categoryId));
        if (sellerProfileId <= 0) throw new ArgumentException("Perfil do vendedor do produto é obrigatório.", nameof(sellerProfileId));
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
        SellerProfileId = sellerProfileId;
    }

    public void Update(string name, string description, decimal price, int categoryId)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nome do produto não pode ser nulo ou vazio.", nameof(name));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Descrição do produto não pode ser nula ou vazia.", nameof(description));
        if (price <= 0) throw new ArgumentException("Preço do produto deve ser maior que zero.", nameof(price));
        if (categoryId <= 0) throw new ArgumentException("Categoria do produto é obrigatória.", nameof(categoryId));
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }
}
