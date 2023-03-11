using TarefaAula3.Application.UseCases;
using TarefaAula3.Application.Interfaces;
using TarefaAula3.Repository.Interfaces;
using TarefaAula3.Repository;
using TarefaAula3.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICadastrarPessoaUseCase, CadastrarPessoaUseCase>();
builder.Services.AddScoped<IListarPessoasUseCase, ListarPessoasUseCase>();
builder.Services.AddScoped<IBuscarPessoaUseCase, BuscarPessoaUseCase>();
builder.Services.AddScoped<IExcluirPessoaUseCase, ExcluirPessoaUseCase>();
builder.Services.AddScoped<IAtualizarPessoaUseCase, AtualizarPessoaUseCase>();

builder.Services.AddSingleton<IRepository<Pessoa>, PessoaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    if (context.Request.Headers["Profile"] != "Ada")
    {
        context.Response.StatusCode = 403;
        context.Response.ContentType = "application/json";
        var Json = new
        {
            Error = $"O perfil '{context.Request.Headers["Profile"]}' não possui autorização para acessar a API"
        };
        await context.Response.WriteAsJsonAsync(Json);
    }
    else
    {
        await next.Invoke();
    }
});

app.UseAuthorization();

app.MapControllers();

app.Run();
