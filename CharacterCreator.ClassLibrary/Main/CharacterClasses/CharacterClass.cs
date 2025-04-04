using System.Text.Json.Serialization;

namespace CharacterCreator.ClassLibrary.Main.CharacterClasses;

[JsonDerivedType(typeof(Fighter), "Fighter")]
[JsonDerivedType(typeof(Wizard), "Wizard")]
public abstract class CharacterClass
{
    public virtual string Name { get; set; } = "DefaultClass";
    public virtual int ClassLevel { get; set; }

    /// <summary>
    /// Applies class benefits to the character.
    /// </summary>
    /// <param name="character"></param>
    public virtual void ApplyClassBenefits(Character character)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Applies default class ability scores to the character
    /// </summary>
    /// <param name="character"></param>
    public virtual void ApplyDefaultAbilityValues(Character character)
    {
        throw new NotImplementedException();
    }
}
