using System;
using System.Collections.Generic;

namespace KnittingClub.Domain
{
    public class Game
    {
        private readonly IList<Player> players;
        private readonly BuyIn buyIn;
        private readonly IList<Payout> payouts;
        private readonly IList<GameResult> playersKnockedOut;

        public Game()
            : this(new BuyIn(0))
        {
            
        }

        public Game(BuyIn buyIn)
        {
            this.buyIn = buyIn;
            players = new List<Player>();
            payouts = new List<Payout>();
            playersKnockedOut = new List<GameResult>();
        }

        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime GameDate { get; set; }


        public virtual IEnumerable<Player> AllEntrants()
        {
            foreach(var player in players)
                yield return player;
        }

        public virtual IEnumerable<Payout> AllPayouts()
        {
            foreach(var payout in payouts)
                yield return payout;
        }

        public virtual IEnumerable<GameResult> GameResults()
        {
            foreach(var result in playersKnockedOut)
                yield return result;
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

        public virtual int TotalPrizePool()
        {
            return buyIn.BuyInAmount*players.Count;
        }

        public virtual bool IsStarted()
        {
            return (this.payouts.Count > 0);
        }


        public virtual void AddPayouts(IList<Payout> newPayouts)
        {
            if (this.IsStarted())
                throw new ArgumentException("Cannot adjust payouts after a game has started.");

            int totalPayouts = 0;

            foreach (var payout in newPayouts)
                totalPayouts += payout.AmountToBePaid;

            if (totalPayouts != this.TotalPrizePool())
                throw new ArgumentException(string.Format("Payout total of {0} does not equal the prize pool of {1}", totalPayouts, this.TotalPrizePool()));

            foreach(var payout in newPayouts)
                this.payouts.Add(payout);
        }

        public virtual int GetPayoutFor(int place)
        {
            if (place > payouts.Count)
            {
                return 0;
            }

            return payouts[place - 1].AmountToBePaid;
        }

        public virtual void KnockPlayerOut(Player knockedOut, Player knockingOut)
        {
            foreach(var result in playersKnockedOut)
            {
                if (result.Player.Id == knockedOut.Id)
                    throw new ArgumentException("A player that's already knocked out can't be knocked out again!");
                if (result.Player.Id == knockingOut.Id)
                    throw new ArgumentException("A player that's knocked out can't knock out another player!");
                if (knockedOut.Id == knockingOut.Id)
                    throw new ArgumentException("Stop being so dumb! You can't knock yourself out (unless you're Mark)");

            }

            int place = players.Count - playersKnockedOut.Count;

            var gameResult = new GameResult()
                             {
                                 KnockedOutBy = knockingOut,
                                 Player = knockedOut,
                                 Place = place
                             };

            playersKnockedOut.Add(gameResult);

            // this means knockOut Player won!
            if (place == 2)
            {
                var lastResult = new GameResult()
                             {
                                 KnockedOutBy = null,
                                 Player = knockingOut,
                                 Place = 1
                             };  
                playersKnockedOut.Add(lastResult);
            }

        }
    }
}