using Microsoft.EntityFrameworkCore;
using Pokemon.API.Extension;
using Pokemon.Infrastructure.Data.PokemonContext;
using Pokemon.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPokemonContract, PokemonImplementation>();
builder.Services.AddSqliteDatabaseConnection(builder.Configuration); // DbConnection extension method

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


using var serviceProvider = app.Services.CreateScope();
var services = serviceProvider.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
try
{
    var context = services.GetRequiredService<PokemonDbContext>();
    await context.Database.MigrateAsync();
}
catch (Exception ex){
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred while migrating the database.");
}
                
            
await app.RunAsync();
