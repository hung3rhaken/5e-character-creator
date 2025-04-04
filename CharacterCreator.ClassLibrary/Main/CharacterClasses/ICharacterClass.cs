namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

public interface ICharacterClass
{
    abstract string Name { get; }
    abstract int ClassLevel { get; set; }

    /// <summary>
    /// Applies class benefits to the character.
    /// </summary>
    /// <param name="character"></param>
    void ApplyClassBenefits(Character character);

    /// <summary>
    /// Applies default class ability scores to the character
    /// </summary>
    /// <param name="character"></param>
    void ApplyDefaultAbilityValues(Character character);
}
