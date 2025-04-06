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
    public List<Skill> AllSkills { get; init; }

    public Character()
    {
        
    }

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

        InitialiseAbilities();
        characterClass.ApplyDefaultAbilityValues(this);
        InitialiseSkills();

        AllSkills = new List<Skill>
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

        IsNewCharater = true;
        IsInitialAbilityAllocation = true;
    }

    private void InitialiseAbilities()
    {
        Strength = new Ability("Strength", 10);
        Dexterity = new Ability("Dexterity", 10);
        Constitution = new Ability("Constitution", 10);
        Intelligence = new Ability("Intelligence", 10);
        Wisdom = new Ability("Wisdom", 10);
        Charisma = new Ability("Charisma", 10);
    }

    private void InitialiseSkills()
    {
        Acrobatics = new Skill("Acrobatics", Dexterity);
        AnimalHandling = new Skill("AnimalHandling", Wisdom);
        Arcana = new Skill("Arcana", Intelligence);
        Athletics = new Skill("Athletics", Strength);
        Deception = new Skill("Deception", Charisma);
        History = new Skill("History", Intelligence);
        Insight = new Skill("Insight", Wisdom);
        Intimidation = new Skill("Intimidation", Charisma);
        Investigation = new Skill("Investigation", Intelligence);
        Medicine = new Skill("Medicine", Wisdom);
        Nature = new Skill("Nature", Intelligence);
        Perception = new Skill("Perception", Wisdom);
        Performance = new Skill("Performance", Charisma);
        Persuasion = new Skill("Persuasion", Charisma);
        Religion = new Skill("Religion", Intelligence);
        SlightOfHand = new Skill("SlightOfHand", Dexterity);
        Stealth = new Skill("Stealth", Dexterity);
        Survival = new Skill("Survival", Wisdom);
    }
}
