namespace GildedRose.Strategies
{
    public class BackstagePassStockItemStrategy : StockItemStrategyBase, IStockItemStrategy
    {
        private readonly int ThresholdInDaysOfFirstQualityIncrease = 11;
        private readonly int ThresholdInDaysOfSecondQualityIncrease = 6;

        public void UpdateItem(Item item)
        {
            IncreaseQuality(item);
            if (item.SellIn < ThresholdInDaysOfFirstQualityIncrease)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < ThresholdInDaysOfSecondQualityIncrease)
            {
                IncreaseQuality(item);
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}