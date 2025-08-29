
using Cultura.Application.Interfaces.Service;
using Cultura.Application.Services;
using Cultura.Application.Validator;
using Cultura.Data;
using Cultura.Infrastructure.Data;
using Cultura.Infrastructure.Interfaces.Repositorio;
using Cultura.Infrastructure.Repositories;
using Cultura.Infrastructure.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<UsuarioValidator>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("Cultura.Infrastructure")
    ));


// Registro dos serviços
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IEventoService, EventoService>();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

builder.Services.AddScoped<IIngressoRepository, IngressoRepository>();

builder.Services.AddScoped<ITipoIngressoRepository,TipoIngressoRepository>();
builder.Services.AddScoped<ITipoIngressoService, TipoIngressoService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Autorização
builder.Services.AddAuthorization();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontendLocal", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirFrontendLocal");

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();
