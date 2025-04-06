using System.Reflection;

namespace CharacterCreator.ClassLibrary.Main.CharacterData;

public static class AlignmentType
{
    public const string LawfulGood = "Lawful Good";
    public const string NeutralGood = "Neutral Good";
    public const string ChaoticGood = "Chaotic Good";

    public const string LawfulNeutral = "Lawful Neutral";
    public const string Neutral = "Neutral";
    public const string ChaoticNeutral = "Chaotic Neutral";

    public const string LawfulEvil = "Lawful Evil";
    public const string NeutralEvil = "Neutral Evil";
    public const string ChaoticEvil = "Chaotic Evil";

    public static List<string> GetAllAlignments()
    {
        return typeof(AlignmentType)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
            .Select(fi => (string)fi.GetValue(null)).ToList();
    }

}
