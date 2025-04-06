using CharacterCreator.ClassLibrary.Main.CharacterData;
using CharacterCreator.ClassLibrary.Main.Properties;
using System.Text.Json.Serialization;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

[JsonDerivedType(typeof(Barbarian), "Barbarian")]
[JsonDerivedType(typeof(Bard), "Bard")]
[JsonDerivedType(typeof(Cleric), "Cleric")]
[JsonDerivedType(typeof(Druid), "Druid")]
[JsonDerivedType(typeof(Fighter), "Fighter")]
[JsonDerivedType(typeof(Monk), "Monk")]
[JsonDerivedType(typeof(Paladin), "Paladin")]
[JsonDerivedType(typeof(Ranger), "Ranger")]
[JsonDerivedType(typeof(Rogue), "Rogue")]
[JsonDerivedType(typeof(Sorcerer), "Sorcerer")]
[JsonDerivedType(typeof(Warlock), "Warlock")]
[JsonDerivedType(typeof(Wizard), "Wizard")]
public abstract class CharacterClass
{
    public virtual string Name { get; set; } = "DefaultClass";
    public virtual int ClassLevel { get; set; }
    public virtual string SubClass { get; set; } = string.Empty;
    public virtual HitDice HitDice { get; set; }

    protected abstract int HitDieValue { get; }

    protected abstract int DefaultStrength { get; }
    protected abstract int DefaultDexterity { get; }
    protected abstract int DefaultConstitution { get; }
    protected abstract int DefaultIntelligence { get; }
    protected abstract int DefaultWisdom { get; }
    protected abstract int DefaultCharisma { get; }


    protected CharacterClass(int classLevel = 1)
    {
        ClassLevel = classLevel;
        HitDice = new HitDice(10, classLevel);
    }

    /// <summary>
    /// Applies class benefits to the character.
    /// </summary>
    /// <param name="character"></param>
    public abstract void ApplyClassBenefits(Character character);

    /// <summary>
    /// Applies default class ability scores to the character
    /// </summary>
    /// <param name="character"></param>
    public virtual void ApplyDefaultAbilityValues(Character character)
    {
        character.Strength.Score = DefaultStrength;
        character.Dexterity.Score = DefaultDexterity;
        character.Constitution.Score = DefaultConstitution;
        character.Intelligence.Score = DefaultIntelligence;
        character.Wisdom.Score = DefaultWisdom;
        character.Charisma.Score = DefaultCharisma;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual int ArmorClassBonus(Character character)
    {
        return 0;
    }
}
