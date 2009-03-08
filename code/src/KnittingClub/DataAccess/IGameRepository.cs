using System.Collections.Generic;
using KnittingClub.Domain;

namespace KnittingClub.DataAccess
{
    public interface IGameRepository : IRepository<Game>
    {
        IList<Game> GetAllLatestFirst();
    }
}