namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;
public class Fighter : ICharacterClass
{
    public string Name => "Fighter";

    public void ApplyDefaults<T>(Character<T> character) where T : ICharacterClass, new()
    {
        character.Strength = new Ability("Strength", 16);
        character.Dexterity = new Ability("Dexterity", 12);
        character.Constitution = new Ability("Constitution", 14);
        character.Intelligence = new Ability("Intelligence", 10);
        character.Wisdom = new Ability("Wisdom", 10);
        character.Charisma = new Ability("Charisma", 10);
    }

    public void FighterSpecificFunction()
    {

    }
}
