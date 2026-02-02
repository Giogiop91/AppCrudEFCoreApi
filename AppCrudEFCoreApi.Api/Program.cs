//Inserimento sorgente cartelle
using AppCrudEFCoreApi.Api.Data;
using AppCrudEFCoreApi.Api.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// genera in automaitco la documentazioni api
builder.Services.AddEndpointsApiExplorer();
//genera Swagger
builder.Services.AddSwaggerGen();
//abilita controller
builder.Services.AddControllers();


//utilizzo 
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<OrderRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// abilitare il controller
app.MapControllers();
// abilitare il run
app.Run();

