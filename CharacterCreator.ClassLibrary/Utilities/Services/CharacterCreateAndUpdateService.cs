using CharacterCreator.ClassLibrary.Main.CharacterClasses;
using CharacterCreator.ClassLibrary.Main.CharacterData;
using CharacterCreator.ClassLibrary.Main.Origin.CharacterSpecies;

namespace CharacterCreator.ClassLibrary.Utilities.Services;

public static class CharacterCreateAndUpdateService
{
    private static readonly Dictionary<CharacterClassType, Func<int, CharacterClass>> _classes = new()
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

    private static readonly Dictionary<CharacterSpeciesType, Func<Species>> _species = new()
    {
        { CharacterSpeciesType.Aasimar, () => new Aasimar() },
        { CharacterSpeciesType.Dragonborn, () => new Dragonborn() },
        { CharacterSpeciesType.Dwarf, () => new Dwarf() },
        { CharacterSpeciesType.Elf, () => new Elf() },
        { CharacterSpeciesType.Gnome, () => new Gnome() },
        { CharacterSpeciesType.Goliath, () => new Goliath() },
        { CharacterSpeciesType.Halfling, () => new Halfling() },
        { CharacterSpeciesType.Human, () => new Human() },
        { CharacterSpeciesType.Orc, () => new Orc() },
        { CharacterSpeciesType.Tiefling, () => new Tiefling() }
    };

    public static Character CreateNewCharacter(CharacterClassType characterClassType, CharacterSpeciesType speciesType, int characterLevel = 1)
    {
        var characterClass = GetCharacterClassInstance(characterClassType);
        var species = GetCharacterSpeciesInstance(speciesType);
        
        var character = new Character(characterClass, species)
        {
            Level = characterLevel
        };

        UpdateCharacterValues(character);

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
                character.Species.ApplyInitialSpeciesBenefits(character);
            }
        }

        character.CalculateProficiencyBonus();
        character.CalculateSkillProficiencies();
        character.CalculateArmorClass();
        character.CalculateMaxHitDice();
        character.CalculateMaxHitPoints();
        character.CalculateInititative();
        character.CalculatePassivePerception();

        character.Species.ApplySpeciesBenefits(character);
    }

    public static CharacterClass GetCharacterClassInstance(CharacterClassType type, int classLevel = 1)
    {

        if (_classes.TryGetValue(type, out var characterClass))
        {
            return characterClass(classLevel);
        }
        // Optionally throw or return a default if type is not found.
        throw new ArgumentException($"Invalid character class type: {type}");
    }

    public static Species GetCharacterSpeciesInstance(CharacterSpeciesType type)
    {

        if (_species.TryGetValue(type, out var species))
        {
            return species();
        }
        // Optionally throw or return a default if type is not found.
        throw new ArgumentException($"Invalid character class type: {type}");
    }
}
