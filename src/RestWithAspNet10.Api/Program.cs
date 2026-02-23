using RestWithAspNet10.Services;
using RestWithAspNet10.Interface;
using RestWithAspNet10.Configurations;
using RestWithAspNet10.repository;
using RestWithAspNet10.Api.Repository.Base;
using RestWithAspNet10.Api.Interface.Base;
using RestWithAspNet10.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddMSSQLServerSQLConnection(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenAPIConfig();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.UseSwaggerSpecification();

app.UseScalarConfiguration();
app.Run();
