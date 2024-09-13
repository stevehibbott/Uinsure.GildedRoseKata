using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const int MaxQuality = 50;
        private const int ThresholdInDaysOfFirstQualityIncrease = 11;
        private const int ThresholdInDaysOfSecondQualityIncrease = 6;

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name != AgedBrie && item.Name != BackstagePasses)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != Sulfuras)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < MaxQuality)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == BackstagePasses)
                        {
                            if (item.SellIn < ThresholdInDaysOfFirstQualityIncrease)
                            {
                                if (item.Quality < MaxQuality)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < ThresholdInDaysOfSecondQualityIncrease)
                            {
                                if (item.Quality < MaxQuality)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != Sulfuras)
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != AgedBrie)
                    {
                        if (item.Name != BackstagePasses)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != Sulfuras)
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (item.Quality < MaxQuality)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}