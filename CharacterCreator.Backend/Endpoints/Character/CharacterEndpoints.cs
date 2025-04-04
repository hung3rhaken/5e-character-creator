using CharacterCreator.ClassLibrary.Utilities.JsonConverters;
using System.Text.Json;


namespace CharacterCreator.Backend.Endpoints.Character;

public static class CharacterEndpoints
{
    private static readonly string DataFolder = Path.Combine(AppContext.BaseDirectory, "Data");

    public static void AddCharacterEndpoints(this WebApplication app)
    {
        //JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        //{
        //    Formatting = Formatting.Indented,
        //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //};

        // GET endpoint: returns a Character instance if it exists, otherwise 404.
        app.MapGet("/character", async (string characterName) =>
        {
            var filePath = Path.Combine(DataFolder, $"{characterName}.json");

            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                var character = JsonSerializer.Deserialize<ClassLibrary.Main.Character>(json);

                return Results.Ok(character);
            }
            return Results.NotFound("No character data found");
        })
        .WithName("GetCharacterData")
        .WithOpenApi();


        // GET endpoint: returns all Characters from data store.
        app.MapGet("/characters", async () =>
        {
            var filePath = Path.Combine(DataFolder);

            var files = Directory.GetFiles(DataFolder, "*.json");
            var characterNames = files.Select(file => Path.GetFileNameWithoutExtension(file)).ToList();
            return Results.Ok(characterNames);
        })
        .WithName("GetAllCharacterNames")
        .WithOpenApi();

        //// POST endpoint to save the character data
        //app.MapPost("/character", async (Character character) =>
        //{
        //    var filePath = Path.Combine(dataFolder, $"{character.Name}.json");

        //    var options = new JsonSerializerOptions { WriteIndented = true };
        //    var json = JsonSerializer.Serialize(character, options);

        //    await File.WriteAllTextAsync(filePath, json);
        //    return Results.Created();
        //})
        //.WithName("PostCharacterData")
        //.WithOpenApi();

        // POST endpoint to save the character data
        app.MapPost("/character", async (ClassLibrary.Main.Character character) =>
        {
            //await HandlePostCharacterAsync(character);

            // Read the request body as a string.
            //using var reader = new StreamReader(request.Body);
            //string json = await reader.ReadToEndAsync();

            // Use Newtonsoft.Json with your custom settings to deserialize.
            //var character = JsonSerializer.Deserialize<ClassLibrary.Main.Character>(json);

            var filePath = Path.Combine(DataFolder, $"{character.Name}.json");

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(character, options);

            await File.WriteAllTextAsync(filePath, json);

            return Results.Created();
        })
        .WithName("PostCharacterData")
        .WithOpenApi();

        //app.MapPost("/character", async (HttpRequest request) =>
        //{
        //    //await HandlePostCharacterAsync(character);

        //    // Read the request body as a string.
        //    using var reader = new StreamReader(request.Body);
        //    string json = await reader.ReadToEndAsync();

        //    // Use Newtonsoft.Json with your custom settings to deserialize.
        //    var character = JsonSerializer.Deserialize<ClassLibrary.Main.Character>(json);

        //    var filePath = Path.Combine(DataFolder, $"{character.Name}.json");

        //    await File.WriteAllTextAsync(filePath, json);

        //    return Results.Created();
        //})
        //.WithName("PostCharacterData")
        //.WithOpenApi();
    }

    private static async Task HandlePostCharacterAsync(ClassLibrary.Main.Character character)
    {
        //var filePath = Path.Combine(DataFolder, $"{character.Name}.json");

        //var options = new JsonSerializerOptions { WriteIndented = true };
        //var json = JsonConvert.SerializeObject(character, _jsonSerializerSettings);

        //await File.WriteAllTextAsync(filePath, json);
    }
}
