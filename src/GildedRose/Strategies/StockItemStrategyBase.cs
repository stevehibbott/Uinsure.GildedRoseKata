namespace GildedRose.Strategies
{
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