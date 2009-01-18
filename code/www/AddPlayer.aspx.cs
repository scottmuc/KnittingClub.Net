using System;
using System.Web.UI;
using KnittingClub.DataAccess;
using KnittingClub.Domain;
using Rhino.Commons;

public partial class admin_AddPlayer : Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        ctlCreatePlayer.Click += delegate { CreatePlayer(); };
    }

    private void CreatePlayer()
    {
        Player player = new Player
                            {
                                FirstName = ctlFirstName.Text.Trim(),
                                LastName = ctlLastName.Text.Trim(),
                                NickName = ctlNickName.Text.Trim()
                            };

        var repo = IoC.Resolve<IPlayerRepository>();

        repo.Save(player);

        Response.Redirect("DisplayPlayers.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
