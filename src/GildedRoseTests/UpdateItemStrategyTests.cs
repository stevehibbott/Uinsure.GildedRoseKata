using System.Collections.Generic;
using GildedRose;
using GildedRose.Strategies;
using Xunit;

namespace GildedRoseTests
{
    public class UpdateItemStrategyTests
    {
        [Theory]
        [InlineData(10, 5, 9, 4)]
        [InlineData(0, 5, 0, 4)]
        [InlineData(10, -1, 8, -2)]
        public void UpdateDefaultItem_ReturnsExpected_Results(
            int initialQuality,
            int initalSellIn,
            int expectedQuality,
            int expectedSellIn
        )
        {
            //Arrange
            var item = new Item() { Quality = initialQuality, SellIn = initalSellIn };
            //Act
            new DefaultStockItemStrategy().UpdateItem(item);
            //Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }
    }
}
