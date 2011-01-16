using System;
using System.Collections.Generic;
using Castle.Facilities.NHibernateIntegration;
using KnittingClub.Domain;
using NHibernate.Criterion;

namespace KnittingClub.DataAccess
{
    public class GameRepository : CoreRepository<Game>, IGameRepository
    {
        private readonly ISessionManager sessionManager;

        public GameRepository(ISessionManager sessionManager)
            : base(sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public IList<Game> GetAllLatestFirst()
        {
            using (var session = sessionManager.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof (Game)).AddOrder(Order.Desc("GameDate"));
                return criteria.List<Game>();                    
            }
        }

        public IList<int> GetYearsThatHaveGames()
        {
            using (var session = sessionManager.OpenSession())
            {
                var criteria = session.CreateQuery(@"SELECT distinct YEAR(g.GameDate) from Game g order by YEAR(g.GameDate) DESC");
                return criteria.List<int>();
            }
        }
    }
}