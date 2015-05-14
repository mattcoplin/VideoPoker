using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoPoker
{
    interface IModel
    {
         void DealHand();
         void EmptyHand();
         void ReplaceCard(int index);
         string GetCardName(int index);
         int GetCoins();
         int GetMaxBet();
         void PlaceBet(int bet);
         void Payout();
         int GetPayout();
         string GetHandName();
    }
}
