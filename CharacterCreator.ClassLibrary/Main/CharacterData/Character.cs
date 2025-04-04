using CharacterCreator.ClassLibrary.Main.CharacterClasses;
using CharacterCreator.ClassLibrary.Main.Properties;
using System.Numerics;
using System.Text.Json.Serialization;

namespace CharacterCreator.ClassLibrary.Main.CharacterData;

public class Character
{
    // Base Properties
    public string Name { get; set; }
    public int Level { get; set; }
    public CharacterClass CharacterClass { get; set; }
    // Multiclassing somewhere here

    // Origin
    public string Background { get; set; }
    public string Species { get; set; }
    public string Alignment { get; set; }
    public string Size { get; set; }
    public int Speed { get; set; }

    // Dynamic Data
    public int ProficiencyBonus { get; set; }
    public int ArmorClass { get; set; }
    public int MaxHitPoints { get; set; }
    public int CurrentHitPoints { get; set; }
    public int Initiative { get; set; }
    public int PassivePerception { get; set; }


    // Abilities
    public Ability Strength { get; set; }
    public Ability Dexterity { get; set; }
    public Ability Constitution { get; set; }
    public Ability Intelligence { get; set; }
    public Ability Wisdom { get; set; }
    public Ability Charisma { get; set; }

    // Saving Throws

    // Skills

    // Feats?

    // Equipment

    // Spellcasting

    // Control and metadata properties
    public bool IsNewCharater { get; set; }

    [JsonIgnore]
    public bool IsInitialAbilityAllocation { get; set; }

    public Character(CharacterClass characterClass)
    {
        Name = "New Guy";
        Level = 1;
        CharacterClass = characterClass;

        Background = "Artisan";
        Species = "Human";
        Alignment = "Neutral Good";
        Size = "Medium";
        Speed = 30;

        ProficiencyBonus = 2;
        ArmorClass = 13;
        MaxHitPoints = 10;
        CurrentHitPoints = MaxHitPoints;
        Initiative = 2;
        PassivePerception = 12;

        IsNewCharater = true;
        IsInitialAbilityAllocation = true;
    }

    public void CalculateCharacterValues()
    {
        CharacterClass?.ApplyDefaultAbilityValues(this);
        CharacterClass?.ApplyClassBenefits(this);
    }

    private void CalculateInitialCharacterValues()
    {
        CharacterClass.ApplyDefaultAbilityValues(this);
        CharacterClass.ApplyClassBenefits(this);
    }
}
