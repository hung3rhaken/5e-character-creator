using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Monk : CharacterClass
{
    public override string Name { get; set; } = "Monk";

    protected override int HitDieValue => 8;

    protected override int DefaultStrength => 12;
    protected override int DefaultDexterity => 15;
    protected override int DefaultConstitution => 13;
    protected override int DefaultIntelligence => 10;
    protected override int DefaultWisdom => 14;
    protected override int DefaultCharisma => 8;

    public Monk()
    {
        
    }

    public Monk(int classLevel = 1) : base(classLevel)
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
        character.Strength.HasSavingThrowProficiency = true;
        character.Dexterity.HasSavingThrowProficiency = true;
    }
}
