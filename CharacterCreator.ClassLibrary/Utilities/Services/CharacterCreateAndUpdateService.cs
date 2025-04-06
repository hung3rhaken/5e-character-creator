using CharacterCreator.ClassLibrary.Main.CharacterClasses;
using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Utilities.Services;

public static class CharacterCreateAndUpdateService
{
    private static readonly Dictionary<CharacterClassType, Func<int, CharacterClass>> _factory = new()
    {
        { CharacterClassType.Barbarian, (int classLevel) => new Barbarian(classLevel) },
        { CharacterClassType.Bard, (int classLevel) => new Bard(classLevel) },
        { CharacterClassType.Cleric, (int classLevel) => new Cleric(classLevel) },
        { CharacterClassType.Druid, (int classLevel) => new Druid(classLevel) },
        { CharacterClassType.Fighter, (int classLevel) => new Fighter(classLevel) },
        { CharacterClassType.Monk, (int classLevel) => new Monk(classLevel) },
        { CharacterClassType.Paladin, (int classLevel) => new Paladin(classLevel) },
        { CharacterClassType.Ranger, (int classLevel) => new Ranger(classLevel) },
        { CharacterClassType.Rogue, (int classLevel) => new Rogue(classLevel) },
        { CharacterClassType.Sorcerer, (int classLevel) => new Sorcerer(classLevel) },
        { CharacterClassType.Warlock, (int classLevel) => new Warlock(classLevel) },
        { CharacterClassType.Wizard, (int classLevel) => new Wizard(classLevel) }
    };

    public static Character CreateNewCharacter(CharacterClassType characterClassType, int characterLevel = 1)
    {
        var characterClass = GetCharacterClassInstance(characterClassType);
        
        var character = new Character(characterClass)
        {
            Level = characterLevel
        };        

        character.UpdateCharacterValues();

        return character;
    }

    public static void CharacterLevelUp(Character character, int characterLevel)
    {
        character.Level = characterLevel;
        character.CharacterClass.ClassLevel = characterLevel;

        UpdateCharacterValues(character);
    }

    public static void UpdateCharacterValues(this Character character)
    {
        if (character.IsNewCharater)
        {
            if (character.IsInitialAbilityAllocation)
            {
                character.CharacterClass.ApplyDefaultAbilityValues(character);
                character.InitialiseSkills();
            }            
        }

        character.CalculateProficiencyBonus();
        character.CalculateArmorClass();
        character.CalculateMaxHitDice();
        character.CalculateMaxHitPoints();
        character.CalculateInititative();
        character.CalculatePassivePerception();
    }

    public static CharacterClass GetCharacterClassInstance(CharacterClassType type, int classLevel = 1)
    {

        if (_factory.TryGetValue(type, out var characterClass))
        {
            return characterClass(classLevel);
        }
        // Optionally throw or return a default if type is not found.
        throw new ArgumentException($"Invalid character class type: {type}");
    }

    private static void InitialiseSkills(this Character character)
    {       
        character.Acrobatics      = new Skill("Acrobatics", character.Dexterity);
        character.AnimalHandling  = new Skill("AnimalHandling", character.Wisdom);
        character.Arcana          = new Skill("Arcana", character.Intelligence);
        character.Athletics       = new Skill("Athletics", character.Strength);
        character.Deception       = new Skill("Deception", character.Charisma);
        character.History         = new Skill("History", character.Intelligence);
        character.Insight         = new Skill("Insight", character.Wisdom);
        character.Intimidation    = new Skill("Intimidation", character.Charisma);
        character.Investigation   = new Skill("Investigation", character.Intelligence);
        character.Medicine        = new Skill("Medicine", character.Wisdom);
        character.Nature          = new Skill("Nature", character.Intelligence);
        character.Perception      = new Skill("Perception", character.Wisdom);
        character.Performance     = new Skill("Performance", character.Charisma);
        character.Persuasion      = new Skill("Persuasion", character.Charisma);
        character.Religion        = new Skill("Religion", character.Intelligence);
        character.SlightOfHand    = new Skill("SlightOfHand", character.Dexterity);
        character.Stealth         = new Skill("Stealth", character.Dexterity);
        character.Survival        = new Skill("Survival", character.Wisdom);
    }
}
