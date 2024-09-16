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
            if (itemName == Constants.Conjured)
            {
                return new ConjuredStockItemStrategy();
            }
            else if (itemName == Constants.Sulfuras)
            {
                return new SulfurasStockItemStrategy();
            }
            else if (
                itemName != Constants.BackstagePasses
                && itemName != Constants.Sulfuras
                && itemName != Constants.AgedBrie
            )
            {
                return new DefaultStockItemStrategy();
            }
            else if (itemName == Constants.BackstagePasses)
            {
                return new BackstagePassStockItemStrategy();
            }
            else if (itemName == Constants.AgedBrie)
            {
                return new AgedBrieStockItemStrategy();
            }

            return new DefaultStockItemStrategy();
        }
    }
}
