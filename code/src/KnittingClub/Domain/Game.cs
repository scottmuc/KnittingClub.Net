using System;
using System.Collections.Generic;

namespace KnittingClub.Domain
{
    public class Game
    {
        private readonly IList<Player> players;
        private readonly BuyIn buyIn;

        public Game()
            : this(new BuyIn(20))
        {
            
        }

        public Game(BuyIn buyIn)
        {
            this.buyIn = buyIn;
            players = new List<Player>();
        }

        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime GameDate { get; set; }

        public virtual IEnumerable<Player> AllEntrants()
        {
            foreach(var player in players)
                yield return player;
        }

        public virtual void AddEntrant(Player entrant)
        {
            if (!players.Contains(entrant))
            {
                players.Add(entrant);
                buyIn.IncrementPrizePool();
            }
        }

        public virtual BuyIn BuyIn
        {
            get { return buyIn; }
        }
    }
}