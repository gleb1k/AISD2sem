using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class BagGreedy
    {
        private class Item
        {
            public int Weight { get; set; }
            public int Price { get; set; }
            public double PricePerWeight { get; }

            public Item(int weight, int price)
            {
                Weight = weight;
                Price = price;
                PricePerWeight = Price / Weight;
            }
        }
        public void Run()
        {
            var itemList = new List<Item>()
            {
                new Item(30, 90),
                new Item(15, 30),
                new Item(5, 10),
                new Item(50, 100),
                new Item(2, 2)
            }
            .OrderByDescending(x => x.PricePerWeight)
            .ThenBy(x => x.Weight);

            var bagWeight = 42;
            var sumPrice = 0;

            foreach (var item in itemList)
            {
                while (bagWeight >= item.Weight)
                {
                    Console.WriteLine(
                        $"Положен предмет с весом {item.Weight}" +
                        $" и ценностью {item.Price}");
                    sumPrice += item.Price;
                    bagWeight -= item.Weight;
                }
            }

            Console.WriteLine($"Суммарная стоимость {sumPrice}");
        }
    }
}
    
    

