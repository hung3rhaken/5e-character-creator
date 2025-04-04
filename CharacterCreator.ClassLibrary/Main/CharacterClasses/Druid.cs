using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Druid : CharacterClass
{
    public override string Name { get; set; } = "Druid";

    public Druid(int classLevel = 1) : base(classLevel) { }

    public override void ApplyClassBenefits(Character character)
    {
        // ... 
    }

    public override void ApplyDefaultAbilityValues(Character character)
    {
        character.Strength = new Ability("Strength", 8);
        character.Dexterity = new Ability("Dexterity", 12);
        character.Constitution = new Ability("Constitution", 14);
        character.Intelligence = new Ability("Intelligence", 13);
        character.Wisdom = new Ability("Wisdom", 15);
        character.Charisma = new Ability("Charisma", 10);
    }
}
