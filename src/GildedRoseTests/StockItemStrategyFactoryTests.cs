using System;
using GildedRose.Factories;
using GildedRose.Strategies;
using Xunit;

namespace GildedRoseTests
{
    public class StockItemStrategyFactoryTests
    {
        [Theory]
        [InlineData("+5 Dexterity Vest", typeof(DefaultStockItemStrategy))]
        [InlineData("Conjured Mana Cake", typeof(ConjuredStockItemStrategy))]
        [InlineData("Aged Brie", typeof(AgedBrieStockItemStrategy))]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassStockItemStrategy))]
        public void StockItemStrategyFactory_Create_Returns_Expected_Results(
            string itemName,
            Type expectedImplementation
        )
        {
            //Arrange and act
            var result = new StockItemStrategyFactory().Create(itemName);
            //Assert
            Assert.Equal(expectedImplementation, result.GetType());
        }
    }
}
