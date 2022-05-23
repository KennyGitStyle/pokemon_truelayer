using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pokemon.API.Extension;
using Pokemon.Infrastructure.Data.PokemonContext;
using Pokemon.Infrastructure.Repository;
using Pokemon.Infrastructure.SeedData;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(p => {
    p.SwaggerDoc("v1", new OpenApiInfo {Title = "PokemonApi", Version = "v1"});
});
builder.Services.AddHealthChecks().AddDbContextCheck<PokemonDbContext>();
builder.Services.AddScoped<IPokemonContract, PokemonImplementation>();
builder.Services.AddSqliteDatabaseConnection(builder.Configuration); // DbConnection extension method

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(p => {
        p.SwaggerEndpoint("/swagger/v1/swagger.json", "PokemonApi v1");
        p.SupportedSubmitMethods(new[]{
            SubmitMethod.Get
        });
    });
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
    await DataSeed.DbInitializer(context, loggerFactory);
}
catch (Exception ex){
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred while migrating the database.");
}
                
            
await app.RunAsync();
