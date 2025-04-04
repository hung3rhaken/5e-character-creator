using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Cleric : CharacterClass
{
    public override string Name { get; set; } = "Cleric";

    public Cleric(int classLevel = 1) : base(classLevel) { }

    public override void ApplyClassBenefits(Character character)
    {
        // ... 
    }

    public override void ApplyDefaultAbilityValues(Character character)
    {
        character.Strength = new Ability("Strength", 14);
        character.Dexterity = new Ability("Dexterity", 8);
        character.Constitution = new Ability("Constitution", 13);
        character.Intelligence = new Ability("Intelligence", 10);
        character.Wisdom = new Ability("Wisdom", 15);
        character.Charisma = new Ability("Charisma", 12);
    }
}
