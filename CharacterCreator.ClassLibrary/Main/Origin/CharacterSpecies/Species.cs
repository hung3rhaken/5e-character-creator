using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.Origin.CharacterSpecies;

public abstract class Species
{
    public abstract string Name { get; }

    public virtual void ApplySpeciesBenefits(Character character)
    {

    }

    public virtual void ApplyInitialSpeciesBenefits(Character character)
    {

    }
}
