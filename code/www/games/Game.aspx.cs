using System;
using System.Web.UI;
using KnittingClub.DataAccess;
using KnittingClub.Domain;
using Rhino.Commons;

public partial class games_Game : Page
{
    private readonly IGameRepository repository;

    public games_Game()
    {
        repository = IoC.Resolve<IGameRepository>();
    }

    public int GameId
    {
        get { return Convert.ToInt32(Request.QueryString["gameId"]); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var game = repository.GetById(this.GameId);

            ctlPlayers.DataSource = game.AllEntrants();
            ctlPlayers.DataBind();

            ctlPayouts.DataSource = game.AllPayouts();
            ctlPayouts.DataBind();

            ctlResults.DataSource = game.GameResults();
            ctlResults.DataBind();
        }
    }


    protected string GetKnockedOutPlayerString(GameResult gameResult)
    {
        if (gameResult.KnockedOutBy == null)
            return string.Empty;

        return string.Format("knocked out by {0}", gameResult.KnockedOutBy.NickName);
    }
}
