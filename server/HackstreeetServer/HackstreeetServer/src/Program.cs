using HackstreeetServer.src.Repositories;
using HackstreeetServer.src.Repositories.Interfaces;
using HackstreeetServer.src.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddScoped<IMeasureRepository, MeasureRepository>();
builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();
builder.Services.AddScoped<IEcoGraderService, EcoGraderService>();

var reactCors = "_reactCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: reactCors,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(reactCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
