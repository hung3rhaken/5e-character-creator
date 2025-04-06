using System.Text.Json;
using System.Text.Json.Serialization;

namespace CharacterCreator.ClassLibrary.Utilities.Json;

public static class GlobalJsonOptions
{
    public static readonly bool PropertyNameCaseInsensitive = true;
    public static readonly bool WriteIndented = true;
    public static readonly ReferenceHandler ReferenceHandler = ReferenceHandler.Preserve;

    public static readonly JsonSerializerOptions SerializerOptions = new ()
    {
        PropertyNameCaseInsensitive = true,
        ReferenceHandler = ReferenceHandler,
        WriteIndented = true
    };
}