namespace GildedRose.Strategies
{
    public class DefaultStockItemStrategy : StockItemStrategyBase, IStockItemStrategy
    {
        public void UpdateItem(Item item)
        {
            DegradeQualityAndSellIn(item, 1);
        }
    }
}