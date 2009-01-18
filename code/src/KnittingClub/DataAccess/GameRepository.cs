using Castle.Facilities.NHibernateIntegration;
using KnittingClub.Domain;

namespace KnittingClub.DataAccess
{
    public class GameRepository : IGameRepository
    {
        private readonly ISessionManager sessionManager;
        private IRepository<Game> coreRepository;

        public GameRepository(ISessionManager sessionManager, IRepository<Game> coreRepository)
        {
            this.sessionManager = sessionManager;
            this.coreRepository = coreRepository;
        }

        public Game GetById(int id)
        {
            return coreRepository.GetById(id);
        }

        public Game[] GetAll()
        {
            return coreRepository.GetAll();
        }

        public void Update(Game game)
        {
            coreRepository.Update(game);        
        }

        public void Save(Game game)
        {
            coreRepository.Save(game);
        }
    }
}