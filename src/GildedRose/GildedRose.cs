using System.Collections.Generic;
using GildedRose.Strategies;

namespace GildedRose
{
    public class GildedRose(IList<Item> Items)
    {
        IList<Item> Items = Items;

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == Constants.Conjured)
                {
                    new ConjuredStockItemStrategy().UpdateItem(item);
                }
                else if (item.Name != Constants.BackstagePasses && item.Name != Constants.Sulfuras && item.Name != Constants.AgedBrie)
                {
                    new DefaultStockItemStrategy().UpdateItem(item);
                }
                else if (item.Name == Constants.BackstagePasses)
                {
                     new BackstagePassStockItemStrategy().UpdateItem(item);
                }
                else if (item.Name == Constants.AgedBrie)
                {
                    new AgedBrieStockItemStrategy().UpdateItem(item);
                }
            }
        }
    }
}
