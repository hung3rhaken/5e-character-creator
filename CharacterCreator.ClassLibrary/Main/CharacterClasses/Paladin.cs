using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Paladin : CharacterClass
{
    public override string Name { get; set; } = "Paladin";

    protected override int HitDieValue => 10;

    public Paladin(int classLevel = 1) : base(classLevel)
    {
        HitDice = new(HitDieValue, classLevel);
    }
    public override void ApplyClassBenefits(Character character)
    {
        // ... 
    }

    public override void ApplyDefaultAbilityValues(Character character)
    {
        character.Strength = new Ability("Strength", 15);
        character.Dexterity = new Ability("Dexterity", 10);
        character.Constitution = new Ability("Constitution", 13);
        character.Intelligence = new Ability("Intelligence", 8);
        character.Wisdom = new Ability("Wisdom", 12);
        character.Charisma = new Ability("Charisma", 14);
    }
}
