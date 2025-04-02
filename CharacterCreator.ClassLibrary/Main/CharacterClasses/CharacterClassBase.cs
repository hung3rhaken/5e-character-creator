namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public abstract class CharacterClassBase : ICharacterClass
{
    public abstract string Name { get; }
    public abstract void ApplyDefaults(Character character);
}
