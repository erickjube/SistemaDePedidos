namespace SistemaDePedidos.Domain.Entities;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = true;

    public ICollection<Product> Products { get; private set; } = new List<Product>();

    public Category() { }

    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name), "Nome da categoria não pode ser nulo ou vazio.");
        Name = name;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name), "Nome da categoria não pode ser nulo ou vazio.");
        Name = name;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}
