using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Wizard : CharacterClass
{
    public override string Name { get; set; } = "Wizard";

    protected override int HitDieValue => 6;

    public Wizard(int classLevel = 1) : base(classLevel) 
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
        character.Dexterity = new Ability("Dexterity", 12);
        character.Constitution = new Ability("Constitution", 13);
        character.Intelligence = new Ability("Intelligence", 15);
        character.Wisdom = new Ability("Wisdom", 14);
        character.Charisma = new Ability("Charisma", 10);
    }
}
