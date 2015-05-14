using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoPoker
{
    interface IView
    {
         void Welcome();
         void ShowPayouts();
         void ShowCoins(int coins);
         int GetBet(int max);
         void ConfirmBet(int bet);
         void ShowHandHeader();
         void ShowCard(int index, string name);
         void ShowHandPayout(string hand, int payout);
         bool DiscardCards();
         string GetDiscards(int max);
         void ShowWinnings(string hand, int payout);
         void OutOfCoins();
         bool ContinuePlaying();
         void ShowEndingCoins(int coins);
    }
}
