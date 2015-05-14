using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoPoker
{
    class Hand
    {
        private static string[] CARD_NAMES = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven",
                                        "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
        private static string[] CARD_SUITS = { "Spades", "Diamonds", "Clubs", "Hearts" };
        private static int NAME_COUNT = CARD_NAMES.Length;
        private static int SUIT_COUNT = CARD_SUITS.Length;
        private const int MAX_CARDS = 5;

        private const int ROYAL_FLUSH = 800;
        private const int STRAIGHT_FLUSH = 50;
        private const int FOUR_OF_A_KIND = 25;
        private const int FULL_HOUSE = 9;
        private const int FLUSH = 8;
        private const int STRAIGHT = 4;
        private const int THREE_OF_A_KIND = 3;
        private const int TWO_PAIR = 2;
        private const int HIGH_PAIR = 1;

        Card[] cards;
        
        public Hand()
        {
            cards = new Card[MAX_CARDS];
            for(int i = 0; i < MAX_CARDS; i++)
                cards[i] = null;
        }

        public void AddCard(Card card, int index)
        {
            if (index >= MAX_CARDS) throw new IndexOutOfRangeException("Tried to add a card to a hand in slot " + index);
            if (cards[index] != null) throw new InvalidOperationException("Tried to add a card to a hand in a non-null slot.");
            cards[index] = card;
        }

        public Card RemoveCard(int index)
        {
            Card tempCard = cards[index];
            cards[index] = null;
            return tempCard;
        }

        public string GetCardName(int index)
        {
            return cards[index].GetCardName();
        }

        public int Size()
        {
            int size = 0;
            for (int i = 0; i < MAX_CARDS; i++)
                if (cards[i] != null) size++;
            return size;
        }

        private int CountValue(int value)
        {
            int count = 0;
            for (int i = 0; i < MAX_CARDS; i++)
                if (cards[i].GetValue() == value) count++;
            return count;
        }

        private int CountSuit(string suit)
        {
            int count = 0;
            for (int i = 0; i < MAX_CARDS; i++)
                if (cards[i].GetSuit() == suit) count++;
            return count;
        }

        private bool IsStraight()
        {
            for (int i = 0; i < NAME_COUNT - 5; i++)
                if (CountValue(i) == 1 && CountValue(i + 1) == 1 && CountValue(i + 2) == 1 &&
                    CountValue(i + 3) == 1 && CountValue(i + 4) == 1)
                    return true;
            return false;
        }

        private bool IsRoyalStraight()
        {
            return (CountValue(0) == 1 && CountValue(9) == 1 && CountValue(10) == 1 &&
                    CountValue(11) == 1 && CountValue(12) == 1);
        }

        private bool NOfOneKind(int n)
        {
            for (int i = 0; i < NAME_COUNT; i++)
                if (CountValue(i) == n) return true;
            return false;
        }

        private bool HasTwoPair()
        {
            bool one_pair = false;
            for (int i = 0; i < NAME_COUNT; i++)
            {
                if (CountValue(i) == 2)
                {
                    if (one_pair) return true;
                    else one_pair = true;
                }
            }
            return false;
        }

        private bool HasHighPair()
        {
            return (CountValue(0) == 2 || CountValue(10) == 2 || CountValue(11) == 2 ||
                CountValue(12) == 2);
        }

        private bool IsFlush()
        {
            for (int i = 0; i < SUIT_COUNT; i++)
                if (CountSuit(CARD_SUITS[i]) == 5) return true;
            return false;
        }

        public int GetPayout()
        {
            if (IsFlush())
            {
                if (IsRoyalStraight()) return ROYAL_FLUSH;
                else if (IsStraight()) return STRAIGHT_FLUSH;
                else return FLUSH;
            }
            if (IsRoyalStraight()) return STRAIGHT;
            if (IsStraight()) return STRAIGHT;
            if (NOfOneKind(4)) return FOUR_OF_A_KIND;
            if (NOfOneKind(3))
            {
                if (NOfOneKind(2)) return FULL_HOUSE;
                else return THREE_OF_A_KIND;
            }
            if (HasTwoPair()) return TWO_PAIR;
            if (HasHighPair()) return HIGH_PAIR;
            return 0;
        }

        public string GetHandName()
        {
            if (IsFlush())
            {
                if (IsRoyalStraight()) return "a royal flush";
                else if (IsStraight()) return "a straight flush";
                else return "a flush";
            }
            if (IsRoyalStraight()) return "a straight";
            if (IsStraight()) return "a straight";
            if (NOfOneKind(4)) return "four of a kind";
            if (NOfOneKind(3))
            {
                if (NOfOneKind(2)) return "a full house";
                else return "three of a kind";
            }
            if (HasTwoPair()) return "two pair";
            if (HasHighPair()) return "a high pair";
            return "no winning hand";
        }
    }
}
