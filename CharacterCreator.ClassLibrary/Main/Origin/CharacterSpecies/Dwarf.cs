using CharacterCreator.ClassLibrary.Main.CharacterData;

namespace CharacterCreator.ClassLibrary.Main.Origin.CharacterSpecies;

public class Dwarf : Species
{
    public override string Name => "Dwarf";

    public override void ApplySpeciesBenefits(Character character)
    {
        var bonusHitpoints = character.Level;
        character.MaxHitPoints += bonusHitpoints;
        character.CurrentHitPoints += bonusHitpoints;
    }
}
