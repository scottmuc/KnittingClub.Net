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
    }
}