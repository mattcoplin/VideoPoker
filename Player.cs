using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoPoker
{
    class Player : IModel
    {
        const int STARTING_COINS = 1000;
        const int MAX_CARDS = 5;
        const int MAX_BET = 5;

        private Deck deck;
        private Hand hand;
        private int coins;
        private int bet;

        public Player()
        {
            coins = 1000;
            bet = 0;
            hand = new Hand();
            deck = new Deck();
        }

        public void DealHand()
        {
            deck.Shuffle();
            if(hand.Size() > 0) throw new InvalidOperationException("Tried to deal when the player's hand wasn't empty.");
            for (int i = 0; i < MAX_CARDS; i++)
                hand.AddCard(deck.RemoveCard(), i);
        }

        public void EmptyHand()
        {
            if (hand.Size() < MAX_CARDS) throw new InvalidOperationException("Tried to empty when the player's hand wasn't full.");
            for (int i = 0; i < MAX_CARDS; i++)
                deck.AddCard(hand.RemoveCard(i));
        }

        public void ReplaceCard(int index)
        {
            deck.AddCard(hand.RemoveCard(index));
            hand.AddCard(deck.RemoveCard(),index);
        }

        public string GetCardName(int index)
        {
            return hand.GetCardName(index);
        }

        public int GetCoins()
        {
            return coins;
        }

        public int GetMaxBet()
        {
            if (coins < MAX_BET) return coins;
            return MAX_BET;
        }

        public void PlaceBet(int bet)
        {
            if (bet > coins) throw new InvalidOperationException("Attempted to place a bet higher than current coins.");
            coins -= bet;
            this.bet = bet;
        }

        public void Payout()
        {
            coins += GetPayout();
            bet = 0;
        }

        public int GetPayout()
        {
            return bet * hand.GetPayout();
        }

        public string GetHandName()
        {
            return hand.GetHandName();
        }
    }
}
