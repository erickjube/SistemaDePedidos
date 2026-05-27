namespace SistemaDePedidos.Domain.Entities;

public class Cart
{
    public int Id { get; private set; }

    public int ClientProfileId { get; private set; }
    public ClientProfile ClientProfile { get; private set; }

    public decimal TotalAmount => Items.Sum(item => item.Product.Price * item.Quantity);
    public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();

    public Cart() { }
     
    public Cart(int clientProfileId)
    {
        if (clientProfileId <= 0) throw new ArgumentException("Id do cliente é obrigatório.", nameof(clientProfileId));
        ClientProfileId = clientProfileId;
    }
}
