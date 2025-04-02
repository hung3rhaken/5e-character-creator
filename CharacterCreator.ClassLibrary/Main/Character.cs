using CharacterCreator.ClassLibrary.Main.CharacterClasses;

namespace CharacterCreator.ClassLibrary.Main;

public class Character<T> : CharacterBase where T : ICharacterClass, new()
{
    //public string Name { get; set; }
    public T CharacterClass { get; set; }
    //public string CharacterClassName { get; set; }
    //public string Species { get; set; }
    //public int Level { get; set; }
    //public Ability Strength { get; set; }
    //public Ability Dexterity { get; set; }
    //public Ability Constitution { get; set; }
    //public Ability Intelligence { get; set; }
    //public Ability Wisdom { get; set; }
    //public Ability Charisma { get; set; }

    public Character()
    {
        CharacterClass = new T();
        CharacterClassName = CharacterClass.Name;
        Name = "New Guy";
        Species = "Human";
        Level = 1;
        Strength = new Ability("Strength", 10);
        Dexterity = new Ability("Dexterity", 10);
        Constitution = new Ability("Constitution", 10);
        Intelligence = new Ability("Intelligence", 10);
        Wisdom = new Ability("Wisdom", 10);
        Charisma = new Ability("Charisma", 10);

        CharacterClass.ApplyDefaults(this);
    }
}
