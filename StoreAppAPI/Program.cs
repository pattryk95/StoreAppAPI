using Microsoft.EntityFrameworkCore;
using StoreAppAPI.Entities;
using StoreAppAPI.Services;
using StoreAppAPI.Services.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEndClient", policyBuilder =>
    
        policyBuilder.AllowAnyMethod()
                     .AllowAnyHeader()
                     .WithOrigins(builder.Configuration["AllowedOrigins"])
    );
});

builder.Services.AddDbContext<StoreAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreAppConnectionString"))
);
builder.Services.AddScoped<StoreAppSeeder>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



//Invoke Swager in services configuration (Necessary services do make API Docs)
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseCors("FrontEndClient");
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
