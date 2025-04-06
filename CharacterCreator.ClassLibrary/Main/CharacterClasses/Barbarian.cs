using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Barbarian : CharacterClass
{
    public override string Name { get; set; } = "Barbarian";

    protected override int HitDieValue => 12;

    protected override int DefaultStrength => 15;
    protected override int DefaultDexterity => 13;
    protected override int DefaultConstitution => 14;
    protected override int DefaultIntelligence => 10;
    protected override int DefaultWisdom => 12;
    protected override int DefaultCharisma => 8;

    public Barbarian()
    {
        
    }

    public Barbarian(int classLevel = 1) : base(classLevel) 
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
        character.Constitution.HasSavingThrowProficiency = true;
    }
}
