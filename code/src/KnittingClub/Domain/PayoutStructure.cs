using System;
using System.Collections.Generic;

namespace KnittingClub.Domain
{
    public class PayoutStructure
    {
        private readonly int buyInAmount;
        private readonly int numberOfEntrants;
        private IList<int> payouts;

        public PayoutStructure()
            : this(0, 0)
        {
            
        }

        public PayoutStructure(int buyInAmount, int numberOfEntrants)
        {
            this.buyInAmount = buyInAmount;
            this.numberOfEntrants = numberOfEntrants;
        }

        public virtual int Id { get; set; }
        public virtual Game Game { get; set; }

        public virtual int TotalPrizePool()
        {
            return buyInAmount * numberOfEntrants;
        }

        public virtual void SetPayouts(IList<int> listOfPayouts)
        {
            int totalPayouts = 0;

            foreach (var payout in listOfPayouts)
                totalPayouts += payout;

            if (totalPayouts != this.TotalPrizePool())
                throw new ArgumentException(string.Format("Payout total of {0} does not equal the prize pool of {1}", totalPayouts, this.TotalPrizePool()));

            this.payouts = listOfPayouts;
        }

        public virtual int GetPayoutFor(int place)
        {
            return payouts[place - 1];
        }
    }
}