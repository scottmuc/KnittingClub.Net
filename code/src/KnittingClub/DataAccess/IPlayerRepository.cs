using System.Collections.Generic;
using KnittingClub.Domain;

namespace KnittingClub.DataAccess
{
    public interface IPlayerRepository : IRepository<Player>
    {
        IList<Player> GetPlayersWithStats(int year);
    }
}