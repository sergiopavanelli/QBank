using Microsoft.EntityFrameworkCore;
using MeuProjetoAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o DbContext com a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona serviços de controladores
builder.Services.AddControllers();

// Adiciona e configura o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeuProjetoAPI v1"));
}

// Configura o roteamento e os endpoints
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
