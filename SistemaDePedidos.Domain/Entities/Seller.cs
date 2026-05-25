using SistemaDePedidos.Domain.ValueObjects;

namespace SistemaDePedidos.Domain.Entities;

public class Seller : User
{
    public ICollection<Product> Products { get; private set; } = new List<Product>();
    public Seller() { }

    public Seller(string name, CPF cpf, Email email, string passwordHash, Phone phone, DateOnly birthDate, Address address)
        : base(name, cpf, email, passwordHash, phone, birthDate, address)
    {
    }
}
