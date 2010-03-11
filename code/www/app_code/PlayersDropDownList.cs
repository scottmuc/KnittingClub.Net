using System;
using System.Web.UI.WebControls;
using KnittingClub.DataAccess;
using Rhino.Commons;

namespace KnittingClub.UI.Web.Controls
{
    public class PlayersDropDownList : DropDownList
    {
        private readonly IPlayerRepository repository;

        public PlayersDropDownList()
            : this(IoC.Resolve<IPlayerRepository>())
        {
            
        }

        public PlayersDropDownList(IPlayerRepository repository)
        {
            this.repository = repository;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach(var player in repository.GetAll())
            {
                this.Items.Add(new ListItem(player.NickName, player.Id.ToString()));
            }
        }
    }
}