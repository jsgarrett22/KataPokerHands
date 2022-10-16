using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

public class Player
{
	public string Name { get; set; }
	public List<Card> Cards { get; set; }
	public Card WinningCard { get; set; }
	public Player(string name)
	{
		this.Name = name;
		Cards = new List<Card>();
		WinningCard = null;
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

    // Straight flush: 5 cards of the same suit with consecutive values.
	// Ranked by the highest card in the hand.
    public bool HasStraightFlush()
    {
		return false;
    }

    // Four of a kind: 4 cards with the same value.
	// Ranked by the value of the 4 cards.
    public bool HasFourOfAkind()
    {
        List<Card> fours = new List<Card>();
        for (int i = 0; i < this.Cards.Count; i++)
        {
            int currentValue = this.Cards[i].Value;
            fours = this.Cards.FindAll(card => card.Value.Equals(currentValue));
            if (fours.Count == 4)
            {
                WinningCard = fours[0];
                return true;
            }
        }
        return false;
    }

    // Full House: 3 cards of the same value, with the remaining 2 cards forming a pair.
	// Ranked by the value of the 3 cards.
    public bool HasFullHouse()
    {
		return false;
    }

    // Flush: Hand contains 5 cards of the same suit.
	// Hands which are both flushes are ranked using the rules for High Card.
    public bool HasFlush()
	{
		return false;
	}

    // Straight: Hand contains 5 cards with consecutive values.
	// Hands which both contain a straight are ranked by their highest card.
    public bool HasStraight()
	{
        List<Card> cards = new List<Card>();
        cards = this.Cards.OrderBy(card => card.Value).ToList();
        for (int i = 0; i < this.Cards.Count - 1; i++)
        {
            Card currentCard = cards[i];
            Card nextCard = cards[i + 1];
            if (currentCard.Value + 1 != nextCard.Value)
            {
                return false;       // a single false case ensures the user doesn't have a flush
            }
        }
        cards = this.Cards.OrderByDescending(card => card.Value).ToList();
        WinningCard = cards[0];
		return true;
	}

	// Three of a Kind: Three of the cards in the hand have the same value.
	// Hands which both contain three of a kind are ranked by the value of the 3 cards.
	public bool HasThreeOfAKind()
    {
		List<Card> threes = new List<Card>();
		for (int i = 0; i < this.Cards.Count; i++)
		{
			int currentValue = this.Cards[i].Value;
			threes = this.Cards.FindAll(card => card.Value.Equals(currentValue));
            if (threes.Count == 3)
            {
                WinningCard = threes[0];
                return true;
            }
        }
		return false;
    }

    // Two Pairs: The hand contains 2 different pairs.
	// Hands which both contain 2 pairs are ranked by the value of their highest pair.
	// Hands with the same highest pair are ranked by the value of their other pair.
	// If these values are the same the hands are ranked by the value of the remaining card.
    public bool HasTwoPair()
    {
        List<Card> pairs = new List<Card>();
        List<Card> tmp = new List<Card>();
        for (int i = 0; i < this.Cards.Count; i++)
        {
            int currentValue = this.Cards[i].Value;
            tmp = this.Cards.FindAll(card => card.Value.Equals(currentValue));
            if (tmp.Count == 2)
            {
                pairs.Add(this.Cards[i]);
            }
        }
        if (pairs.Count == 4)
        {
			pairs = pairs.OrderByDescending(card => card.Value).ToList();
            WinningCard = pairs[0];
            return true;
        }
        else
        {
            return false;
        }
    }

    // Pair: 2 of the 5 cards in the hand have the same value.
	// Hands which both contain a pair are ranked by the value of the cards forming the pair.
	// If these values are the same, the hands are ranked by the values of the cards not forming the pair,
	// in decreasing order.
    public bool HasAPair()
    {
		// Check every card in the hand and compare if they have equal value.
		// If we find at least 2 matches, then we have a pair and we can add
		// to our matches. If matches only two matches were found, that'll
		// give us a count of 2, which we will set our WinningCard to and return true
		List<Card> pairs = new List<Card>();
		List<Card> tmp = new List<Card>();
		for (int i = 0; i < this.Cards.Count; i++)
		{
			int currentValue = this.Cards[i].Value;
			tmp = this.Cards.FindAll(card => card.Value.Equals(currentValue));
			if (tmp.Count == 2)
			{
				pairs.Add(this.Cards[i]);
			}
		}
		if (pairs.Count == 2)
		{
			WinningCard = pairs[0];
			return true;
		} else
		{
			return false;
		}
    }


    // High Card: Hands which do not fit any higher category are ranked by the value of their highest card.
	// If the highest cards have the same value, the hands are ranked by the next highest, and so on.

    // This is the method we will run on a player to determine the WinningCard given for the player
    // and what kind of hand the player has given the cards. If it falls all the way down to the bottom,
    // then the player's highest card is the winning card.
    public string Hand()
	{
		if (HasFullHouse())
		{
            return "full house";
        } else if (HasFlush())
		{
			return "flush";
		} else if (HasStraight())
		{
			return "straight";
		} else if (HasFourOfAkind())
		{
			return "four of a kind";
        } else if (HasThreeOfAKind())
		{
            return "three of a kind";
        } else if (HasTwoPair())
		{
			return "two pair";
		} else if (HasAPair())
		{
			return "a pair";
		} else
		{
            this.Cards = Cards.OrderByDescending(card => card.Value).ToList();
            WinningCard = Cards[0];
            return $"high card: {DetermineHighCard(WinningCard)}";
        }
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
