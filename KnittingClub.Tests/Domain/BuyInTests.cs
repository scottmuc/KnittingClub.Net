using KnittingClub.Domain;
using Xunit;

namespace KnittingClub.Tests.Domain
{
    public class BuyInTests
    {
        [Fact]
        public void BuyInAmount_ConstructedWith_ShouldStoreAmount()
        {
            const int testBuyInAmont = 20;
            BuyIn sut = new BuyIn(testBuyInAmont);

            int result = sut.BuyInAmount;

            Assert.Equal(testBuyInAmont, result);
        }

    }
}