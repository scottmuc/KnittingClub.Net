namespace KnittingClub.Domain
{
    public class BuyIn
    {
        public BuyIn()
            : this(0)
        {
            
        }

        public BuyIn(int amount)
        {
            this.BuyInAmount = amount;
        }

        public virtual int BuyInAmount { get; private set; }
    }
}