using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Barbarian : CharacterClass
{
    public override string Name { get; set; } = "Barbarian";
    public override int ClassLevel {  get; set; }

    public Barbarian()
    {
        
    }

    public Barbarian(int classLevel = 1)
    {
        ClassLevel = classLevel;
    }

    public override void ApplyClassBenefits(Character character)
    {
        character.Strength = new Ability("Strength", 16);
        character.Dexterity = new Ability("Dexterity", 12);
        character.Constitution = new Ability("Constitution", 14);
        character.Intelligence = new Ability("Intelligence", 10);
        character.Wisdom = new Ability("Wisdom", 10);
        character.Charisma = new Ability("Charisma", 10);
    }

    public override void ApplyDefaultAbilityValues(Character character)
    {
        character.Strength = new Ability("Strength", 16);
        character.Dexterity = new Ability("Dexterity", 12);
        character.Constitution = new Ability("Constitution", 14);
        character.Intelligence = new Ability("Intelligence", 10);
        character.Wisdom = new Ability("Wisdom", 10);
        character.Charisma = new Ability("Charisma", 10);
    }
}
