using System;
using System.Web.UI;
using KnittingClub.DataAccess;
using Rhino.Commons;

public partial class admin_DisplayPlayers : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var repo = IoC.Resolve<IPlayerRepository>();

            ctlPlayers.DataSource = repo.GetAll();
            ctlPlayers.DataBind();

        }
    }
}
