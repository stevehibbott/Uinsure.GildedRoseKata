using System;
using System.Collections.Generic;
using GildedRose.Factories;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new() {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                /*XXX - "Aged Brie" actually increases in Quality the older it gets - Looking at the approval test this is true but it increases by 2. 
                Need to check if this functionality is correct but will make assumption that since this is the Golden master that the current functionality is correct */
                new() {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new() {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new() {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new() {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                // XXX - This tests that Quality is not increased past quality limit
                new() {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // XXX - Added test coverage to show that Quality increases by 2 when there are 10 days or less
                new() {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 11,
                    Quality = 20
                },
                // XXX - Added test coverage to show that Quality increases by by 3 when there are 5 days or less
                new() {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 6,
                    Quality = 20
                },
                // XXX - Added test coverage to show that Quality drops to 0 after the concert
                new() {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 1,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new() {Name = "Conjured Mana Cake", SellIn = 3, Quality = 16}
            };

            var factory = new StockItemStrategyFactory();

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var item in Items)
                {
                    Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
                    factory.Create(item.Name).UpdateItem(item);
                }
                Console.WriteLine("");
            }
        }
    }
}
