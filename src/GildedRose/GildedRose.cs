using System.Collections.Generic;
using GildedRose.Strategies;

namespace GildedRose
{
    public class GildedRose(IList<Item> Items)
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const int MaxQuality = 50;
        private const int ThresholdInDaysOfFirstQualityIncrease = 11;
        private const int ThresholdInDaysOfSecondQualityIncrease = 6;

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
                    UpdateBackstagePasses(item);
                }
                else if (item.Name == AgedBrie)
                {
                    UpdateAgedBrie(item);
                }
            }
        }

        private static void UpdateBackstagePasses(Item item)
        {
            IncreaseQuality(item);
            IncreaseBackstagePassesQuality(item);
            
            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        private static void UpdateAgedBrie(Item item)
        {
            IncreaseQuality(item);
            item.SellIn--;
            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }

        private static void IncreaseBackstagePassesQuality(Item item)
        {
            if (item.SellIn < ThresholdInDaysOfFirstQualityIncrease)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < ThresholdInDaysOfSecondQualityIncrease)
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
}
