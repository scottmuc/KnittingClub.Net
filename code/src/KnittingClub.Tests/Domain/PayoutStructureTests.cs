using System;
using System.Collections.Generic;
using KnittingClub.Domain;
using Xunit;

namespace KnittingClub.Tests.Domain
{
    public class PayoutStructureTests
    {
        [Fact]
        public void Payout_depends_on_the_value_of_the_buyin_and_the_number_of_entrants()
        {
            var payoutStructure = new PayoutStructure(20, 5);

            Assert.Equal(100, payoutStructure.TotalPrizePool());
        }


        [Fact]
        public void When_assiging_payouts_the_totals_should_be_equal_to_total_prize_pool()
        {
            var payoutStructure = new PayoutStructure(20, 4);


            Exception ex = Assert.Throws<ArgumentException>(() => payoutStructure.SetPayouts(GetPayouts()));
            Assert.Equal("Payout total of 100 does not equal the prize pool of 80", ex.Message);
        }

        [Fact]
        public void When_asked_for_the_payout_of_1st_place_should_return_first_payout()
        {
            var payoutStructure = new PayoutStructure(20, 5);


            payoutStructure.SetPayouts(GetPayouts());

            const int firstPlace = 1;
            int result = payoutStructure.GetPayoutFor(firstPlace);

            Assert.Equal(60, result);
        }

        private IList<Payout> GetPayouts()
        {
            return new List<Payout>
                       {
                           new Payout {AmountToBePaid = 60, Place = 1},
                           new Payout {AmountToBePaid = 40, Place = 2}
                       };
        }

    }
}