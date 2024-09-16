using System;
using GildedRose.Strategies;

namespace GildedRose.Factories
{
    public interface IStockItemStrategyFactory
    {
        IStockItemStrategy Create(string itemName);
    }

    public class StockItemStrategyFactory : IStockItemStrategyFactory
    {
        public IStockItemStrategy Create(string itemName)
        {
            return itemName switch
            {
                Constants.Conjured => new ConjuredStockItemStrategy(),
                Constants.Sulfuras => new SulfurasStockItemStrategy(),
                Constants.BackstagePasses => new BackstagePassStockItemStrategy(),
                Constants.AgedBrie => new AgedBrieStockItemStrategy(),
                _ => new DefaultStockItemStrategy(),
            };
        }
    }
}
