using Backend.Data;
using Backend.Interfaces;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlite("Data Source=AppApi.sql"));

builder.Services.AddScoped<IsAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IsProducerRepository, ProducerRepository>();
builder.Services.AddScoped<IsSeriesRepository, SeriesRepository>();
builder.Services.AddScoped<IsCharacterRepository, CharacterRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();