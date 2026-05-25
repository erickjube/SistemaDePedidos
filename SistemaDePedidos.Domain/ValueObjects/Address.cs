using System.Text.RegularExpressions;

namespace SistemaDePedidos.Domain.ValueObjects;

public class Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string CEP { get; }

    public Address(string street, string city, string state, string cep)
    {
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Rua não pode estar vazia.", nameof(street));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("Cidade não pode estar vazia.", nameof(city));
        if (string.IsNullOrWhiteSpace(state)) throw new ArgumentException("Estado não pode estar vazio.", nameof(state));
        if (string.IsNullOrWhiteSpace(cep)) throw new ArgumentException("CEP não pode estar vazio.", nameof(cep));
        if (!ValidCEP(cep)) throw new ArgumentException("CEP inválido.", nameof(cep));
        Street = street;
        City = city;
        State = state;
        CEP = cep;
    }

    private bool ValidCEP(string cep)
    {
        // Aceita "12345-678" ou "12345678"
        string pattern = @"^\d{5}-\d{3}$|^\d{8}$";

        return Regex.IsMatch(cep, pattern);
    }
}
