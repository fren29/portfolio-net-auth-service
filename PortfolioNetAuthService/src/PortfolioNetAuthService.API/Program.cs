using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PortfolioNetAuthService.Application.DependencyInjection;
using PortfolioNetAuthService.Infrastructure.DependencyInjection;
using PortfolioNetAuthService.Application.Mappings;
using System.Text;
using PortfolioNetAuthService.Application.Interfaces;
using PortfolioNetAuthService.Application.Services;
using PortfolioNetAuthService.Domain.Interfaces;
using PortfolioNetAuthService.Infrastructure.Repositories;
using PortfolioNetAuthService.Infrastructure.Services;
using PortfolioNetAuthService.Application.Features.Auth.Handlers;
using MediatR;
using System.Reflection;
using PortfolioNetAuthService.Application.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Carrega a Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string is missing.");

// Adiciona camadas da aplicação (Infra + Application)
builder.Services.AddApplicationLayer();

// Adiciona AutoMapper (Para Mapear DTOs <-> Entidades)
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configuração do Swagger com suporte a Autenticação JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Portfolio Auth Service API",
        Version = "v1",
        Description = "API de autenticação do portfólio.",
        Contact = new OpenApiContact
        {
            Name = "Seu Nome",
            Email = "seu@email.com"
        }
    });

    // Configuração do esquema de autenticação para Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira 'Bearer' [espaço] e seu token JWT.",
    });

    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Configuração de Autenticação JWT
var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);

builder.Services.AddSingleton(jwtSettings);
builder.Services.AddInfrastructureLayer(connectionString, jwtSettings);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

// Adiciona suporte a Autorização e Controladores
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();




var app = builder.Build();

// Ativar Swagger apenas no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
