using back_end.Services;
using back_end.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DbConnectionFactory>();
builder.Services.AddScoped<PessoasService>();
builder.Services.AddScoped<PessoasRepository>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Dev", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.UseCors("Dev");   // antes do MapControllers
app.MapControllers();

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
