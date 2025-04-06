using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Wizard : CharacterClass
{
    public override string Name { get; set; } = "Wizard";

    protected override int HitDieValue => 6;

    protected override int DefaultStrength => 8;
    protected override int DefaultDexterity => 12;
    protected override int DefaultConstitution => 13;
    protected override int DefaultIntelligence => 15;
    protected override int DefaultWisdom => 14;
    protected override int DefaultCharisma => 10;

    public Wizard()
    {
        
    }

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
        base.ApplyDefaultAbilityValues(character);
        character.Intelligence.HasSavingThrowProficiency = true;
        character.Wisdom.HasSavingThrowProficiency = true;
    }
}
