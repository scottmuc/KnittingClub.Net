namespace KnittingClub.Domain
{
    public class GameResult
    {
        public virtual int Id { get; set; }

        public virtual Player Player { get; set; }
        public virtual Player KnockedOutBy { get; set; }

        public virtual int Place { get; set; }
    }
}