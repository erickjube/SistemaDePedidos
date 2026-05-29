namespace SistemaDePedidos.Domain.Entities;

public class Order
{
    public int Id { get; private set; }

    public int ClientProfileId { get; private set; }
    public ClientProfile ClientProfile { get; private set; } = null!;

    public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();

    public decimal TotalAmount { get; private set; } 
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Order() { }

    public Order(int clientProfileId)
    {
        if (clientProfileId <= 0) throw new ArgumentException("Id do cliente é obrigatório.", nameof(clientProfileId));
        ClientProfileId = clientProfileId;
        CreatedAt = DateTime.UtcNow;
    }
}
