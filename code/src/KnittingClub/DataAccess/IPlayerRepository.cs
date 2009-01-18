using KnittingClub.Domain;
using Rhino.Commons;

namespace KnittingClub.DataAccess
{
    public interface IPlayerRepository
    {
        Player GetById(int id);
        Player[] GetAll();

        void Save(Player player);
        void Update(Player player);
    }
}