using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoPoker
{
    class View : IView
    {
        public View()
        {
        }

        public void Welcome()
        {
            Console.Out.WriteLine("Welcome to Video Poker!\nWritten in 2011 by Matt Coplin\n");
        }

        public void ShowPayouts()
        {
            Console.Out.WriteLine("Payouts are as follows:\n" +
                                  "Royal Flush             800\n" +
                                  "Straight Flush           50\n" +
                                  "Four of a Kind           25\n" +
                                  "Full House                9\n" +
                                  "Flush                     8\n" +
                                  "Straight                  4\n" +
                                  "Three of a Kind           3\n" +
                                  "Two Pair                  2\n" +
                                  "Jacks or Better           1\n");
        }

        public void ShowCoins(int coins)
        {
            Console.Out.WriteLine("You have " + coins + " coins.");
        }

        public int GetBet(int max)
        {
            Console.Out.WriteLine("How many coins will you bet? The maximum is " + max + " coins.");
            int bet = -1;
            do
            {
                Console.Out.Write("Your bet: ");
                string input = Console.In.ReadLine();
                bool number = input.Length > 0;
                foreach (char letter in input)
                    if (!char.IsNumber(letter))
                    {
                        bet = -1;
                        number = false;
                    }
                if (number) bet = int.Parse(input);
                if (bet <= 0) Console.Out.WriteLine("Invalid bet.");
                else if (bet > max) Console.Out.WriteLine("You can't bet that much.");
            }
            while (bet <= 0 || bet > max);
            return bet;
        }

        public void ConfirmBet(int bet)
        {
            Console.Out.WriteLine("You bet " + bet + " coins.\n");
        }

        public void ShowHandHeader()
        {
            Console.Out.WriteLine("Your hand:");
        }

        public void ShowCard(int index, string name)
        {
            Console.Out.WriteLine((index + 1) + ". " + name);
        }

        public void ShowHandPayout(string hand, int payout)
        {
            if (payout > 0) Console.Out.WriteLine("You have " + hand + "! [Payout: " + payout + "]");
            else Console.Out.WriteLine("You have " + hand + ". [Payout: " + payout + "]");
            Console.Out.WriteLine();
        }

        public bool DiscardCards()
        {
            char decision = 'x';
            while (decision != 'y' && decision != 'n')
            {
                Console.Out.Write("Do you wish to discard cards? [Y/N]: ");
                string input = Console.In.ReadLine();
                if(input.Length > 0) decision = char.ToLower(input[0]);
                if (decision != 'y' && decision != 'n') Console.Out.WriteLine("Invalid entry.");
            }
            if (decision == 'y') return true;
            return false;
        }

        public string GetDiscards(int max)
        {
            string discards = "";
            while (discards.Length == 0)
            {
                Console.Out.Write("Enter the number of each card you wish to discard: ");
                string input = Console.In.ReadLine();
                for (int i = 1; i <= max; i++)
                    if (input.Contains(i.ToString()[0])) discards = discards + i;
                if (discards.Length == 0) Console.Out.WriteLine("Invalid entry.");
            }
            Console.Out.WriteLine();
            return discards;
        }

        public void ShowWinnings(string hand, int payout)
        {
            Console.Out.WriteLine();
            if (payout > 0) Console.Out.WriteLine("You have " + hand + "! You win " + payout + " coins.");
            else Console.Out.WriteLine("You win " + payout + " coins.");
            Console.Out.WriteLine();
        }

        public void OutOfCoins()
        {
            Console.Out.WriteLine("You're out of coins. Game over.");
        }

        public bool ContinuePlaying()
        {
            char decision = 'x';
            while (decision != 'y' && decision != 'n')
            {
                Console.Out.Write("Continue playing? [Y/N]: ");
                string input = Console.In.ReadLine();
                if(input.Length > 0) decision = char.ToLower(input[0]);
                if (decision != 'y' && decision != 'n') Console.Out.WriteLine("Invalid entry.");
            }
            if (decision == 'y') return true;
            return false;
        }

        public void ShowEndingCoins(int coins)
        {
            Console.Out.WriteLine("You walk away with " + coins + " coins.");
        }
    }
}
