using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Warlock : CharacterClass
{
    public override string Name { get; set; } = "Warlock";

    protected override int HitDieValue => 8;

    protected override int DefaultStrength => 8;
    protected override int DefaultDexterity => 14;
    protected override int DefaultConstitution => 13;
    protected override int DefaultIntelligence => 12;
    protected override int DefaultWisdom => 10;
    protected override int DefaultCharisma => 15;

    public Warlock()
    {
        
    }

    public Warlock(int classLevel = 1) : base(classLevel) 
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
        character.Wisdom.HasSavingThrowProficiency = true;
        character.Charisma.HasSavingThrowProficiency = true;
    }
}
