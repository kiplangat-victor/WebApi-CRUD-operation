using Api.Data;
using Api.Interfaces;
using Api.Interfaces.Students;
using Api.Repositories;
using Api.Repositories.StudentRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString=builder.Configuration.GetConnectionString("AppDbConnectionSettings");

builder.Services.AddDbContext<AppDbContext>(options=>options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IMarkRepository, MarkRepository>();
builder.Services.AddScoped<IStudentRepository, StudentsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
