namespace SistemaDePedidos.Domain.ValueObjects;

public class Phone
{
    public string Value { get; }
    public Phone(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Telefone não pode estar vazio.", nameof(value));
        if (!ValidatePhone(value)) throw new ArgumentException("Telefone inválido.", nameof(value));
        Value = value;
    }
    private static bool ValidatePhone(string phone)
    {
        phone = new string(phone.Where(char.IsDigit).ToArray());

        return phone.Length == 10 || phone.Length == 11;
    }
}
