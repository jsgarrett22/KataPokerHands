using System;
using System.Collections;
using System.Collections.Generic;

/**
 * Kata Poker Hand
 * By: Joshua S. Garrett
 * 10/14/2022
 */
namespace KataPokerHands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sampleInputs = {
                "Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH",
                "Black: 2H 4S 4C 2D 4H  White: 2S 8S AS QS 3S",
                "Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C KH",
                "Black: 2H 3D 5S 9C KD  White: 2D 3H 5C 9S KH",
                "Black: 2H 2D 5S 9C KD  White: 3D 3H 4C 4S KH",     // Pair and TwoPair
            };

            InputController inputController = new InputController(sampleInputs[4]);
            Game game = new Game(inputController);
            Console.WriteLine(game.Players[1].Hand());
            // GET PLAYER NAMES
            //Console.WriteLine($"Total players {inputController.PlayerNames.Count}: {inputController.PlayerNames[0]}, {inputController.PlayerNames[1]}");
            // GET CARD COUNT
            //Console.WriteLine($"Total Cards in Cards list: {inputController.Cards.Count}");
            //game.DisplayPlayers();
            //game.Players.ForEach(p => p.DisplayHand());
            //game.DisplayWinner();
            // END
            Console.ReadLine();
        }
    }
}
