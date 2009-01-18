using System;
using System.Collections.Generic;

namespace KnittingClub.Domain
{
    public class PayoutStructure
    {
        private readonly int buyInAmount;
        private IList<int> payouts;

        public PayoutStructure()
            : this(20)
        {            
        }

        public PayoutStructure(int numberOfDollars)
        {
            this.buyInAmount = numberOfDollars;
            this.TotalPrizePool = 0;
        }

        public virtual int Id { get; set; }

        public int BuyInAmount
        {
            get { return buyInAmount; }
        }

        public int TotalPrizePool { get; private set; }

        public void IncrementPrizePool()
        {
            TotalPrizePool += buyInAmount;
        }


        public void SetPayouts(IList<int> listOfPayouts)
        {
            int totalPayouts = 0;

            foreach(int payout in listOfPayouts)
                totalPayouts += payout;

            if (totalPayouts != this.TotalPrizePool)
                throw new ArgumentException(string.Format("Payout total of {0} does not equal the prize pool of {1}", totalPayouts, this.TotalPrizePool));

            this.payouts = listOfPayouts;
        }

        public int GetPayoutFor(int place)
        {
            return payouts[place - 1];
        }
    }
}