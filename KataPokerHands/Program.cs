using System;

/**
 * Manifest Solutions - Poker Hands Kata (Coding Dojo)
 * By: Joshua S. Garrett
 * 10/16/2022
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
                                                                    // [ADDITIONAL TEST INPUTS]
                "Black: 2H 2D 5S 9C KD  White: 3D 3H 4C 4S KH",     // Pair and Two Pair 
                "Black: 2H 2D 2S 9C KD  White: 3D 3H 3C 3S KH",     // Three and Four of a Kind
                "Black: 2H 3D 4S 5C 6C  White: 2H 3H 5H 8H KH",     // Straight and Flush
                "Black: 2H 3H 4H 5H 6H  White: 2D 2H 2C 3D 3H",     // Straight-Flush and Full House
                "Black: 2H 3H 4H 5H 6H  White: 2H 3H 4H 5H 6H",     // Straight-Flush tie.
            };
            for (int i = 4; i < 9; i++)
            {
                InputController inputController = new InputController(sampleInputs[i]);
                Game game = new Game(inputController);
                game.DetermineWinner();
            }

            // END
            Console.ReadLine();
        }
    }
}
