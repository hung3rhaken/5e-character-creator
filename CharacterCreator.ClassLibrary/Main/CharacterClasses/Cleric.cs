using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Cleric : CharacterClass
{
    public override string Name { get; set; } = "Cleric";

    protected override int HitDieValue => 8;

    protected override int DefaultStrength => 14;
    protected override int DefaultDexterity => 8;
    protected override int DefaultConstitution => 13;
    protected override int DefaultIntelligence => 10;
    protected override int DefaultWisdom => 15;
    protected override int DefaultCharisma => 12;

    public Cleric()
    {
        
    }

    public Cleric(int classLevel = 1) : base(classLevel)
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
