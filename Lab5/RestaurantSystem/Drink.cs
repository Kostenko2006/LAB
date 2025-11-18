using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestaurantSystem
{
    public class Drink : Menu
    {
        public double VolumeMl { get; private set; }
        public bool IsAlcoholic { get; private set; }

        public Drink(string name, decimal price, double volume, bool isAlcoholic): base(name, price)
        {
            VolumeMl = volume;
            IsAlcoholic = isAlcoholic;
        }

        public override string GetDetails()
        {
            string alcMarker;

            if (IsAlcoholic)
            {
                alcMarker = "Алк.";
            }
            else
            {
                alcMarker = "Безалк.";
            }

            return $"[Напій] {Name} ({VolumeMl} мл, {alcMarker})";
        }
    }
}
