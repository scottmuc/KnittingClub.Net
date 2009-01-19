using System;
using System.Collections.Generic;
using KnittingClub.Domain;
using Xunit;

namespace KnittingClub.Tests.Domain
{
    public class BuyInTests
    {
        [Fact]
        public void PayoutStructure_depends_on_the_value_of_the_buyin()
        {
            var payoutStructure = new BuyIn(20);

            Assert.Equal(20, payoutStructure.BuyInAmount);
        }

        [Fact]
        public void When_a_buy_in_is_added_to_payour_structure_the_prize_pool_should_increase_by_the_same_amount()
        {
            var payoutStructure = new BuyIn(20);
            payoutStructure.IncrementPrizePool();

            Assert.Equal(20, payoutStructure.TotalPrizePool);
        }

        [Fact] 
        public void When_assiging_payouts_the_totals_should_be_equal_to_total_prize_pool()
        {
            var payoutStructure = CreatePayoutStructureWithNPlayers(4);

            IList<int> payouts = new List<int> {60, 40};

            Exception ex = Assert.Throws<ArgumentException>(() => payoutStructure.SetPayouts(payouts));
            Assert.Equal("Payout total of 100 does not equal the prize pool of 80", ex.Message);
        }

        [Fact]
        public void When_asked_for_the_payout_of_1st_place_should_return_first_payout()
        {
            var payoutStructure = CreatePayoutStructureWithNPlayers(5);

            IList<int> payouts = new List<int> {60, 40};

            payoutStructure.SetPayouts(payouts);

            const int firstPlace = 1;
            int result = payoutStructure.GetPayoutFor(firstPlace);

            Assert.Equal(60, result);
        }

        private static BuyIn CreatePayoutStructureWithNPlayers(int numberOfPlayers)
        {
            var payoutStructure = new BuyIn(20);

            while(numberOfPlayers-- != 0)
                payoutStructure.IncrementPrizePool();

            return payoutStructure;
        }


    }
}