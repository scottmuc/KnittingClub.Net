using System;
using System.Linq;
using System.Web.UI;
using KnittingClub.DataAccess;
using Rhino.Commons;

public partial class _Default : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            BindPage(Convert.ToInt32(ctlYears.SelectedValue));
        }
        else
        {
            ctlYears.DataSource = IoC.Resolve<IGameRepository>().GetYearsThatHaveGames();
            ctlYears.DataBind();
            BindPage(DateTime.Now.Year);
        }


    }

    private void BindPage(int year)
    {
        var repo = IoC.Resolve<IPlayerRepository>();

        var players = from p in repo.GetPlayersWithStats(year)
                      orderby p.TotalEarnings descending
                      select p;

        ctlYearlyStats.DataSource = players;
        ctlYearlyStats.DataBind();        
    }
}
