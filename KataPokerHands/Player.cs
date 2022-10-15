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
		// Check every card in the hand and compare if they have equal value.
		// If we find at least 2 matches, then we have a pair and we can add
		// to our matches. If matches only two matches were found, that'll
		// give us a count of 2, which we will set our WinningCard to and return true
		List<Card> matches = new List<Card>();
		for (int i = 0; i < this.Cards.Count; i++)
		{
			int value = this.Cards[i].Value;
			if (this.Cards.FindAll(x => x.Value.Equals(value)).Count == 2)
			{
				matches.Add(this.Cards[i]);
			}
		}
		if (matches.Count == 2)
		{
			WinningCard = matches[0];
			return true;
		} else
		{
            return false;
        }
    }

	// This is the method we will run on a player to determine the WinningCard given for the player
	// and what kind of hand the player has given the cards. If it falls all the way down to the bottom,
	// then the player's highest card is the winning card and we need to order the cards by their value,
	// least to greatest and grab the highest card in the collection.
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
		return $"high card: {DetermineHighCard(WinningCard)}";
	}

	
	private string DetermineHighCard(Card card)
	{
		int value = card.Value;
		if (value == 14)
		{
			return "Ace";
		} else if (value == 13)
		{
			return "King";
		} else if (value == 12)
		{
			return "Queen";
		} else if (value == 11)
		{
			return "Jack";
		} else if (value == 10)
		{
			return "10";
		} else
		{
			return value.ToString();
		}
	}
}
