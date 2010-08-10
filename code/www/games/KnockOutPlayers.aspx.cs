using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using KnittingClub.DataAccess;
using Rhino.Commons;

public partial class games_KnockOutPlayers : Page
{
    private readonly IGameRepository gameRepo;
    private readonly IPlayerRepository userRepo;

    public games_KnockOutPlayers()
    {
        gameRepo = IoC.Resolve<IGameRepository>();
        userRepo = IoC.Resolve<IPlayerRepository>();
    }

    public int GameId
    {
        get { return Convert.ToInt32(Request.QueryString["gameId"]); }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        ctlKnockOutPlayer.Click += delegate { KnockPlayerOut(); };
    }

    private void KnockPlayerOut()
    {
        var game = gameRepo.GetById(this.GameId);

        int playerKnockedOutId = Convert.ToInt32(ctlKnockedOut.SelectedValue);
        int playerKnockingOutId = Convert.ToInt32(ctlKnockerOuter.SelectedValue);

        var knockedOut = userRepo.GetById(playerKnockedOutId);
        var knockerOut = userRepo.GetById(playerKnockingOutId);


        game.KnockPlayerOut(knockedOut, knockerOut);

        gameRepo.Save(game);
        message.Text = string.Format("Success: {0} knocked out {1}", knockerOut.FirstName, knockedOut.FirstName);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            var game = gameRepo.GetById(this.GameId);

            ctlKnockedOut.DataSource = game.AllEntrants();
            ctlKnockedOut.DataTextField = "NickName";
            ctlKnockedOut.DataValueField = "Id";
            ctlKnockedOut.DataBind();

            ctlKnockerOuter.DataSource = game.AllEntrants();
            ctlKnockerOuter.DataTextField = "NickName";
            ctlKnockerOuter.DataValueField = "Id";
            ctlKnockerOuter.DataBind();
        }
    }
}
