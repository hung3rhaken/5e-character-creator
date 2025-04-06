using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Bard : CharacterClass
{
    public override string Name { get; set; } = "Bard";

    protected override int HitDieValue => 8;

    public Bard(int classLevel = 1) : base(classLevel)
    {
        HitDice = new(HitDieValue, classLevel);
    }

    public override void ApplyClassBenefits(Character character)
    {
        // ... 
    }

    public override void ApplyDefaultAbilityValues(Character character)
    {
        character.Strength = new Ability("Strength", 8);
        character.Dexterity = new Ability("Dexterity", 14);
        character.Constitution = new Ability("Constitution", 12);
        character.Intelligence = new Ability("Intelligence", 13);
        character.Wisdom = new Ability("Wisdom", 10);
        character.Charisma = new Ability("Charisma", 15);
    }
}
