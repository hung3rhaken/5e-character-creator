namespace CharacterCreator.ClassLibrary.Main.CharacterData;

public class Skill
{
    public string Name { get; set; }
    public Ability BaseAbility { get; set; }
    public bool HasProficiency { get; set; }
    public bool HasExpertise { get; set; }
    public int Modifier { get; set; }

    public Skill()
    {
        
    }

    public Skill(string name, Ability baseAbility)
    {
        Name = name;
        BaseAbility = baseAbility;
        HasProficiency = false;
        HasExpertise = false;
        Modifier = BaseAbility.Modifier;
    }
}
