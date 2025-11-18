using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class Restaurant
    {
        private List<Menu> _menu;
        private List<Order> _activeOrders;

        public Restaurant()
        {
            _menu = new List<Menu>();
            _activeOrders = new List<Order>();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
         
            _menu.Add(new Dish("Борщ", 120, DishCategory.Soup, 350));
            _menu.Add(new Dish("Цезар", 150, DishCategory.Salad, 250));
            _menu.Add(new Dish("Стейк", 350, DishCategory.MainCourse, 300));
            _menu.Add(new Dish("Тірамісу", 110, DishCategory.Dessert, 150));

            
            _menu.Add(new Drink("Кава", 60, 200, false));
            _menu.Add(new Drink("Вино", 120, 150, true));
            _menu.Add(new Drink("Сік", 70, 250, false));
        }

        public void ShowMenu()
        {
            Console.WriteLine("\n=== МЕНЮ РЕСТОРАНУ ===");
            foreach (var item in _menu)
            {
                Console.WriteLine(item.GetDetails() + $" - {item.Price} грн");
            }
            Console.WriteLine("======================\n");
        }

        public Order CreateOrder(int tableNumber)
        {
            var order = new Order(tableNumber);
            _activeOrders.Add(order);
            Console.WriteLine($"Створено нове замовлення №{order.Id} для столика {tableNumber}");
            return order;
        }

        public Menu FindMenuItem(string name)
        {
            return _menu.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void ShowAllOrders()
        {
            Console.WriteLine("\n--- АКТИВНІ ЗАМОВЛЕННЯ ---");
            if (_activeOrders.Count == 0)
            {
                Console.WriteLine("Немає активних замовлень.");
            }
            else
            {
                foreach (var order in _activeOrders)
                {
                    Console.WriteLine($"ID: {order.Id} | Стіл: {order.TableNumber} | Статус: {order.Status} | Сума: {order.CalculateTotal()} грн");
                }
            }
            Console.WriteLine("--------------------------\n");
        }
    }
}
