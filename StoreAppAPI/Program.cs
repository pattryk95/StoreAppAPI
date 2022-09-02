using Microsoft.EntityFrameworkCore;
using StoreAppAPI.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StoreAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreAppConnectionString"))
);
builder.Services.AddScoped<StoreAppSeeder>();


//Invoke Swager in services configuration (Necessary services do make API Docs)
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<StoreAppSeeder>();

seeder.Seed();

app.UseHttpsRedirection();


//Swager implementation
app.UseSwagger();
app.UseSwaggerUI(conf =>
{
    conf.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreAppAPI");
});

app.UseAuthorization();

app.MapControllers();



app.Run();
