var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Invoke Swager in services configuration (Necessary services do make API Docs)
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

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
