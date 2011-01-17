using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Facilities.NHibernateIntegration;
using KnittingClub.Domain;

namespace KnittingClub.DataAccess
{
    public class PlayerRepository : CoreRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ISessionManager sessionManager)
            : base(sessionManager)
        {
        }

        public IList<Player> GetPlayersWithStats(int year)
        {
            var players = base.GetAll();
            var games = GetAllGamesInAYear(year);

            foreach(var player in players)
            {
                foreach(var game in games)
                {
                    var gameResult = game.GameResults().Where(r => r.Player.Id == player.Id).FirstOrDefault();

                    if (gameResult != null)
                    {
                        player.GamesPlayed++;
                        player.TotalEarnings += game.GetPayoutFor(gameResult.Place);
                    }
                }
            }

            return players;            
        }

        private IEnumerable<Game> GetAllGamesInAYear(int year)
        {
            using (var session = SessionManager.OpenSession())
            {
                var games = session.CreateQuery("from Game").List<Game>().Where(g => g.GameDate.Year == year);                    

                return games;
            }
        }
    }
}