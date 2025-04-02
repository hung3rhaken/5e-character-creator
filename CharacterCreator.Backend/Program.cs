using CharacterCreator.ClassLibrary.Main;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Optional: Configure JSON options if needed (e.g., for indented output)
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.WriteIndented = true;
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Define the data folder and file path
var dataFolder = Path.Combine(AppContext.BaseDirectory, "Data");
if (!Directory.Exists(dataFolder))
{
    Directory.CreateDirectory(dataFolder);
}


// GET endpoint: returns a Character instance if it exists, otherwise 404.
app.MapGet("/character", async (string characterName) =>
{
    var filePath = Path.Combine(dataFolder, $"{characterName}.json");

    if (File.Exists(filePath))
    {
        var json = await File.ReadAllTextAsync(filePath);
        var character = JsonSerializer.Deserialize<Character>(json);

        // Return the JSON content with a 200 OK
        return Results.Ok(character);
    }
    // If the file does not exist, return a 404 Not Found response
    return Results.NotFound("No character data found");
})
.WithName("GetCharacterData")
.WithOpenApi();

// GET endpoint: returns all Characters from data store.
app.MapGet("/characters", async () =>
{
    var filePath = Path.Combine(dataFolder);

    var files = Directory.GetFiles(dataFolder, "*.json");
    var characterNames = files.Select(file => Path.GetFileNameWithoutExtension(file)).ToList();
    return Results.Ok(characterNames);

    if (File.Exists(filePath))
    {
        var json = await File.ReadAllTextAsync(filePath);
        var character = JsonSerializer.Deserialize<Character>(json);

        // Return the JSON content with a 200 OK
        return Results.Ok(character);
    }
    // If the file does not exist, return a 404 Not Found response
    return Results.NotFound("No character data found");
})
.WithName("GetAllCharacterNames")
.WithOpenApi();

// POST endpoint to save the character data
app.MapPost("/character", async (Character character) =>
{
    var filePath = Path.Combine(dataFolder, $"{character.Name}.json");

    var options = new JsonSerializerOptions { WriteIndented = true };
    var json = JsonSerializer.Serialize(character, options);

    await File.WriteAllTextAsync(filePath, json);
    return Results.Created();
})
.WithName("PostCharacterData")
.WithOpenApi();

app.Run();