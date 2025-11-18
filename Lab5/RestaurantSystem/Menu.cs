using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public abstract class Menu : IBillable
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }

        protected Menu(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public abstract string GetDetails();

        public string GetDescription()
        {
            return $"{Name} - {Price} грн";
        }
    }
}
