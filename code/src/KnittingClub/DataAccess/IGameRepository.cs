using System.Collections.Generic;
using System.Web.UI.WebControls;
using KnittingClub.Domain;

namespace KnittingClub.DataAccess
{
    public interface IGameRepository : IRepository<Game>
    {
        IList<Game> GetAllLatestFirst();
        IList<int> GetYearsThatHaveGames();
        IList<Game> GetAllGamesInAYear(int year);
    }
}