namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;
public class Fighter : CharacterClassBase
{
    public override string Name => "Fighter";

    public override void ApplyDefaults(Character character)
    {
        character.CharacterClass = "Fighter";
        character.Strength = new Ability("Strength", 16);
        character.Dexterity = new Ability("Dexterity", 12);
        character.Constitution = new Ability("Constitution", 14);
        character.Intelligence = new Ability("Intelligence", 10);
        character.Wisdom = new Ability("Wisdom", 10);
        character.Charisma = new Ability("Charisma", 10);
    }
}
