using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Wizard : CharacterClass
{
    public override string Name { get; set; } = "Wizard";
    public override int ClassLevel { get; set; }

    public Wizard(int classLevel = 1)
    {
        ClassLevel = classLevel;
    }

    public override void ApplyClassBenefits(Character character)
    {
        character.Strength = new Ability("Strength", 8);
        character.Dexterity = new Ability("Dexterity", 10);
        character.Constitution = new Ability("Constitution", 14);
        character.Intelligence = new Ability("Intelligence", 18);
        character.Wisdom = new Ability("Wisdom", 14);
        character.Charisma = new Ability("Charisma", 12);
    }

    public override void ApplyDefaultAbilityValues(Character character)
    {
        character.Strength = new Ability("Strength", 8);
        character.Dexterity = new Ability("Dexterity", 10);
        character.Constitution = new Ability("Constitution", 14);
        character.Intelligence = new Ability("Intelligence", 18);
        character.Wisdom = new Ability("Wisdom", 14);
        character.Charisma = new Ability("Charisma", 12);
    }
}
