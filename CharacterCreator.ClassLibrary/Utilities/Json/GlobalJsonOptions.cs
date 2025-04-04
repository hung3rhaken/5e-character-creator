using System.Text.Json;

namespace CharacterCreator.ClassLibrary.Utilities.Json;

public static class GlobalJsonOptions
{
    public static readonly bool PropertyNameCaseInsensitive = true;
    public static readonly bool WriteIndented = true;

    public static readonly JsonSerializerOptions SerializerOptions = new ()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };
}