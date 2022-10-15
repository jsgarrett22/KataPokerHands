using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
	public string Name { get; set; }
	public List<Card> Cards { get; set; }
	public Card WinningCard { get; set; }
	public Player(string name)
	{
		this.Name = name;
		Cards = new List<Card>();
	}

	public void AddCard(Card card)
	{
		Cards.Add(card);
	}

	public void DisplayHand()
	{
		Console.Write($"{Name} -");
		foreach (Card card in Cards)
		{
			Console.Write($" {card.Value} ");
		}
		Console.WriteLine();
	}

    public bool HasFullHouse()
    {
        return false;
    }

    public bool HasFlush()
	{
		return false;
	}

	public bool HasStraight()
	{
		return false;
	}

    public bool HasStraightFlush()
    {
        return false;
    }

    public bool HasFourOfAkind()
    {
        return false;
    }

    public bool HasThreeOfAKind()
    {
        return false;
    }

    public bool HasTwoPair()
    {
        return false;
    }

    public bool HasAPair()
    {
		List<Card> matches = new List<Card>();
		for (int i = 0; i < this.Cards.Count; i++)
		{
			int value = this.Cards[i].Value;
			if (this.Cards.FindAll(card => card.Value.Equals(value)).Count == 2)
			{
				matches.Add(this.Cards[i]);
			}
		}
		if (matches.Count == 2)
		{
			WinningCard = matches[0];
			return true;
		} 
		else
		{
            return false;
        }
    }

	public string Hand()
	{
		if (HasFullHouse()) return "full house";
		if (HasFlush()) return "flush";
		if (HasStraight()) return "straight";
		if (HasFourOfAkind()) return "four of a kind";
		if (HasThreeOfAKind()) return "three of a kind";
		if (HasTwoPair()) return "two pair";
		if (HasAPair()) return "a pair";
		Cards.OrderBy(card => card.Value).ToList();
		WinningCard = Cards[Cards.Count - 1];
		return "high card";
	}
}
