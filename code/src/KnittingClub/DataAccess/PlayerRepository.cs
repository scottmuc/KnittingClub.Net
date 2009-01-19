using Castle.Facilities.NHibernateIntegration;
using KnittingClub.Domain;
using Rhino.Commons;

namespace KnittingClub.DataAccess
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ISessionManager sessionManager;
        private readonly IRepository<Player> coreRepository;

        public PlayerRepository(ISessionManager sessionManager, IRepository<Player> coreRepository)
        {
            this.sessionManager = sessionManager;
            this.coreRepository = coreRepository;
        }

        public Player GetById(int id)
        {
            return coreRepository.GetById(id);
        }

        public Player[] GetAll()
        {
            return coreRepository.GetAll();
        }

        public void Save(Player player)
        {
            coreRepository.Save(player);
        }

        public void Update(Player player)
        {
            coreRepository.Update(player);
        }
    }
}