using System;
using System.Web.UI;

public partial class games_Game : Page
{
    public int GameId
    {
        get { return Convert.ToInt32(Request.QueryString["gameId"]); }
    }
}
