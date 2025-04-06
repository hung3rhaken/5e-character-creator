using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public class Rogue : CharacterClass
{
    public override string Name { get; set; } = "Rogue";

    protected override int HitDieValue => 8;

    protected override int DefaultStrength => 12;
    protected override int DefaultDexterity => 15;
    protected override int DefaultConstitution => 13;
    protected override int DefaultIntelligence => 14;
    protected override int DefaultWisdom => 10;
    protected override int DefaultCharisma => 8;

    public Rogue()
    {
        
    }

    public Rogue(int classLevel = 1) : base(classLevel)
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
