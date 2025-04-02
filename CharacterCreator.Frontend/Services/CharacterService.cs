using CharacterCreator.ClassLibrary.Main;
using System.Net.Http.Json;

namespace CharacterCreator.Frontend.Services;

public class CharacterService
{
    private readonly HttpClient _httpClient;

    public CharacterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Character?> GetCharacterAsync(string characterName)
    {
        // Ensure the character name is URL encoded in case it contains spaces or special characters.
        var encodedName = Uri.EscapeDataString(characterName);
        var response = await _httpClient.GetAsync($"character?characterName={encodedName}");

        if (response.IsSuccessStatusCode)
        {
            // Optionally, read the saved character from the response.
            return await response.Content.ReadFromJsonAsync<Character>();
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
        var response = await _httpClient.PostAsJsonAsync("character", character);
        if (response.IsSuccessStatusCode)
        {
            // Optionally, read the saved character from the response.
            return character;
        }
        return null;
    }
}
