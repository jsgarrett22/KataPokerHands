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
                "Black: 2H 3D 5S 9C KD  White: 2D 3H 5C 9S KH"
            };

            InputController inputController = new InputController(sampleInputs[0]);
            Game game = new Game(inputController);

            // GET PLAYER NAMES
            //Console.WriteLine($"Total players {inputController.PlayerNames.Count}: {inputController.PlayerNames[0]}, {inputController.PlayerNames[1]}");
            // GET CARD COUNT
            //Console.WriteLine($"Total Cards in Cards list: {inputController.Cards.Count}");
            //game.DisplayPlayers();
            //game.Players.ForEach(p => p.DisplayHand());
            //game.DisplayWinner();

            foreach (var player in game.Players)
            {
                Console.WriteLine(player.Name);
                foreach (var card in player.Cards)
                {
                    Console.Write(card.ToString() + " ");
                }
            }
            // END
            Console.ReadLine();
        }
    }
}
