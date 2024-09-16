namespace GildedRose.Strategies
{
    public class ConjuredStockItemStrategy : StockItemStrategyBase, IStockItemStrategy
    {
        public void UpdateItem(Item item)
        {
            DegradeQualityAndSellIn(item, 2);
        }
    }
}