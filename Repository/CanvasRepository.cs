using FinalBattle.Data;
using FinalBattle.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CanvasRepository : ICanvasRepository
{
    private readonly ApplicationDbContext _context;

    public CanvasRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Canvas>> GetAllCanvasesAsync()
    {
        return await _context.Canvases.ToListAsync();
    }

    public async Task<Canvas> GetCanvasByIdAsync(int id)
    {
        return await _context.Canvases.FindAsync(id);
    }

    public async Task CreateCanvasAsync(Canvas canvas)
    {
        _context.Canvases.Add(canvas);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCanvasAsync(Canvas canvas)
    {
        _context.Entry(canvas).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCanvasAsync(int id)
    {
        var canvas = await _context.Canvases.FindAsync(id);
        if (canvas != null)
        {
            _context.Canvases.Remove(canvas);
            await _context.SaveChangesAsync();
        }
    }
}
