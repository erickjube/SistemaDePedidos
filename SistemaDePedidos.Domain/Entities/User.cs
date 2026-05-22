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

    public DateOnly CreatedAt { get; protected set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    protected User() { }
    protected User(string name, CPF cpf, Email email, string passwordHash, Phone phone, DateOnly birthDate,Address address)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name), "Nome não pode ser nulo.");
        if (cpf == null)  throw new ArgumentException(nameof(cpf), "CPF não pode ser nulo.");
        if (email == null) throw new ArgumentException(nameof(email), "Email não pode ser nulo.");
        if (phone == null) throw new ArgumentException(nameof(phone), "Telefone não pode ser nulo");
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentException(nameof(passwordHash), "Senha não pode estar vazia.");
        if (birthDate == default) throw new ArgumentException(nameof(birthDate), "Data de nascimento é obrigatória.");
        if (birthDate > DateOnly.FromDateTime(DateTime.Now)) throw new ArgumentException(nameof(birthDate), "Data de nascimento não pode ser no futuro.");
        if (address == null) throw new ArgumentNullException(nameof(address), "Endereço não pode ser nulo.");

        Name = name;
        CPF = cpf;
        Email = email;
        PasswordHash = passwordHash;
        Phone = phone;
        Address = address;
        BirthDate = birthDate;
    }
    
    public void UpdateUser(string name, Email email, Phone phone, DateOnly birthDate, Address address)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name), "Nome não pode ser nulo.");
        if (email == null) throw new ArgumentException(nameof(email), "Email não pode ser nulo.");
        if (phone == null) throw new ArgumentException(nameof(phone), "Telefone não pode estar vazio.");
        if (birthDate == default) throw new ArgumentException(nameof(birthDate), "Data de nascimento é obrigatória.");
        if (birthDate > DateOnly.FromDateTime(DateTime.Now)) throw new ArgumentException(nameof(birthDate), "Data de nascimento não pode ser no futuro.");
        if (address == null) throw new ArgumentNullException(nameof(address), "Endereço não pode ser nulo.");
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        BirthDate = birthDate;
    }
}
