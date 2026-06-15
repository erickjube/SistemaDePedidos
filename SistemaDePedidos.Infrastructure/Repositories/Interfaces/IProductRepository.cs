using SistemaDePedidos.Domain.Entities;

namespace SistemaDePedidos.Infrastructure.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int productId);
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    Task AddAsync(Product product);
}
