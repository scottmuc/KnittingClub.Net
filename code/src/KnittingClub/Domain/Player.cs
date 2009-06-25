using System.Collections.Generic;

namespace KnittingClub.Domain
{   
    public class Player 
    {
        private readonly int id;

        public Player()
        {
            id = 0;
        }

        public virtual int Id { get { return id; } }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string NickName { get; set; }

        public virtual int TotalEarnings { get; private set; }
        public virtual int GamesPlayed { get; private set; }


    }
}