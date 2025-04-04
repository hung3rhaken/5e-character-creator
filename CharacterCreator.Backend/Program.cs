using CharacterCreator.Backend.Endpoints.Character;
using CharacterCreator.ClassLibrary.Utilities.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = GlobalJsonOptions.PropertyNameCaseInsensitive;
    options.SerializerOptions.WriteIndented = GlobalJsonOptions.WriteIndented;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddCharacterEndpoints();

app.UseHttpsRedirection();

app.Run();