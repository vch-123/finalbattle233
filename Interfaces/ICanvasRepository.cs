using FinalBattle.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICanvasRepository
{
    Task<IEnumerable<Canvas>> GetAllCanvasesAsync();
    Task<Canvas> GetCanvasByIdAsync(int id);
    Task CreateCanvasAsync(Canvas canvas);
    Task UpdateCanvasAsync(Canvas canvas);
    Task DeleteCanvasAsync(int id);
}
