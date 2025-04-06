using CharacterCreator.ClassLibrary.Main.CharacterData;
using System.Text.Json.Serialization;

namespace CharacterCreator.ClassLibrary.Main.Origin.CharacterSpecies;

[JsonDerivedType(typeof(Aasimar), "Aasimar")]
[JsonDerivedType(typeof(Dragonborn), "Dragonborn")]
[JsonDerivedType(typeof(Dwarf), "Dwarf")]
[JsonDerivedType(typeof(Elf), "Elf")]
[JsonDerivedType(typeof(Gnome), "Gnome")]
[JsonDerivedType(typeof(Goliath), "Goliath")]
[JsonDerivedType(typeof(Halfling), "Halfling")]
[JsonDerivedType(typeof(Human), "Human")]
[JsonDerivedType(typeof(Orc), "Orc")]
[JsonDerivedType(typeof(Tiefling), "Tiefling")]
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
