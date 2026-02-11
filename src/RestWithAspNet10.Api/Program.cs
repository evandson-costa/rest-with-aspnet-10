using RestWithAspNet10.Services;
using RestWithAspNet10.Interface;
using RestWithAspNet10.Configurations;
using RestWithAspNet10.repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddOpenApi();
builder.Services.AddMSSQLServerSQLConnection(builder.Configuration);
builder.AddSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
