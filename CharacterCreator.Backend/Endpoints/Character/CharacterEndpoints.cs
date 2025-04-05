using CharacterCreator.ClassLibrary.Utilities.Json;
using System.Text.Json;


namespace CharacterCreator.Backend.Endpoints.Character;

public static class CharacterEndpoints
{
    private static readonly string DataFolder = Path.Combine(AppContext.BaseDirectory, "Data");
    private static readonly JsonSerializerOptions jsonSerializerOptions = GlobalJsonOptions.SerializerOptions;

    public static void AddCharacterEndpoints(this WebApplication app)
    {
        // GET endpoint: returns a Character instance if it exists, otherwise 404.
        app.MapGet("/character", async (string characterName) =>
        {
            var filePath = Path.Combine(DataFolder, $"{characterName}.json");

            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                var character = JsonSerializer.Deserialize<ClassLibrary.Main.CharacterData.Character>(json, jsonSerializerOptions);

                return Results.Ok(character);
            }
            return Results.NotFound("No character data found");
        })
        .WithName("GetCharacterData")
        .WithOpenApi();


        // GET endpoint: returns all Characters from data store.
        app.MapGet("/characters", async () =>
        {
            List<string> characterNames = new();
            var files = Directory.GetFiles(DataFolder, "*.json");

            if (files is not null)
            {
                characterNames =
                    files.Select(file =>
                        Path.GetFileNameWithoutExtension(file))
                    .ToList();
            }

            return Results.Ok(characterNames);
        })
        .WithName("GetAllCharacterNames")
        .WithOpenApi();

        // POST endpoint to save the character data
        app.MapPost("/character", async (ClassLibrary.Main.CharacterData.Character character) =>
        {
            if (!Path.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }

            var filePath = Path.Combine(DataFolder, $"{character.Name}.json");

            var json = JsonSerializer.Serialize(character, jsonSerializerOptions);

            await File.WriteAllTextAsync(filePath, json);

            return Results.Created();
        })
        .WithName("CreateCharacter")
        .WithOpenApi();
    }
}