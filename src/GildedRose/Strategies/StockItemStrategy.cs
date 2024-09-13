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
}
