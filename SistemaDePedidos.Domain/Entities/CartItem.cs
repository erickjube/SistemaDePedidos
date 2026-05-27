namespace SistemaDePedidos.Domain.Entities;

public class CartItem
{
    public int Id { get; private set; }

    public int CartId { get; private set; }
    public Cart Cart { get; private set; } = null!;

    public int ProductId { get; private set; }
    public Product Product { get; private set; } = null!;

    public int Quantity { get; private set; } 

    private CartItem() { }
    public CartItem(int productId, int quantity)
    {
        if (productId <= 0) throw new ArgumentException("Id do produto é obrigatório.", nameof(productId));
        if (quantity <= 0) throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(quantity));
        ProductId = productId;
        Quantity = quantity;
    }

    public void AddQuantity(int amount)
    {
        if (amount <= 0) throw new ArgumentException("Quantidade a ser aumentada deve ser maior que zero.", nameof(amount));
        Quantity += amount;
    }
    public void RemoveQuantity(int amount)
    {
        if (amount <= 0) throw new ArgumentException("Quantidade a ser diminuída deve ser maior que zero.", nameof(amount));
        Quantity -= amount;
    }
 }
