using System;
using System.Linq;
using System.Web.UI;
using KnittingClub.DataAccess;
using Rhino.Commons;

public partial class _Default : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var repo = IoC.Resolve<IPlayerRepository>();

        var players = from p in repo.GetAll()
                      orderby p.TotalEarnings descending
                      select p;

        ctlYears.DataSource = IoC.Resolve<IGameRepository>().GetYearsThatHaveGames();
        ctlYears.DataBind();

        ctlYearlyStats.DataSource = players;
        ctlYearlyStats.DataBind();
    }
}
