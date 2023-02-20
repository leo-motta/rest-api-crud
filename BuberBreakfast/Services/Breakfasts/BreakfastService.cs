using BuberBreakfast.Models;
using BuberBreakfast.Data;

namespace BuberBreakfast.Services.Breakfasts;


public class BreakfastService : IBreakfastService
{
    private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();

    //Database
    private readonly BreakfastDBContext _context;
    public BreakfastService(BreakfastDBContext context) 
    {
        _context = context;
    }

    public async void CreateBreakfast(Breakfast breakfast)
    {
        // Add breakfast to dictionary
        //_breakfasts.Add(breakfast.Id, breakfast);

        // Add simple breakfast to DB
        SimpleBreakfast sb = new SimpleBreakfast(12345, breakfast.Name,breakfast.Description);
        try 
        {
            _context.SimpleBreakfast.Add(sb);
            await _context.SaveChangesAsync();
            Console.WriteLine("............SUCESSO em Services.CreateBreakfast............");
        } 
        catch(Exception e) 
        {
            Console.WriteLine("............ERRO em Services.CreateBreakfast............");
            Console.WriteLine(e.Message);
            throw new Exception("Error Creating Breakfast!");
        }
    }

    public async Task<Breakfast> GetBreakfast(Guid id)
    {
        if(_context.SimpleBreakfast != null) {
            var obj = await _context.SimpleBreakfast.FindAsync(id);
            
            if(obj == null)
            {
                throw new Exception("Simple Breakfast Not Found!");
            }
            Console.WriteLine($"Objeto encontrado: ${obj.Name}");
        }
        return _breakfasts[id];
    }

    public void UpsertBreakfast(Breakfast breakfast)
    {
        _breakfasts[breakfast.Id] = breakfast;
    }

    public void DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
    }
}