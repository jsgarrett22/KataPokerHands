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
                "Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH",     // White wins. - with high card: Ace 
                "Black: 2H 4S 4C 2D 4H  White: 2S 8S AS QS 3S",     // Black wins. - with full house: 4 over 2
                "Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C KH",     // Black wins. - with high card: 9
                "Black: 2H 3D 5S 9C KD  White: 2D 3H 5C 9S KH",     // Tie.

                "Black: 2H 2D 5S 9C KD  White: 3D 3H 4C 4S KH",     // Pair and Two Pair
                "Black: 2H 2D 2S 9C KD  White: 3D 3H 3C 3S KH",     // Three and Four of a Kind
                "Black: 2H 3D 4S 5C 6C  White: 2H 3H 5H 8H KH",     // Straight and Flush
                "Black: 2H 3H 4H 5H 6H  White: 2D 2H 2C 3D 3H"      // Straight-Flush and Full House
            };

            InputController inputController = new InputController(sampleInputs[4]);
            Game game = new Game(inputController);
            Console.WriteLine(game.Players[0].Hand());
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
