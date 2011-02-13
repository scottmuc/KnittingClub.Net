namespace KnittingClub.Domain
{
    public class Payout
    {
        public virtual int Id { get; set; }
        public virtual int Place { get; set; }
        public virtual int AmountToBePaid { get; set; }
    }
}