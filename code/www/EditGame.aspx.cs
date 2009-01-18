using System;
using System.Web.UI;
using KnittingClub.DataAccess;
using Rhino.Commons;

public partial class EditGame : Page
{
    private readonly IGameRepository repository;
    private readonly IPlayerRepository playerRepository;

    public EditGame()
    {
        repository = IoC.Resolve<IGameRepository>();
        playerRepository = IoC.Resolve<IPlayerRepository>();
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        ctlAddPlayer.Click += delegate { AddPlayerToGame(); };
    }

    private void AddPlayerToGame()
    {
        int playerId = Convert.ToInt32(ctlPlayers.SelectedValue);

        var player = playerRepository.GetById(playerId);

        var game = repository.GetById(this.GameId);

        game.AddEntrant(player);
        repository.Update(game);


        ctlPlayersInGame.DataSource = game.AllEntrants();
        ctlPlayersInGame.DataBind();
        Response.Redirect(Request.Url.AbsoluteUri);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var game = repository.GetById(this.GameId);
            ctlPlayersInGame.DataSource = game.AllEntrants();
            ctlPlayersInGame.DataBind();
        }
    }

    public int GameId
    {
        get { return Convert.ToInt32(Request.QueryString["gameId"]); }
    }

    private void AddMessage(string message)
    {
        ctlMessage.Text += string.Format("{0}<br />", message);
    }
}
