using System;
using System.Collections.Generic;

namespace KataPokerHands
{
    public class InputController
    {
        public List<string> PlayerNames { get; set; }
        public List<Card> Cards { get; set; }
        public string[] ParsedInput { get; set; }
        public string[] Suits { get; set; }
        public int[] Values { get; set; }

        public InputController(string input)
        {
            PlayerNames = new List<string>();
            Cards = new List<Card>();
            ParsedInput = this.Parse(input);
            Suits = this.ParseSuits(ParsedInput);
            Values = this.ParseValues(ParsedInput);
            LoadCards(Values, Suits);
        }

        // Parses the initial input and extracts the Player names
        // THIS SHOULD BE REDONE IN THE FUTURE TO JUST EXTRACT PLAYER NAMES
        private string[] Parse(string input)
        {
            string[] tmp = input.Split(' ');

            // EXTRACT PLAYER NAMES FROM SAMPLE INPUT AND TRIM
            foreach (string s in tmp)
            {
                if (s.Equals("Black:") || s.Equals("White:"))
                {
                    PlayerNames.Add(s.Remove(s.Length - 1, 1));
                }
            }
            return tmp;
        }

        // EXTRACT SUITS FROM INPUT
        private string[] ParseSuits(string[] input)
        {
            string[] tmp = input;
            string[] suits = new string[tmp.Length];

            for (int i = 0; i < tmp.Length; i++)
            {
                // if input indexes are player names / spaces
                if ((i == 0) || (i == 6) || (i == 7))
                {
                    continue;
                }
                else
                {
                    suits[i] = tmp[i].Substring(tmp[i].Length - 1);
                }
            }
            return suits;
        }

        // EXTRACT VALUES FROM INPUT
        private int[] ParseValues(string[] input)
        {
            string[] tmp = input;
            int[] values = new int[tmp.Length];

            for (int i = 0; i < tmp.Length; i++)
            {
                // if input indexes are player names / spaces
                if ((i == 0) || (i == 6) || (i == 7))
                {
                    continue;
                }
                else
                {
                    if (tmp[i].StartsWith("A"))
                    {
                        values[i] = 14;
                    }
                    else if (tmp[i].StartsWith("K"))
                    {
                        values[i] = 13;
                    }
                    else if (tmp[i].StartsWith("Q"))
                    {
                        values[i] = 12;
                    }
                    else if (tmp[i].StartsWith("J"))
                    {
                        values[i] = 11;
                    }
                    else if (tmp[i].StartsWith("10"))
                    {
                        values[i] = 10;
                    }
                    else
                    {
                        values[i] = Convert.ToInt32(tmp[i].Substring(0,1));
                    }
                }
            }
            return values;
        }

        // Instantiates the Cards and adds them to the card list of the inputcontroller
        private void LoadCards(int[] values, string[] suits)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if ((i == 0) || (i == 6) || (i == 7))
                {
                    continue;
                }
                else
                {
                    Cards.Add(new Card(values[i], suits[i]));
                }
            }
        }
    }
}
