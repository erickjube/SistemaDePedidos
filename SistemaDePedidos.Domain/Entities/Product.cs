using SistemaDePedidos.Domain.ENUMs;

namespace SistemaDePedidos.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public int StockQuantity { get; private set; }
    public ProductStatus Status { get; private set; } = ProductStatus.Active;

    public int CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;

    public int SellerProfileId { get; private set; }
    public SellerProfile SellerProfile { get; private set; } = null!;

    public Product() { }

    public Product(string name, string description, decimal price, int categoryId, int sellerProfileId, int stockQuantity)
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
        StockQuantity = stockQuantity;
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

    public void DecreaseStock(int quantity)
    {
        if (quantity > StockQuantity)
            throw new ArgumentException("Quantidade insuficiente em estoque.", nameof(quantity));

        StockQuantity -= quantity;

        if (StockQuantity == 0) Status = ProductStatus.OutOfStock;
    }

    public void IncreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(quantity));

        StockQuantity += quantity;

        if (Status == ProductStatus.OutOfStock) Status = ProductStatus.Active;
    }

    public void TurnInactive()
    {
        Status = ProductStatus.Inactive;
    }
}
