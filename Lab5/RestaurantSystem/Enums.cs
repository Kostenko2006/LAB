using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public enum OrderStatus
    {
        New,        
        InProgress, 
        Ready,      
        Paid        
    }

    public enum DishCategory
    {
        Soup,       
        MainCourse, 
        Dessert,    
        Salad       
    }
}
