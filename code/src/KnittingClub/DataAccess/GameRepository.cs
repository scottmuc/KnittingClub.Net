using Castle.Facilities.NHibernateIntegration;
using KnittingClub.Domain;

namespace KnittingClub.DataAccess
{
    public class GameRepository : CoreRepository<Game>, IGameRepository
    {
        public GameRepository(ISessionManager sessionManager)
            : base(sessionManager)
        {
           
        }
    }
}