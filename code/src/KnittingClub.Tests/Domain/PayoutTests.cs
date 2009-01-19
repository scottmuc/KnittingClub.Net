using System;
using System.Collections.Generic;
using KnittingClub.Domain;
using Xunit;

namespace KnittingClub.Tests.Domain
{
    public class PayoutTests
    {
        [Fact]
        public void Payout_depends_on_the_value_of_the_buyin_and_the_number_of_entrants()
        {
            var payoutStructure = new Payout(20, 5);

            Assert.Equal(100, payoutStructure.TotalPrizePool());
        }


        [Fact] 
        public void When_assiging_payouts_the_totals_should_be_equal_to_total_prize_pool()
        {
            var payoutStructure = new Payout(20, 4);

            IList<int> payouts = new List<int> {60, 40};

            Exception ex = Assert.Throws<ArgumentException>(() => payoutStructure.SetPayouts(payouts));
            Assert.Equal("Payout total of 100 does not equal the prize pool of 80", ex.Message);
        }

        [Fact]
        public void When_asked_for_the_payout_of_1st_place_should_return_first_payout()
        {
            var payoutStructure = new Payout(20, 5);

            IList<int> payouts = new List<int> {60, 40};

            payoutStructure.SetPayouts(payouts);

            const int firstPlace = 1;
            int result = payoutStructure.GetPayoutFor(firstPlace);

            Assert.Equal(60, result);
        }     
    }
}