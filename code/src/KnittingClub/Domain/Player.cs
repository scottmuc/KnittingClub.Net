namespace KnittingClub.Domain
{   
    public class Player 
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string NickName { get; set; }
    }
}