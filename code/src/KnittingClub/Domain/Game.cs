using System;
using System.Collections.Generic;

namespace KnittingClub.Domain
{
    public class Game
    {
        private readonly IList<Player> players;
        private readonly PayoutStructure payoutStructure;
       
        public Game(PayoutStructure payoutStructure)
        {
            this.payoutStructure = payoutStructure;
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
                payoutStructure.IncrementPrizePool();
            }
        }

        public virtual PayoutStructure PayoutStructure
        {
            get { return payoutStructure; }
        }
    }
}