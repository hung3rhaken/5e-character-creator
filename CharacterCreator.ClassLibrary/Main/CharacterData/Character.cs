using CharacterCreator.ClassLibrary.Main.CharacterClasses;
using CharacterCreator.ClassLibrary.Main.Properties;
using System.Numerics;
using System.Text.Json.Serialization;

namespace CharacterCreator.ClassLibrary.Main.CharacterData;

public class Character
{
    #region Base Properties
    public string Name { get; set; }
    public int Level { get; set; }
    public CharacterClass CharacterClass { get; set; }
    // Multiclassing somewhere here
    #endregion

    #region Origin
    public string Background { get; set; }
    public string Species { get; set; }
    public string Alignment { get; set; }
    public string Size { get; set; }
    public int Speed { get; set; }
    #endregion

    #region Main Character Properties
    public int ProficiencyBonus { get; set; }
    public int ArmorClass { get; set; }
    public int MaxHitPoints { get; set; }
    public int CurrentHitPoints { get; set; }
    public int Initiative { get; set; }
    public int PassivePerception { get; set; }
    #endregion


    #region Abilities
    public Ability Strength { get; set; }
    public Ability Dexterity { get; set; }
    public Ability Constitution { get; set; }
    public Ability Intelligence { get; set; }
    public Ability Wisdom { get; set; }
    public Ability Charisma { get; set; }
    #endregion

    // Saving Throws

    #region Skills
    public Skill Acrobatics { get; set; }
    public Skill AnimalHandling { get; set; }
    public Skill Arcana { get; set; }
    public Skill Athletics { get; set; }
    public Skill Deception { get; set; }
    public Skill History { get; set; }
    public Skill Insight { get; set; }
    public Skill Intimidation { get; set; }
    public Skill Investigation { get; set; }
    public Skill Medicine { get; set; }
    public Skill Nature { get; set; }
    public Skill Perception { get; set; }
    public Skill Performance { get; set; }
    public Skill Persuasion { get; set; }
    public Skill Religion { get; set; }
    public Skill SlightOfHand { get; set; }
    public Skill Stealth { get; set; }
    public Skill Survival { get; set; }
    #endregion

    // Feats?

    // Equipment

    // Spellcasting

    // Control and metadata properties
    public bool IsNewCharater { get; set; }

    [JsonIgnore]
    public bool IsInitialAbilityAllocation { get; set; }

    [JsonIgnore]
    public IEnumerable<Skill> AllSkills => 
        new List<Skill> 
        {
            Acrobatics, 
            AnimalHandling,
            Arcana,
            Athletics,
            Deception,
            History,
            Insight,
            Intimidation,
            Investigation,
            Medicine,
            Nature,
            Perception,
            Performance,
            Persuasion,
            Religion,
            SlightOfHand,
            Stealth,
            Survival
        };

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

        //ProficiencyBonus = 2;
        //ArmorClass = 13;
        //MaxHitPoints = 10;
        //CurrentHitPoints = MaxHitPoints;
        //Initiative = 2;
        //PassivePerception = 12;

        IsNewCharater = true;
        IsInitialAbilityAllocation = true;
    }
}
