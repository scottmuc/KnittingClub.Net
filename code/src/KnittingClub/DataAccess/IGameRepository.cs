using KnittingClub.Domain;

namespace KnittingClub.DataAccess
{
    public interface IGameRepository
    {
        Game GetById(int id);
        Game[] GetAll();

        void Update(Game game);
        void Save(Game game);
    }
}