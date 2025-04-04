using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Utilities.Services;

public static class ValueCalculator
{
    public static void CalculateArmorClass(this Character character)
    {
        int ac = StaticBaseValues.BaseArmorClass;
        ac += character.Dexterity.Modifier; // limit for medium armor, don't apply for heavy armor
        ac += character.CharacterClass.ArmorClassBonus(character);

        character.ArmorClass = ac;
    }

    public static void CalculateMaxHitPoints(this Character character)
    {
        var hitpoints = CalculateFirstLevelMaxHitpoints(
            character.CharacterClass.HitDice.Die, 
            character.Constitution.Modifier);

        if(character.Level > 1)
        {
            hitpoints += CalculateSubsequentLevelMaxHitpoints(
                character.CharacterClass.HitDice.Die,
                character.Constitution.Modifier,
                character.CharacterClass.ClassLevel);
        }

        character.MaxHitPoints = hitpoints;
    }

    public static void CalculateMaxHitDice(this Character character)
    {
        character.CharacterClass.HitDice.MaxAmount = character.CharacterClass.ClassLevel;
    }

    public static void CalculateInititative(this Character character)
    {
        character.Initiative = character.Dexterity.Modifier;
    }

    public static void CalculatePassivePerception(this Character character)
    {
        character.PassivePerception = StaticBaseValues.BasePerception + character.Wisdom.Modifier; // Todo: placeholder, actuallz needs to be calculated from Perception
    }

    public static void CalculateProficiencyBonus(this Character character)
    {
        character.ProficiencyBonus = (character.Level / 4) + 2;
    }

    private static int CalculateFirstLevelMaxHitpoints(int hitDieValue, int conModifier)
    {
        return hitDieValue + conModifier;
    }

    private static int CalculateSubsequentLevelMaxHitpoints(int hitDieValue, int conModifier, int classLevel)
    {
        return ((hitDieValue/2 + 1) + conModifier) * classLevel;
    }
}
