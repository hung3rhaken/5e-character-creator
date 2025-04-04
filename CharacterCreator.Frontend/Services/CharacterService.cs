using CharacterCreator.ClassLibrary.Main;
using System.Text;
using System.Text.Json;

namespace CharacterCreator.Frontend.Services;

public class CharacterService
{
    private readonly HttpClient _httpClient;
    //private readonly JsonSerializerSettings _jsonSerializerSettings;

    public CharacterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        //_jsonSerializerSettings = new JsonSerializerSettings()
        //{
        //    Formatting = Formatting.Indented,
        //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

        //};
    }

    public async Task<Character>? GetCharacterAsync(string characterName)
    {
        // Ensure the character name is URL encoded in case it contains spaces or special characters.
        var encodedName = Uri.EscapeDataString(characterName);
        var response = await _httpClient.GetAsync($"character?characterName={encodedName}");

        if (response.IsSuccessStatusCode)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
            };

            var resultString = await response.Content.ReadAsStringAsync();
            var character = JsonSerializer.Deserialize<Character>(resultString, options);
            return character;
        }
        return null;
    }

    public async Task<List<string>> GetAvailableCharactersAsync()
    {
        var response = await _httpClient.GetAsync($"characters");

        var result = await _httpClient.GetFromJsonAsync<List<string>>("characters");
        return result ?? new List<string>();
    }

    public async Task<Character?> SaveCharacterAsync(Character character)
    {
        string json = string.Empty;
        try
        {
            json = JsonSerializer.Serialize(character);
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
