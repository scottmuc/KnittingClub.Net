using System;
using System.Collections.Generic;

namespace KnittingClub.Domain
{
    public class Payout
    {
        private readonly int buyInAmount;
        private readonly int numberOfEntrants;
        private IList<int> payouts;

        public Payout(int buyInAmount, int numberOfEntrants)
        {
            this.buyInAmount = buyInAmount;
            this.numberOfEntrants = numberOfEntrants;
        }

        public virtual int Id { get; set; }

        public int BuyInAmount
        {
            get { return buyInAmount; }
        }

        public int TotalPrizePool()
        {
            return buyInAmount * numberOfEntrants;
        }

        public void SetPayouts(IList<int> listOfPayouts)
        {
            int totalPayouts = 0;

            foreach (int payout in listOfPayouts)
                totalPayouts += payout;

            if (totalPayouts != this.TotalPrizePool())
                throw new ArgumentException(string.Format("Payout total of {0} does not equal the prize pool of {1}", totalPayouts, this.TotalPrizePool()));

            this.payouts = listOfPayouts;
        }

        public int GetPayoutFor(int place)
        {
            return payouts[place - 1];
        }
    }
}