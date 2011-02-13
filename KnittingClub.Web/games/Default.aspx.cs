using System;
using System.Web.UI;
using KnittingClub.DataAccess;
using Rhino.Commons;

public partial class DisplayGames : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var repo = IoC.Resolve<IGameRepository>();

            ctlGames.DataSource = repo.GetAllLatestFirst();
            ctlGames.DataBind();

        }
    }
}
