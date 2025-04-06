using System.Text.Json.Serialization;

namespace CharacterCreator.ClassLibrary.Main.Properties;

public class HitDice
{
    public int Die { get; set; }

    public int MaxAmount { get; set; }

    public HitDice()
    {
        
    }

    public HitDice(int die, int maxAmount)
    {
        Die = die;
        MaxAmount = maxAmount;
    }

    public override string ToString()
    {
        return $"D{Die}";
    }
}
