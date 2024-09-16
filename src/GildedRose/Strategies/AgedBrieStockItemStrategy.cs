namespace GildedRose.Strategies
{
    public class AgedBrieStockItemStrategy : StockItemStrategyBase, IStockItemStrategy
    {
        public void UpdateItem(Item item)
        {
            IncreaseQuality(item);
            item.SellIn--;
            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }
    }
}