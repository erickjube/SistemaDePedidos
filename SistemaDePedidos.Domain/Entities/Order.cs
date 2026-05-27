namespace SistemaDePedidos.Domain.Entities;

public class Order
{
    public int Id { get; private set; }

    public int ClientId { get; private set; }
    public ClientProfile Client { get; private set; } = null!;

    public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();

    public decimal TotalAmount => Items.Sum(i => i.Subtotal);
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Order() { }

    public Order(int clientId)
    {
        if (clientId <= 0) throw new ArgumentException("Id do cliente é obrigatório.", nameof(clientId));
        ClientId = clientId;
        CreatedAt = DateTime.UtcNow;
    }
}
