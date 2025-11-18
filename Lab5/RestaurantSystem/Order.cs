using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class Order
    {
        private static int _idCounter = 0; 

        public int Id { get; private set; }
        public int TableNumber { get; private set; }
        public OrderStatus Status { get; private set; }

        
        private List<Menu> _items;

        public Order(int tableNumber)
        {
            Id = ++_idCounter;
            TableNumber = tableNumber;
            Status = OrderStatus.New;
            _items = new List<Menu>();
        }

        public void AddItem(Menu item)
        {
            if (Status == OrderStatus.Paid)
            {
                Console.WriteLine($"Помилка: Не можна додавати позиції до оплаченого замовлення №{Id}.");
                return;
            }
            _items.Add(item);
            Console.WriteLine($"До замовлення №{Id} додано: {item.Name}");
        }

        public void RemoveItem(string itemName)
        {
            var item = _items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                _items.Remove(item);
                Console.WriteLine($"З замовлення №{Id} видалено: {item.Name}");
            }
            else
            {
                Console.WriteLine($"Помилка: Позицію '{itemName}' не знайдено.");
            }
        }

        public decimal CalculateTotal()
        {
            return _items.Sum(i => i.Price);
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Статус замовлення №{Id} змінено на: {Status}");
        }

        
        public void SplitBill(int guests)
        {
            if (guests <= 0)
            {
                Console.WriteLine("Помилка: Кількість гостей має бути більше 0.");
                return;
            }

            decimal total = CalculateTotal();
            decimal perPerson = total / guests;

            Console.WriteLine($"\n--- Розділення чека (Order №{Id}) ---");
            Console.WriteLine($"Всього до сплати: {total} грн");
            Console.WriteLine($"Кількість гостей: {guests}");
            Console.WriteLine($"До сплати з кожного: {perPerson} грн\n");
        }

        public void PrintOrderDetails()
        {
            Console.WriteLine($"\n--- Деталі замовлення №{Id} (Стіл {TableNumber}) ---");
            foreach (var item in _items)
            {
                Console.Write($"{item.Name.PadRight(20)} | {item.Price} грн | ");

                
                if (item is Drink drink)
                {
                    Console.WriteLine($"Об'єм: {drink.VolumeMl} мл");
                }
                else if (item is Dish dish)
                {
                    Console.WriteLine($"Категорія: {dish.Category}");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"-----------------------------------------");
            Console.WriteLine($"ЗАГАЛЬНА СУМА: {CalculateTotal()} грн");
            Console.WriteLine($"Статус: {Status}\n");
        }
    }
}
