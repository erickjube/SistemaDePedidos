using SistemaDePedidos.Domain.ValueObjects;

namespace SistemaDePedidos.Domain.Entities;

public abstract class User
{
    public int Id { get; protected set; }
    public string Name { get; protected set; } = string.Empty;
    public CPF CPF { get; protected set; } 
    public Email Email { get; protected set; }
    public Phone Phone { get; protected set; }
    public string PasswordHash { get; protected set; } = string.Empty;
    public DateOnly BirthDate { get; protected set; } 

    public Address Address { get; protected set; }

    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

    protected User() { }
    protected User(string name, CPF cpf, Email email, string passwordHash, Phone phone, DateOnly birthDate,Address address)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nome não pode ser nulo.", nameof(name));
        if (cpf == null)  throw new ArgumentException("CPF não pode ser nulo.", nameof(cpf));
        if (email == null) throw new ArgumentException("Email não pode ser nulo.", nameof(email));
        if (phone == null) throw new ArgumentException("Telefone não pode ser nulo", nameof(phone));
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentException("Senha não pode estar vazia.", nameof(passwordHash));
        if (birthDate == default) throw new ArgumentException("Data de nascimento é obrigatória.", nameof(birthDate));
        if (birthDate > DateOnly.FromDateTime(DateTime.Now)) throw new ArgumentException("Data de nascimento não pode ser no futuro.", nameof(birthDate));
        if (address == null) throw new ArgumentNullException("Endereço não pode ser nulo.", nameof(address));

        Name = name;
        CPF = cpf;
        Email = email;
        PasswordHash = passwordHash;
        Phone = phone;
        Address = address;
        BirthDate = birthDate;
    }
    
    public void Update(string name, Email email, Phone phone, DateOnly birthDate, Address address)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nome não pode ser nulo.", nameof(name));
        if (email == null) throw new ArgumentException("Email não pode ser nulo.", nameof(email));
        if (phone == null) throw new ArgumentException("Telefone não pode estar vazio.", nameof(phone));
        if (birthDate == default) throw new ArgumentException("Data de nascimento é obrigatória.", nameof(birthDate));
        if (birthDate > DateOnly.FromDateTime(DateTime.Now)) throw new ArgumentException("Data de nascimento não pode ser no futuro.", nameof(birthDate));
        if (address == null) throw new ArgumentNullException("Endereço não pode ser nulo.", nameof(address));
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        BirthDate = birthDate;
    }
}
