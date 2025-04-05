using CharacterCreator.ClassLibrary.Main.CharacterData;
using CharacterCreator.ClassLibrary.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace CharacterCreator.Frontend.Services;

public class CharacterService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public CharacterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = GlobalJsonOptions.SerializerOptions;
    }

    public async Task<Character>? GetCharacterAsync(string characterName)
    {
        // Ensure the character name is URL encoded in case it contains spaces or special characters.
        var encodedName = Uri.EscapeDataString(characterName);
        var response = await _httpClient.GetAsync($"character?characterName={encodedName}");

        if (response.IsSuccessStatusCode)
        {
            var resultString = await response.Content.ReadAsStringAsync();
            var character = JsonSerializer.Deserialize<Character>(resultString, _jsonSerializerOptions);
            return character;
        }
        return null;
    }

    public async Task<List<string>> GetAvailableCharactersAsync()
    {
        var response = await _httpClient.GetAsync($"characters");
        List<string> characterList = new();

        if (response.IsSuccessStatusCode)
        {
            var resultString = await response.Content.ReadAsStringAsync();
            characterList = JsonSerializer.Deserialize<List<string>>(resultString, _jsonSerializerOptions);
        }

        return characterList;
    }

    public async Task<Character?> SaveCharacterAsync(Character character)
    {
        string json = string.Empty;
        try
        {
            json = JsonSerializer.Serialize(character, _jsonSerializerOptions);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("character", content);

        if (response.IsSuccessStatusCode)
        {
            return character;
        }

        return null;
    }
}
