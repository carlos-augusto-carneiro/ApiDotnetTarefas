using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTarefas.Database;

var builder = WebApplication.CreateBuilder(args);

var connectionStrong = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TarefasContext>(options => options.UseMySql(connectionStrong, new MySqlServerVersion(new Version(8, 0, 35))));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
