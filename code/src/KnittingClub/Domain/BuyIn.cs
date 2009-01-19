namespace KnittingClub.Domain
{
    public class BuyIn
    {
        private readonly int buyInAmount;

        public BuyIn()
            : this(20)
        {            
        }

        public BuyIn(int numberOfDollars)
        {
            this.buyInAmount = numberOfDollars;

        }

        public int BuyInAmount
        {
            get { return buyInAmount; }
        }

    }
}