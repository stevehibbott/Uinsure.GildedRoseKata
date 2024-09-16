namespace GildedRose.Strategies
{
    public interface IStockItemStrategy
    {
        void UpdateItem(Item item);
    }

    public class DefaultStockItemStrategy : StockItemStrategyBase, IStockItemStrategy
    {
        public void UpdateItem(Item item)
        {
            DegradeQualityAndSellIn(item, 1);
        }
    }

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

    public class ConjuredStockItemStrategy : StockItemStrategyBase, IStockItemStrategy
    {
        public void UpdateItem(Item item)
        {
            DegradeQualityAndSellIn(item, 2);
        }
    }

    public abstract class StockItemStrategyBase
    {
        private static readonly int MaxQuality = 50;

        protected static void IncreaseQuality(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
            }
        }

        protected static void DegradeQualityAndSellIn(Item item, int qualityDegregationRate)
        {
            if (item.Quality > 0)
            {
                item.Quality -= qualityDegregationRate;
            }

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality -= qualityDegregationRate;
            }
        }
    }
}
