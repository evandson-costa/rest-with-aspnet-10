var builder = WebApplication.CreateBuilder(args);

// registra controllers
builder.Services.AddControllers();

// OpenAPI (Swagger)
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
