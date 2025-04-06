using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Paladin : CharacterClass
{
    public override string Name { get; set; } = "Paladin";

    protected override int HitDieValue => 10;

    protected override int DefaultStrength => 15;
    protected override int DefaultDexterity => 10;
    protected override int DefaultConstitution => 13;
    protected override int DefaultIntelligence => 8;
    protected override int DefaultWisdom => 12;
    protected override int DefaultCharisma => 14;

    public Paladin()
    {
        
    }

    public Paladin(int classLevel = 1) : base(classLevel)
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
