namespace SistemaDePedidos.Domain.ValueObjects;

public class Email
{
    public string Value { get; }
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Email não pode estar vazio.", nameof(value));
        if (!ValidateEmail(value)) throw new ArgumentException("Email inválido.", nameof(value));
        Value = value;
    }
    private static bool ValidateEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
