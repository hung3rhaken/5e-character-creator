using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Ranger : CharacterClass
{
    public override string Name { get; set; } = "Ranger";

    public Ranger(int classLevel = 1) : base(classLevel) { }

    public override void ApplyClassBenefits(Character character)
    {
        // ... 
    }

    public override void ApplyDefaultAbilityValues(Character character)
    {
        character.Strength = new Ability("Strength", 12);
        character.Dexterity = new Ability("Dexterity", 15);
        character.Constitution = new Ability("Constitution", 13);
        character.Intelligence = new Ability("Intelligence", 8);
        character.Wisdom = new Ability("Wisdom", 14);
        character.Charisma = new Ability("Charisma", 10);
    }
}
