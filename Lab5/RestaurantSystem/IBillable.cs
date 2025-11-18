using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public interface IBillable
    {
        string Name { get; }
        decimal Price { get; }
        string GetDescription();
    }
}
