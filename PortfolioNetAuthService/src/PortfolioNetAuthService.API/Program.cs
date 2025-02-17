using Microsoft.Extensions.Configuration;
using PortfolioNetAuthService.Application.DependencyInjection;
using PortfolioNetAuthService.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Carrega a Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string is missing.");

// Adiciona camadas da aplicação
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(connectionString);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
