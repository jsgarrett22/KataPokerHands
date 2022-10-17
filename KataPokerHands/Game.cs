using KataPokerHands;
using System;
using System.Collections.Generic;

public class Game
{
	public List<Player> Players { get; set; }
	public Player Winner { get; set; }
	public InputController Data { get; set; }

	public Game(object input)
	{
		// Create new players from InputController data
		Players = new List<Player>();
		this.Data = (InputController)input;
		CreatePlayers();
		SplitHands(Data);
	}

	public void CreatePlayers()
	{
		// Populate the player with name.
		foreach (var name in Data.PlayerNames)
		{
			Players.Add(new Player(name));
		}
	}

	public void DisplayPlayers()
	{
		foreach (Player player in Players)
		{
			Console.WriteLine($"{player.Name} has the following hand:");
		}
	}

	public void SplitHands(InputController data)
	{
		// Give Player 1 first 5 cards
		for (int i = 0; i < 5; i++)
		{
			Players[0].Cards.Add(data.Cards[i]);
		}

		// Give Player 2 remaining 5 cards
		for (int i = 5; i < 10; i++)
		{
			Players[1].Cards.Add(data.Cards[i]);
		}
	}

	public void DetermineWinner()
	{
		Player player1 = this.Players[0];
		Player player2 = this.Players[1];

		if (DeterminePlayerRank(player1.Hand()) > DeterminePlayerRank(player2.Hand()))
		{
			Console.WriteLine($"{player1.Name} wins. - with {player1.Hand()}: {player1.WinningCard}");
		}
		else if (DeterminePlayerRank(player1.Hand()) < DeterminePlayerRank(player2.Hand()))
		{
			Console.WriteLine($"{player2.Name} wins. - with {player2.Hand()}: {player2.WinningCard}");
		}
		else if (DeterminePlayerRank(player1.Hand()) == DeterminePlayerRank(player2.Hand()))
		{
			DetermineEqualHandWinner(player1, player2);
		}
	}

	public HandRank DeterminePlayerRank(string hand)
	{
		switch (hand)
		{
			case "high card":
				return HandRank.HIGHCARD;
			case "a pair":
				return HandRank.PAIR;
			case "two pair":
				return HandRank.TWOPAIR;
			case "three of a kind":
				return HandRank.THREEOFAKIND;
			case "straight":
				return HandRank.STRAIGHT;
			case "flush":
				return HandRank.FLUSH;
			case "full house":
				return HandRank.FULLHOUSE;
			case "four of a kind":
				return HandRank.FOUROFAKIND;
			case "straight flush":
				return HandRank.FOUROFAKIND;
			default:
				return HandRank.HIGHCARD;
		}
	}

	// CARD RANKINGS - LOWEST TO GREATEST
	public enum HandRank
	{
		HIGHCARD,
		PAIR,
		TWOPAIR,
		THREEOFAKIND,
		STRAIGHT,
		FLUSH,
		FULLHOUSE,
		FOUROFAKIND,
		STRAIGHTFLUSH
	}

	private void DetermineEqualHandWinner(Player player1, Player player2)
	{
		if (player1.WinningCard.Value > player2.WinningCard.Value)
		{
			Console.WriteLine($"{player1.Name} wins. - with {player1.Hand()}: {CardValueToString(player1.WinningCard.Value)}");
		}
		else if (player1.WinningCard.Value < player2.WinningCard.Value)
		{
			Console.WriteLine($"{player2.Name} wins. - with {player2.Hand()}: {CardValueToString(player2.WinningCard.Value)}");
		}
		else
		{
			for (int i = 0; i < player1.Cards.Count; i++)
			{
				if (player1.Cards[i].Value > player2.Cards[i].Value)
				{
					Console.WriteLine($"{player1.Name} wins. - with {player1.Hand()}: {CardValueToString(player1.Cards[i].Value)}");
					break;
				}
				else if (player1.Cards[i].Value < player2.Cards[i].Value)
				{
					Console.WriteLine($"{player2.Name} wins. - with {player2.Hand()}: {CardValueToString(player2.Cards[i].Value)}");
					break;
				}
				else if (i == 4)
				{
					Console.WriteLine("Tie.");
					break;
				}
				else
				{
					continue;
				}
			}
		}
	}

	private string CardValueToString(int value)
	{
		switch (value)
		{
			case 0:
			case 1:
			case 2:
				return "2";
			case 3:
				return "3";
			case 4:
				return "4";
			case 5:
				return "5";
			case 6:
				return "6";
			case 7:
				return "7";
			case 8:
				return "8";
			case 9:
				return "9";
			case 10:
				return "10";
			case 11:
				return "Jack";
			case 12:
				return "Queen";
			case 13:
				return "King";
			case 14:
				return "Ace";
			default:
				return "";
		}
	}
}
