using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Sorcerer : CharacterClass
{
    public override string Name { get; set; } = "Sorcerer";

    protected override int HitDieValue => 6;

    public Sorcerer(int classLevel = 1) : base(classLevel) 
    {
        HitDice = new(HitDieValue, classLevel); 
    }

    public override void ApplyClassBenefits(Character character)
    {
        // ... 
    }

    public override void ApplyDefaultAbilityValues(Character character)
    {
        character.Strength = new Ability("Strength", 10);
        character.Dexterity = new Ability("Dexterity", 13);
        character.Constitution = new Ability("Constitution", 14);
        character.Intelligence = new Ability("Intelligence", 8);
        character.Wisdom = new Ability("Wisdom", 12);
        character.Charisma = new Ability("Charisma", 15);
    }
}
