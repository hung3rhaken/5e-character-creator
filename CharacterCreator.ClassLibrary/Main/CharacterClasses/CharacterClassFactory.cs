namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public static class CharacterClassFactory
{
    // You could store these in a dictionary or list. For simplicity:
    private static readonly ICharacterClass[] availableClasses =
    {
        //new Wizard(),
        new Fighter(),
        // Add additional classes here.
    };

    // Lookup by name (case-insensitive). Throws if not found.
    public static ICharacterClass GetAvailableClass(string className)
    {
        var characterClass = availableClasses.FirstOrDefault(
            cc => string.Equals(cc.Name, className, StringComparison.OrdinalIgnoreCase));

        if (characterClass == null)
        {
            throw new ArgumentException($"Invalid character class: {className}");
        }
        return characterClass;
    }

    // Optionally, a method to return all available classes.
    public static IEnumerable<ICharacterClass> GetAllClasses() => availableClasses;
}
