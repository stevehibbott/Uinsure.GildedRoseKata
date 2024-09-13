using System.Collections.Generic;
using GildedRose.Strategies;

namespace GildedRose
{
    public class GildedRose(IList<Item> Items)
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        IList<Item> Items = Items;

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name != BackstagePasses && item.Name != Sulfuras & item.Name != AgedBrie)
                {
                    new DefaultStockItemStrategy().UpdateItem(item);
                }
                else if (item.Name == BackstagePasses)
                {
                     new BackstagePassStockItemStrategy().UpdateItem(item);
                }
                else if (item.Name == AgedBrie)
                {
                    new AgedBrieStockItemStrategy().UpdateItem(item);
                }
            }
        }
    }
}
