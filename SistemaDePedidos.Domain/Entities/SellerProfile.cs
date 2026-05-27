using SistemaDePedidos.Domain.ValueObjects;

namespace SistemaDePedidos.Domain.Entities;

public class SellerProfile 
{
    public int Id { get; private set; }

    public int UserId { get; private set; }
    public User User { get; private set; }

    public ICollection<Product> Products { get; private set; } = new List<Product>();
    public SellerProfile() { }

    public SellerProfile(int userId)
    {
        if (userId <= 0) throw new ArgumentException("Id do usuário é obrigatório.", nameof(userId));
        UserId = userId;
    }
}
