using System;
using System.Collections.Generic;
using System.Web.UI;
using KnittingClub.DataAccess;
using KnittingClub.Domain;
using Rhino.Commons;

public partial class games_AddPayout : Page
{
    private readonly IGameRepository repository;

    public games_AddPayout()
    {
        repository = IoC.Resolve<IGameRepository>();
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        ctlAddPayout.Click += delegate { AddPayoutToGame(); };
    }

    private void AddPayoutToGame()
    {
        int numberOfPlayersPaid = Convert.ToInt32(ctlNumberPaid.SelectedValue);

        var payouts = new List<int>();

        payouts.Add(GetIntFromTextBox(ctlFirstPlace));

        if (numberOfPlayersPaid >= 2)
            payouts.Add(GetIntFromTextBox(ctlSecondPlace));

        if (numberOfPlayersPaid >= 3)
            payouts.Add(GetIntFromTextBox(ctlThirdPlace));

        if (numberOfPlayersPaid >= 4)
            payouts.Add(GetIntFromTextBox(ctlFourthPlace));

        var game = repository.GetById(this.GameId);

        game.AddPayouts(payouts);

        repository.Update(game);

        Response.Redirect("Game.aspx?gameId=" + this.GameId);
    }


    public int GameId
    {
        get { return Convert.ToInt32(Request.QueryString["gameId"]); }
    }

    private static Payout GetPayoutFromTextBox(ITextControl tb, int place)
    {
        int amount = GetIntFromTextBox(tb);
        return new Payout() {AmountToBePaid = amount, Place = place};
    }

    private static int GetIntFromTextBox(ITextControl tb)
    {
        return Convert.ToInt32(tb.Text.Trim());
    }
}
