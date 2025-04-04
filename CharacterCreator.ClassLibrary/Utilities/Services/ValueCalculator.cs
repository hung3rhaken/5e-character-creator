using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Utilities.Services;

public static class ValueCalculator
{
    public static void CalculateArmorClass(Character character)
    {
        int ac = StaticBaseValues.BaseArmorClass;
        ac += character.Dexterity.Modifier; // limit for medium armor, don't apply for heavy armor
        ac += character.CharacterClass.ArmorClassBonus(character);

        character.ArmorClass = ac;
    }
}
