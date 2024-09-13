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
        public void DefaultStockItemStrategy_UpdateItem_Returns_Expected_Results(
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

        [Theory]
        [InlineData(10, 5, 11, 4)]
        [InlineData(50, 5, 50, 4)]
        [InlineData(10, -1, 12, -2)]
        [InlineData(49, -1, 50, -2)]
        public void AgedBrieStockItemStrategy_UpdateItem_Returns_Expected_Results(
            int initialQuality,
            int initalSellIn,
            int expectedQuality,
            int expectedSellIn
        )
        {
            //Arrange
            var item = new Item() { Quality = initialQuality, SellIn = initalSellIn };
            //Act
            new AgedBrieStockItemStrategy().UpdateItem(item);
            //Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }
      
    }
}
