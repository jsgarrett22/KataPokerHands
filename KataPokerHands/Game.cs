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

	public void DisplayWinner()
	{
		// White wins. -with high card: Ace
		// Black wins. - with full house: 4 over 2
		// Black wins. -with high card: 9
		// Tie.

		// If there is a winner, display winner with winner's hand
		// else display Tie.
        Console.WriteLine($"{Winner} wins. -with Winner.Hand: -Card-");
        Console.WriteLine($"Tie.");
    }
}
