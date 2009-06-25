using System;
using System.Web.UI;
using KnittingClub.DataAccess;
using KnittingClub.Domain;
using Rhino.Commons;

public partial class CreateGame : Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        ctlCreateGame.Click += delegate { CreateNewGame(); };
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void CreateNewGame()
    {
        int buyInAmount = Convert.ToInt32(ctlBuyIn.SelectedValue);
        var buyIn = new BuyIn(buyInAmount);

        var game = new Game(buyIn)
        {
            Title = ctlTitle.Text.Trim(), 
            GameDate = DateTime.Now
        };


        var repo = IoC.Resolve<IGameRepository>();

        repo.Save(game);

        Response.Redirect("./");
    }
}
