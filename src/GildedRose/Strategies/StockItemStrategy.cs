
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
            throw new System.NotImplementedException();
        }
    }
}