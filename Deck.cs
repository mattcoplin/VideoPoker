using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoPoker
{
    class Deck
    {
        private static string[] CARD_NAMES = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven",
                                        "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
        private static string[] CARD_SUITS = { "Spades", "Diamonds", "Clubs", "Hearts" };
        private static int NAME_COUNT = CARD_NAMES.Length;
        private static int SUIT_COUNT = CARD_SUITS.Length;

        private Queue<Card> cards;

        private Random rand;

        public Deck()
        {
            cards = new Queue<Card>();
            rand = new Random(System.DateTime.Now.Millisecond);
            for (int i = 0; i < SUIT_COUNT; i++)
                for (int j = 0; j < NAME_COUNT; j++)
                    AddCard(new Card(CARD_NAMES[j], CARD_SUITS[i], j));
        }

        public void AddCard(Card card)
        {
            cards.Enqueue(card);
        }

        public Card RemoveCard()
        {
            return cards.Dequeue();
        }

        public void Shuffle()
        {
            List<Card> tempList = new List<Card>();
            while (cards.Count() > 0)
            {
                tempList.Insert(rand.Next(tempList.Count() + 1), cards.Dequeue());
            }
            while (tempList.Count() > 0)
            {
                cards.Enqueue(tempList.First());
                tempList.RemoveAt(0);
            }
        }
    }
}
