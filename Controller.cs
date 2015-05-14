using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoPoker
{
    class Controller
    {
        const int MAX_BET = 5;
        const int MAX_CARDS = 5;

        static IView view;
        static IModel player;

        static void Main(string[] args)
        {
            player = new Player();
            view = new View();
            view.Welcome();
            view.ShowPayouts();
            bool playing = true;
            while (playing && player.GetCoins() > 0)
            {
                view.ShowCoins(player.GetCoins());
                int bet = view.GetBet(player.GetMaxBet());
                view.ConfirmBet(bet);
                player.PlaceBet(bet);
                player.DealHand();
                view.ShowHandHeader();
                for (int i = 0; i < MAX_CARDS; i++)
                {
                    view.ShowCard(i, player.GetCardName(i));
                }
                view.ShowHandPayout(player.GetHandName(), player.GetPayout());
                if (view.DiscardCards())
                {
                    string discard = view.GetDiscards(MAX_CARDS);
                    for (int i = 1; i <= MAX_CARDS; i++)
                        if (discard.Contains(i.ToString()[0])) player.ReplaceCard(i - 1);
                    view.ShowHandHeader();
                    for (int i = 0; i < MAX_CARDS; i++)
                    {
                        view.ShowCard(i, player.GetCardName(i));
                    }
                }
                view.ShowWinnings(player.GetHandName(), player.GetPayout());
                player.Payout();
                player.EmptyHand();
                if (player.GetCoins() == 0) view.OutOfCoins();
                else playing = view.ContinuePlaying();
            }
            view.ShowEndingCoins(player.GetCoins());
        }
    }
}
