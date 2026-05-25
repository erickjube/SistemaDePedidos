using SistemaDePedidos.Domain.ValueObjects;

namespace SistemaDePedidos.Domain.Entities;

public class Client : User
{
    public Cart? Cart { get; private set; }
    public ICollection<Order> Orders { get; private set; } = new List<Order>();

    public Client() { }
    public Client(string name, CPF cpf, Email email, string passwordHash, Phone phone, DateOnly birthDate, Address address)
        : base(name, cpf, email, passwordHash, phone, birthDate, address)
    {
    }
}
