using CharacterCreator.ClassLibrary.Main.CharacterData;
using System.Text.RegularExpressions;
using System;

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
        character.CurrentHitPoints = hitpoints;
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
        character.PassivePerception = StaticBaseValues.BasePerception + character.Perception.Modifier; // Todo: placeholder, actually needs to be calculated from Perception
    }

    public static void CalculateProficiencyBonus(this Character character)
    {
        character.ProficiencyBonus = (int)(1 + Math.Ceiling((double)character.Level / 4));
    }

    public static void CalculateSkillProficiencies(this Character character)
    {
        character.Acrobatics.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.AnimalHandling.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Arcana.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Athletics.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Deception.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.History.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Insight.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Intimidation.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Investigation.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Medicine.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Nature.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Perception.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Performance.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Persuasion.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Religion.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.SlightOfHand.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Stealth.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
        character.Survival.CalculateSkillProficiencyModifier(character.ProficiencyBonus);
    }

    private static int CalculateFirstLevelMaxHitpoints(int hitDieValue, int conModifier)
    {
        return hitDieValue + conModifier;
    }

    private static int CalculateSubsequentLevelMaxHitpoints(int hitDieValue, int conModifier, int classLevel)
    {
        return ((hitDieValue/2 + 1) + conModifier) * classLevel;
    }

    private static void CalculateSkillProficiencyModifier(this Skill skill, int proficiencyBonus)
    {
        skill.Modifier = skill.BaseAbility.Modifier;

        if (skill.HasProficiency)
        {
            skill.Modifier += proficiencyBonus;

            if (skill.HasExpertise) 
            {
                skill.Modifier += proficiencyBonus;
            }
        }
    }
}
