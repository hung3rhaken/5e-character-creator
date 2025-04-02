namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public interface ICharacterClass
{
    string Name { get; }

    /// <summary>
    /// Applies default ability values (and other defaults) to the given character.
    /// </summary>
    void ApplyDefaults<T>(Character<T> character) where T : ICharacterClass, new();
}
