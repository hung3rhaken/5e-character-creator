using CharacterCreator.ClassLibrary.Main.CharacterClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CharacterCreator.ClassLibrary.Utilities.JsonConverters;

public class CharacterClassConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(CharacterClass).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // Load the JSON into a JObject
        JObject jo = JObject.Load(reader);

        // Try to get the "Name" property in a case-insensitive way.
        if (!jo.TryGetValue("Name", StringComparison.OrdinalIgnoreCase, out JToken typeToken))
        {
            throw new JsonSerializationException("Missing type discriminator property 'Name'.");
        }

        var typeName = typeToken.Value<string>();

        CharacterClass instance = typeName switch
        {
            "Fighter" => new Fighter(),
            "Wizard" => new Wizard(),
            //"Cleric" => new Cleric(),
            _ => throw new NotSupportedException($"CharacterClass type '{typeName}' is not supported.")
        };

        // Populate the instance properties from JSON
        serializer.Populate(jo.CreateReader(), instance);
        return instance;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        // Serialize using the actual runtime type.
        serializer.Serialize(writer, value);

        JObject jo = new JObject();

        if (value is Fighter fighter)
        {
            Fighter x = (Fighter)value;
            writer.WriteValue(x);

            //jo["Name"] = fighter.Name;
            //jo["ClassLevel"] = fighter.ClassLevel;
        }
        else if (value is Wizard wizard)
        {
            jo["Name"] = wizard.Name;
            jo["ClassLevel"] = wizard.ClassLevel;
        }
        else
        {
            throw new NotSupportedException($"Unsupported type: {value.GetType()}");
        }

        //jo.WriteTo(writer);
    }
}
