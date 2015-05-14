using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoPoker
{
    class Card
    {
        private string name;
        private string suit;
        private int value;

        public Card(string name, string suit, int value)
        {
            this.name = name;
            this.suit = suit;
            this.value = value;
        }

        public int GetValue()
        {
            return value;
        }

        public string GetSuit()
        {
            return suit;
        }

        public string GetCardName()
        {
            return name + " of " + suit;
        }
    }
}
