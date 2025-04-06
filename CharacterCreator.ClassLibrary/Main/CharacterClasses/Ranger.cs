using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Ranger : CharacterClass
{
    public override string Name { get; set; } = "Ranger";

    protected override int HitDieValue => 10;

    protected override int DefaultStrength => 12;
    protected override int DefaultDexterity => 15;
    protected override int DefaultConstitution => 13;
    protected override int DefaultIntelligence => 8;
    protected override int DefaultWisdom => 14;
    protected override int DefaultCharisma => 10;

    public Ranger()
    {
        
    }

    public Ranger(int classLevel = 1) : base(classLevel)
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
