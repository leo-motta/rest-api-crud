using Oracle.ManagedDataAccess.Client;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.EntityFrameworkCore;
using BuberBreakfast.Data;

var connectionString = "Data Source=localhost:1521/xe;User Id=system;Password=system;";
try
{
    await using (OracleConnection connection = new OracleConnection(connectionString))
    {
        await connection.OpenAsync();
        Console.WriteLine("Conexão bem-sucedida!");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao conectar: {ex.Message}");
}

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
    builder.Services.AddDbContext<BreakfastDBContext>(options =>
     options.UseOracle(connectionString));
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error"); // route
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}