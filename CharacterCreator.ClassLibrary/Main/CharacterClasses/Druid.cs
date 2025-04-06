using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Druid : CharacterClass
{
    public override string Name { get; set; } = "Druid";

    protected override int HitDieValue => 8;

    protected override int DefaultStrength => 8;
    protected override int DefaultDexterity => 12;
    protected override int DefaultConstitution => 14;
    protected override int DefaultIntelligence => 13;
    protected override int DefaultWisdom => 15;
    protected override int DefaultCharisma => 10;

    public Druid()
    {
         
    }

    public Druid(int classLevel = 1) : base(classLevel) 
    { 
        HitDice = new(HitDieValue, classLevel);
    }

    public override void ApplyClassBenefits(Character character)
    {
        // ... 
    }

    public override void ApplyDefaultAbilityValues(Character character)
    {
        character.Strength.Score = DefaultStrength;
        character.Dexterity.Score = DefaultDexterity;
        character.Constitution.Score = DefaultConstitution;
        character.Intelligence.Score = DefaultIntelligence;
        character.Wisdom.Score = DefaultWisdom;
        character.Charisma.Score = DefaultCharisma;
    }
}
