using KnittingClub.Domain;
using Xunit;

namespace KnittingClub.Tests.Domain
{
    public class PlayerTests
    {
        [Fact]
        public void When_a_player_is_created_it_should_start_with_empty_properties()
        {
            Player player = new Player();

            Assert.Equal(string.Empty, player.FirstName);
            Assert.Equal(string.Empty, player.LastName);
            Assert.Equal(string.Empty, player.NickName);
        }
    }
}