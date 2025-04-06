using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Sorcerer : CharacterClass
{
    public override string Name { get; set; } = "Sorcerer";

    protected override int HitDieValue => 6;

    protected override int DefaultStrength => 10;
    protected override int DefaultDexterity => 13;
    protected override int DefaultConstitution => 14;
    protected override int DefaultIntelligence => 8;
    protected override int DefaultWisdom => 12;
    protected override int DefaultCharisma => 15;

    public Sorcerer()
    {
        
    }

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
        base.ApplyDefaultAbilityValues(character);
        character.Charisma.HasSavingThrowProficiency = true;
        character.Constitution.HasSavingThrowProficiency = true;
    }
}
