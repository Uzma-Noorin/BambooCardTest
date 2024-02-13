using BambooCardTest.Integrations.HackerNews;
using BambooCardTest.Models;
using BambooCardTest.Services.Implementations;
using BambooCardTest.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHackerNewsService, HackerNewsService>();
builder.Services.AddScoped<IHackerNewsClient, HackerNewsClient>();

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Services.Configure<HackerNewsSettings>(options => builder.Configuration.GetSection("HackerNewsSettings").Bind(options));


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

app.Run();
