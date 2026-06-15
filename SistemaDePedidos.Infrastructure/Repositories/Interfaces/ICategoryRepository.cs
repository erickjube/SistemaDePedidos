using SistemaDePedidos.Domain.Entities;

namespace SistemaDePedidos.Infrastructure.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int categoryId);
    Task AddAsync(Category category);
}
