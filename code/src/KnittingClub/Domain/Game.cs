using System;
using System.Collections.Generic;

namespace KnittingClub.Domain
{
    public class Game
    {
        private readonly IList<Player> players;
        private readonly BuyIn buyIn;

        

        public Game()
            : this(new BuyIn(0))
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
        public virtual PayoutStructure Payout { get; private set; }

        public virtual IEnumerable<Player> AllEntrants()
        {
            foreach(var player in players)
                yield return player;
        }

        public virtual void AddEntrant(Player entrant)
        {
            if (this.IsStarted())
                throw new ArgumentException("Cannot join a game that has been started.");
            if (players.Contains(entrant))
                throw new ArgumentException("That player is already in the game.");
                
            players.Add(entrant);            
        }

        public virtual BuyIn BuyIn
        {
            get { return buyIn; }
        }

        public virtual bool IsStarted()
        {
            return (this.Payout != null);
        }


        public virtual void AddPayouts(IList<Payout> payouts)
        {
            if (this.IsStarted())
                throw new ArgumentException("Cannot adjust payouts after a game has started.");

            var payoutStructure = new PayoutStructure(buyIn.BuyInAmount, players.Count);
            //payoutStructure.SetPayouts(payouts);

            this.Payout = payoutStructure;
        }
    }
}