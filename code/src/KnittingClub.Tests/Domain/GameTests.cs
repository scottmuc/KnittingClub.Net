using KnittingClub.Domain;
using KnittingClub.Utility;

using Xunit;

namespace KnittingClub.Tests.Domain
{
    public class GameTests
    {


        [Fact]
        public void When_a_Game_is_constructed_it_should_start_with_zero_players()
        {
            var game = new Game(new PayoutStructure());

            Assert.Empty(game.AllEntrants());
        }

        [Fact]
        public void When_a_player_is_added_to_a_game_its_added_to_the_backing_store()
        {
            var game = new Game(new PayoutStructure());

            var entrant = new Player();
            game.AddEntrant(entrant);

            Assert.Contains(entrant, game.AllEntrants());
        }

        [Fact]
        public void When_a_entrant_is_attempted_to_be_added_more_than_once_it_should_only_be_added_once() 
        {
            var game = new Game(new PayoutStructure());

            var entrant = new Player();
            game.AddEntrant(entrant);
            game.AddEntrant(entrant);

            Assert.Contains(entrant, game.AllEntrants());
            Assert.Equal(1, game.AllEntrants().GetCount());
        }

        [Fact]
        public void When_a_game_is_asked_for_its_payout_structure_it_delegates_it_to_the_Payout_object_that_was_injected()
        {
            var payoutStructure = new PayoutStructure();

            var game = new Game(payoutStructure);

            Assert.Equal(payoutStructure, game.PayoutStructure);
        }
    }
}