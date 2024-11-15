using Microsoft.EntityFrameworkCore;
using StockOfMachineParts.Data;
using StockOfMachineParts.Models;

namespace StockOfMachineParts.Repositories;

public interface IPartsRepository
{
    Task<List<Parts>> GetPartsAsync();
    Task<Parts> GetPartsAsyncById(int id);
    Task<Parts> AddParts(Parts parts);
    Task<Parts> UpdateParts(int id, Parts parts);
    Task DeleteParts(int id);
}

public class PartsRepository : IPartsRepository
{
    private readonly AppDbContext _context;

    public PartsRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Parts>> GetPartsAsync()
    {
        return await _context.Parts.ToListAsync();
    }

    public async Task<Parts> GetPartsAsyncById(int id)
    {
        var parts = await _context.Parts.FindAsync(id);
        if (parts == null)
        {
            throw new KeyNotFoundException($"Peça com o id {id} não encontrada.");
        }
        return parts;
    }

    public async Task<Parts> AddParts(Parts parts)
    {
        await _context.Parts.AddAsync(parts);
        await _context.SaveChangesAsync();
        return parts;
    }

    public async Task<Parts> UpdateParts(int id, Parts parts)
    {
        var existingParts = await _context.Parts.FirstOrDefaultAsync(p => p.Id == id);
        if (existingParts == null)
        {
            throw new KeyNotFoundException($"Peça com o id {id} não encontrada.");
        }

        existingParts.SetPartsName(parts.PartsName);
        existingParts.SetMachineName(parts.MachineName);
        existingParts.SetQuantity(parts.Quantity);
        existingParts.SetPrice(parts.Price);
        await _context.SaveChangesAsync();
        return existingParts;
    }

    public async Task DeleteParts(int id)
    {
        var existingParts = await _context.Parts.FirstOrDefaultAsync(p => p.Id == id);
        if (existingParts == null)
        {
            throw new KeyNotFoundException($"Peça com o id {id} não encontrada.");
        }
        _context.Parts.Remove(existingParts);
        await _context.SaveChangesAsync();
    }
}