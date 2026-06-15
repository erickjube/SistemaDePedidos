using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Domain.Entities;
using SistemaDePedidos.Infrastructure.Data;
using SistemaDePedidos.Infrastructure.Repositories.Interfaces;

namespace SistemaDePedidos.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int categoryId)
    {
        return await _context.Categories.FindAsync(categoryId);
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }
}
