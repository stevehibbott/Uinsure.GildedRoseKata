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
            throw new System.NotImplementedException();
        }
    }

}