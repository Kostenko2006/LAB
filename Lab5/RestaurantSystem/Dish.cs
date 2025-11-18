using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestaurantSystem
{
    public class Dish : Menu
    {
        public DishCategory Category { get; private set; }
        public int WeightGrams { get; private set; }

        public Dish(string name, decimal price, DishCategory category, int weight): base(name, price)
        {
            Category = category;
            WeightGrams = weight;
        }

        public override string GetDetails()
        {
            return $"[Страва] {Name} ({Category}, {WeightGrams}г)";
        }
    }
}
