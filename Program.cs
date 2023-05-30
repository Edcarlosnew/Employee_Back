using Back_End_Employee.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Adicionar serviços de documentação do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API do Projeto Final Impacta", Version = "v1" });
});

// 7ª PASSO: REFERENCIAR O CONTEXTO DO DB CONFIGURADO NA PASTA DATA PARA INICIALIZAR O SERVIÇO PARA
// INTEGRAR A API E O DATABASE
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//2ª ADICIONAR O SERVICE PARA O CORS - COM O OBJETIVO DE FACILITAR O CRUZAMENTO DE DOMINIO ENTRE ASAPLICAÇÕES.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Final Impacta");
});

// 3ª PASSO: AQUI, A APLICAÇÃO FARÁ USO DAS REGRAS CORS ESTABELECIDAS ACIMA
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

