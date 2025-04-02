using CharacterCreator.ClassLibrary.Main;
using CharacterCreator.ClassLibrary.Main.CharacterClasses;
using Newtonsoft.Json;
using System.Text;

namespace CharacterCreator.Frontend.Services;

public class CharacterService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerSettings _jsonSerializerSettings;

    public CharacterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };
    }

    public async Task<CharacterBase>? GetCharacterAsync(string characterName) 
    {
        // Ensure the character name is URL encoded in case it contains spaces or special characters.
        var encodedName = Uri.EscapeDataString(characterName);
        var response = await _httpClient.GetAsync($"character?characterName={encodedName}");       

        if (response.IsSuccessStatusCode)
        {
            var resultString = await response.Content.ReadAsStringAsync();
            var character = JsonConvert.DeserializeObject<CharacterBase>(resultString, _jsonSerializerSettings);
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

    public async Task<CharacterBase?> SaveCharacterAsync(CharacterBase character)
    {
        // Serialize using Newtonsoft.Json with your settings.
        var json = JsonConvert.SerializeObject(character, _jsonSerializerSettings);

        // Create an HttpContent with the JSON payload.
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Send the POST request.
        var response = await _httpClient.PostAsync("character/fighter", content);

        if (response.IsSuccessStatusCode)
        {
            // Optionally, if you want to deserialize the response, you can do so.
            // For now, we'll just return the original character.
            return character;
        }
        return null;
    }
}
