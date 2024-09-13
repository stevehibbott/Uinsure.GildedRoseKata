namespace GildedRose.Strategies
{
    public interface IStockItemStrategy
    {
        void UpdateItem(Item item);
    }

    public class DefaultStockItemStrategy : IStockItemStrategy
    {
        public void UpdateItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }

    public class AgedBrieStockItemStrategy : IStockItemStrategy
    {
        private static readonly int MaxQuality = 50;

        public void UpdateItem(Item item)
        {
            IncreaseQuality(item);
            item.SellIn--;
            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }
        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
            }
        }
    }

    public class BackstagePassStockItemStrategy : IStockItemStrategy
    {
        public void UpdateItem(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}
