using System.Text.Json;
using CharacterCreator.ClassLibrary.Main;
using CharacterCreator.ClassLibrary.Main.CharacterClasses;
using Newtonsoft.Json;


namespace CharacterCreator.Backend.Endpoints.Character;

public static class CharacterEndpoints
{
    private static readonly string DataFolder = Path.Combine(AppContext.BaseDirectory, "Data");

    public static void AddCharacterEndpoints(this WebApplication app)
    {
        // Define the data folder and file path
        //var dataFolder = Path.Combine(AppContext.BaseDirectory, "Data");
        //if (!Directory.Exists(dataFolder))
        //{
        //    Directory.CreateDirectory(dataFolder);
        //}

        // GET endpoint: returns a Character instance if it exists, otherwise 404.
        app.MapGet("/character", async (string characterName) =>
        {
            var _jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            var filePath = Path.Combine(DataFolder, $"{characterName}.json");

            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                var character = JsonConvert.DeserializeObject<Character<Fighter>>(json, _jsonSerializerSettings);
                //var characterBase = JsonConvert.DeserializeObject<CharacterBase>(json, _jsonSerializerSettings);

                var jsonCharacter = JsonConvert.SerializeObject(character, _jsonSerializerSettings);

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
        app.MapPost("/character/Fighter", async (Character<Fighter> character) =>
        {
            await HandlePostCharacterAsync(character);
            return Results.Created();
        })
        .WithName("PostCharacterData")
        .WithOpenApi();
    }

    private static async Task HandlePostCharacterAsync<T>(Character<T> character) where T : ICharacterClass, new()
    {
        var _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };

        var filePath = Path.Combine(DataFolder, $"{character.Name}.json");

        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonConvert.SerializeObject(character, _jsonSerializerSettings);

        await File.WriteAllTextAsync(filePath, json);
    }
}
