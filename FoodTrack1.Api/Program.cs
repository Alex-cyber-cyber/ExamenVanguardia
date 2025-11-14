using FoodTrack.Application.Abstractions;
using FoodTrack.Application.UseCases;
using FoodTrack.Infrastructure.Repositories.InMemory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<CrearOrdenService>();
builder.Services.AddScoped<CambiarEstadoOrdenService>();

builder.Services.AddSingleton<IFoodTruckRepository, InMemoryFoodTruckRepository>();
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
builder.Services.AddSingleton<IEventLogRepository, InMemoryEventLogRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
