public class Card
{
    public int Value { get; set; }
    public string Suit { get; set; }

    public Card(int value, string suit)
    {
        this.Value = value;
        Suit = suit;
    }

    public override string ToString()
    {
        return $"{Value}{Suit}";
    }
}
